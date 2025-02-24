﻿using Model.Models;

namespace Logic.Interfaces
{
    public interface IImageSvc
    {
        public IEnumerable<ImageDTO> GetCheckpointImages(int modelId);
        public IEnumerable<ImageDTO> GetUserImages(int userId);
        public IEnumerable<ImageDTO> GetModelImages(int modelId);
    }
}
