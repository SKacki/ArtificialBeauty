using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;
using Model.Models.Workflows;
using System.Text.Json;

namespace Logic
{
    public class GeneratorSvc : IGeneratorSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserSvc _userSvc;
        private readonly IImageSvc _imageSvc;
        private readonly IModelRepository _modelRepo;
        private readonly GeneratorClient _client;
        private readonly MetadataValidator _validator;

        public GeneratorSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IImageSvc imageSvc,
            IModelRepository modelRepository,
            GeneratorClient genClient)
        {
            _userSvc = userSvc;
            _imageSvc = imageSvc;
            _modelRepo = modelRepository;
            _mapper = mapper;
            _client = genClient;
            _validator = new MetadataValidator();
        }

        //public string RequestGeneration(GenerationDataDTO metadata)
        //{            
        //    var workflow = CreateBaseWorkflow(metadata);
        //    if ((metadata.Lora1Id ?? 0) != 0 )
        //        workflow = AddLora(workflow, (int)metadata.Lora1Id,1);
        //    if((metadata.Lora2Id ?? 0) != 0)
        //        workflow = AddLora(workflow, (int)metadata.Lora2Id,2);

        //    // Serialize back to JSON
        //    var jsonStringOutput = JsonSerializer.Serialize(workflow, new JsonSerializerOptions { WriteIndented = false });

        //    return jsonStringOutput;
        //}

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
        //public MetadataDTO RemixImage(int metadataId) => _imageSvc.GetImageMetadata(metadataId);

        public async Task<byte[]?> AskComfyUI(Dictionary<string, WorkflowNode> workflow)
            => await _client.PostAsync<byte[]>("fetch_image_from_comfy", workflow);

        private Dictionary<string, WorkflowNode> CreateBaseWorkflow(GenerationDataDTO metadata)
        {
            return new Dictionary<string, WorkflowNode>
            {
                { "0", new ModelLoader(_modelRepo.GetById(metadata.ModelId).Path) },
                { "3", new ClipTextEncode(true, metadata.PromptPoz) },
                { "4", new ClipTextEncode(false, metadata.PromptNeg) },
                { "5", new EmptyLatentImage() },
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
    }
}
