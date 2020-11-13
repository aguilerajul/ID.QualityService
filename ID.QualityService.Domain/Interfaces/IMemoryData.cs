using ID.QualityService.Domain.Ads;
using System.Collections.Generic;

namespace ID.QualityService.Domain.Interfaces
{
    public interface IMemoryData
    {
        IList<AdVO> GetAds();
        IList<PictureVO> GetPictures();
    }
}
