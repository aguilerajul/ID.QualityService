using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using ID.QualityService.Repository.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Repository
{
    public class AdVOService : IRepository<AdVO>
    {
        private MemoryData memoryData;

        public AdVOService()
        {
            this.memoryData = new MemoryData();
        }

        public IEnumerable<AdVO> GetAll()
        {
            return memoryData.GetAds();
        }

        public AdVO GetById(int id)
        {
            return memoryData.GetAds().FirstOrDefault(advo => advo.Id.Equals(id));
        }
    }
}
