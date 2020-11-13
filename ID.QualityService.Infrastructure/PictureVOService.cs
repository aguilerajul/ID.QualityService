using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using ID.QualityService.Repository.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Repository
{
    public class PictureVOService : IRepository<PictureVO>
    {
        private MemoryData memoryData;

        public PictureVOService()
        {
            this.memoryData = new MemoryData();
        }

        public IEnumerable<PictureVO> GetAll()
        {
            return memoryData.GetPictures();
        }

        public PictureVO GetById(int id)
        {
            return memoryData.GetPictures().FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
