using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Infrastructure
{
    public class AdVOService : IAdVOService
    {
        private IMemoryData memoryData;

        public AdVOService(IMemoryData memoryData)
        {
            this.memoryData = memoryData;
        }

        public IEnumerable<AdVO> GetAll()
        {
            return memoryData.GetAds();
        }

        public AdVO GetById(int id)
        {
            return memoryData.GetAds().FirstOrDefault(advo => advo.Id.Equals(id));
        }

        public IEnumerable<AdVO> GetQualityAds()
        {
            return memoryData.GetAds()
                ?.Where(a => a.Score >= 40)
                ?.OrderByDescending(o => o.Score);
        }

        public IEnumerable<AdVO> GetIrrelevantAds(DateTime? irrelevantDate = null)
        {
            if(irrelevantDate == null)
                return memoryData.GetAds()
                    ?.Where(a => a.Score <= 40)
                    ?.OrderByDescending(o => o.Score);

            return memoryData.GetAds()
                ?.Where(a => a.Score <= 40 && a.IrrelevantSince >= irrelevantDate)
                ?.OrderByDescending(o => o.Score);
        }

        public int GetTotalScore()
        {
            int score = 0;
            var ads = memoryData.GetAds();
            if (ads == null)
                return score;

            var scoreSum = ads.Sum(a => a.Score);
            if (scoreSum != null)
                score = scoreSum.Value;

            return score;
        }
    }
}
