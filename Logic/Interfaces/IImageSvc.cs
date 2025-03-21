﻿using Model.Models;

namespace Logic.Interfaces
{
    public interface IImageSvc
    {
        public IEnumerable<ImageDTO> GetCheckpointImages(int modelId);
        public IEnumerable<ImageDTO> GetUserImages(int userId);
        public IEnumerable<ImageDTO> GetModelImages(int modelId);
        public MetadataDTO GetImageMetadata(int imageId);
        public ImageDTO GetImageData(int imageId);
        public IEnumerable<ImageDTO> GetFeaturedImages();
        public IEnumerable<ImageDTO> GetFeaturedModels(IEnumerable<int>ids);
        public IEnumerable<CommentDTO> GetComments(int imageId);
        public byte[] GetImage(Guid imageId);
        public byte[] GetImage(int imageId);
        public byte[] GetProfilePicture(Guid imageId);
        public int PostReaction(ReactionDTO reaction);
        public void PostComment(CommentDTO comment);
        public IEnumerable<ImageDTO> SearchImages(string searchTerm);
        public IEnumerable<ImageDTO> GetAllImages();
        public void SaveImage(byte[] bytes, GenerationDataDTO data);
        public Guid SaveProfilePic(byte[] bytes);
        public IEnumerable<ImageDTO> GetModelExamples(int modelId);
        public IEnumerable<ImageDTO> GetUnpublished(int userId);
        public void RemoveImage(Guid imageRef);
        public int PublishImage(ImageDTO imageDTO);
        public IEnumerable<ImageDTO> GetAllModels(IEnumerable<int>? ids);
    }
}
