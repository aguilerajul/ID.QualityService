
using AutoMapper;
using ID.QualityService.Api.Models;
using ID.QualityService.Domain.Ads;

namespace ID.QualityService.Api.Profiles
{
    public class AdsProfile : Profile
    {
        public AdsProfile()
        {
            CreateMap<AdVO, PublicAd>();
            CreateMap<QualityAd, PublicAd>();
        }
    }
}
