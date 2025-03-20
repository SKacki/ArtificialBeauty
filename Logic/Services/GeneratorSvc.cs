using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using Model.Models.Workflows;

namespace Logic
{
    public class GeneratorSvc : IGeneratorSvc
    {
        private readonly IImageSvc _imageSvc;
        private readonly IModelRepository _modelRepo;
        private readonly IGeneratorClient _client;
        private readonly IWebSocketSvc _websocketSvc;
        private readonly IOperationSvc _operationSvc;
        private readonly IMapper _mapper;

        public GeneratorSvc(
            IImageSvc imageSvc,
            IModelRepository modelRepository,
            IOperationSvc operationSvc,
            IGeneratorClient genClient,
            IWebSocketSvc websocketSvc,
            IMapper mapper)
        {
            _imageSvc = imageSvc;
            _modelRepo = modelRepository;
            _client = genClient;
            _websocketSvc = websocketSvc;
            _operationSvc = operationSvc;
            _mapper = mapper;
        }

        public Dictionary<string, WorkflowNode> GetWorkflow(GenerationDataDTO metadata)
        {
            var workflow = CreateBaseWorkflow(metadata);
            if ((metadata.Lora1Id ?? 0) != 0)
            {
                workflow = AddLora(workflow, (int)metadata.Lora1Id, 1);
                if ((metadata.Lora2Id ?? 0) != 0)
                    workflow = AddLora(workflow, (int)metadata.Lora2Id, 2);
            }

            return workflow;
        }
        public MetadataDTO RemixImage(int metadataId) => _imageSvc.GetImageMetadata(metadataId);

        public async Task<byte[]?> AskComfyUI(GenerationDataDTO genData, string uid)
        {
            if (_operationSvc.GenerationFee(_mapper.Map<MetadataDTO>(genData),genData.UserId) == -1)
                throw new ArgumentException();

            var data = ValidateGenerationData(genData);
            var workflow = GetWorkflow(data);
            var img = await _websocketSvc.FetchImageFromComfyAsync(workflow,uid);
            //var img = await _client.PostWorkflowAsync<byte[]>("generate", workflow);
            _imageSvc.SaveImage(img, data);

            return img;
        }
        public async Task<int?> HealthCheck()
        {
            return await new Task<int>(()=> 0); //_client.GetAsync<int?>("HealthCheck");
        }

        private Dictionary<string, WorkflowNode> CreateBaseWorkflow(GenerationDataDTO metadata)
        {
            return new Dictionary<string, WorkflowNode>
            {
                { "0", new ModelLoader(_modelRepo.GetById(metadata.ModelId).Path) },
                { "3", new ClipTextEncode(true, metadata.PromptPoz) },
                { "4", new ClipTextEncode(false, metadata.PromptNeg) },
                { "5", new EmptyLatentImage(metadata.Width,metadata.Height)},
                { "6", new KSampler(metadata) },
                { "7", new VAEDecode() },
                { "8", new SaveImageWebsocket() }
            };
        }
        private Dictionary<string, WorkflowNode> AddLora(Dictionary<string, WorkflowNode> workflow,int modelId, int index)
        {
            workflow.Add(index.ToString(), new LoraLoader(_modelRepo.GetById(modelId).Path,index));
            workflow["3"].SetInput("clip", new object[] { index.ToString(), 1 });
            workflow["4"].SetInput("clip", new object[] { index.ToString(), 1 });
            workflow["6"].SetInput("model", new object[] { index.ToString(), 0 });

            if (index > 1)
            {
                workflow[index.ToString()].SetInput("model", new object[] { (index - 1).ToString(), 0 });
                workflow[index.ToString()].SetInput("clip", new object[] { (index - 1).ToString(), 1 });
            }

            return workflow;
        }
        private GenerationDataDTO ValidateGenerationData(GenerationDataDTO data)
        {
            Random rnd = new();

            if (data.ModelId == 0)
                data.ModelId = 1;
            if (data.Lora1Id == 0)
                data.Lora1Id = null;
            if (data.Lora2Id == 0) 
                data.Lora2Id = null;
            
            data.Sampler = data.Sampler.ToLower();
            data.Scheduler = data.Scheduler.ToLower();
            if(data.Guidance<=0 || data.Guidance > 10) 
                data.Guidance = 5;
            if(data.Steps<=0 || data.Steps > 60)
                data.Steps=20;
            if(data.Seed == null || data.Seed == 0)
                data.Seed = rnd.Next(int.MaxValue);
            if (data.Height <= 0)
                data.Height = 1024;
            if (data.Width <= 0)
                data.Width = 1024;
            if (data.Description.IsNullOrEmpty())
                data.Description = "MyImage";
            return data;
        }

    }
}
