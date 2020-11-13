using ID.QualityService.Domain.Ads;
using System;
using System.Collections.Generic;

namespace ID.QualityService.Domain.Interfaces
{
    public interface IAdVOService : IServiceBase<AdVO>
    {
        IEnumerable<AdVO> GetQualityAds();
        IEnumerable<AdVO> GetIrrelevantAds(DateTime? irrelevantDate = null);
        int GetTotalScore();
    }
}
