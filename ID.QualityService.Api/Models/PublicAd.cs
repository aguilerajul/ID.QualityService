using System;
using System.Collections.Generic;

namespace ID.QualityService.Api.Models
{
    public class PublicAd
    {
        public int Id { get; private set; }
        public string Typology { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Uri> PictureUrls { get; private set; }
        public int HouseSize { get; private set; }
        public int GardenSize { get; private set; }
    }
}
