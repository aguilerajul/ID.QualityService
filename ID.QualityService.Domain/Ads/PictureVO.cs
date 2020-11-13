using ID.QualityService.Domain.Enums;
using System;

namespace ID.QualityService.Domain.Ads
{
    public class PictureVO : EntityBase
    {
        public Uri Url { get; private set; }
        public ImageQuality Quality { get; private set; }

        public PictureVO(int id, Uri url, ImageQuality quality) 
            : base(id)
        {
            this.Url = url;
            this.Quality = quality;
        }
    }
}
