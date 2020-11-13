using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Infrastructure
{
    public class PictureVOService : IServiceBase<PictureVO>
    {
        private IMemoryData memoryData;

        public PictureVOService(IMemoryData memoryData)
        {
            this.memoryData = memoryData;
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
