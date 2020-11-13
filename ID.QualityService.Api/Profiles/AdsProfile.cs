
using AutoMapper;
using ID.QualityService.Api.Models;
using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using ID.QualityService.Infrastructure;
using ID.QualityService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Api.Profiles
{
    public class AdsProfile : Profile
    {
        private IServiceBase<PictureVO> pictureVOService;

        public AdsProfile()
        {
            this.pictureVOService = new PictureVOService(new MemoryData());
            var pictures = this.pictureVOService.GetAll();

            CreateMap<AdVO, PublicAd>()
                .ForMember(dest => dest.PictureUrls,
                            opt => opt.MapFrom(src => GetUrls(src, pictures)));
            CreateMap<AdVO, QualityAd>()
                .ForMember(dest => dest.PictureUrls,
                            opt => opt.MapFrom(src => GetUrls(src, pictures)));
        }

        private IEnumerable<Uri> GetUrls(AdVO src, IEnumerable<PictureVO> pictures)
        {
            var adPictures = pictures.Where(p => src.PictureIds.Contains(p.Id));
            if (adPictures != null && adPictures.Any())
                return adPictures.Select(ap => ap.Url);

            return Enumerable.Empty<Uri>();
        }
    }
}
