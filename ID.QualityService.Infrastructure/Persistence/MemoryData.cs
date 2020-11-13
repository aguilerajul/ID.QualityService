using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ID.QualityService.Repository.Persistence
{
    public class MemoryData
    {
        private IList<AdVO> ads;
        private IList<PictureVO> pictures;

        public MemoryData()
        {
            SetAds();
            SetPictures();
        }

        public IList<AdVO> GetAds()
        {
            return this.ads;
        }

        public IList<PictureVO> GetPictures()
        {
            return this.pictures;
        }

        private void SetAds()
        {
            ads = new List<AdVO>();
            ads.Add(new AdVO(1, Typology.CHALET, "Este piso es una ganga, compra, compra, COMPRA!!!!!", new List<int>(), 300));
            ads.Add(new AdVO(2, Typology.FLAT, "Nuevo ático céntrico recién reformado. No deje pasar la oportunidad y adquiera este ático de lujo", new List<int> { 4 }, 300));
            ads.Add(new AdVO(3, Typology.CHALET, "", new List<int> { 2 }, 300));
            ads.Add(new AdVO(4, Typology.FLAT, "Ático céntrico muy luminoso y recién reformado, parece nuevo", new List<int> { 5 }, 300));
            ads.Add(new AdVO(5, Typology.FLAT, "Pisazo,", new List<int> { 3, 8 }, 300));
            ads.Add(new AdVO(6, Typology.GARAGE, "", new List<int> { 6 }, 300));
            ads.Add(new AdVO(7, Typology.GARAGE, "Garaje en el centro de Albacete", new List<int>(), 300));
            ads.Add(new AdVO(8, Typology.CHALET, "Maravilloso chalet situado en lAs afueras de un pequeño pueblo rural. El entorno es espectacular, las vistas magníficas. ¡Cómprelo ahora!", new List<int> { 1, 7 }, 300));
        }

        private void SetPictures()
        {
            pictures = new List<PictureVO>();
            pictures.Add(new PictureVO(1, new Uri("http://www.idealista.com/pictures/1"), ImageQuality.SD));
            pictures.Add(new PictureVO(2, new Uri("http://www.idealista.com/pictures/2"), ImageQuality.HD));
            pictures.Add(new PictureVO(3, new Uri("http://www.idealista.com/pictures/3"), ImageQuality.SD));
            pictures.Add(new PictureVO(4, new Uri("http://www.idealista.com/pictures/4"), ImageQuality.HD));
            pictures.Add(new PictureVO(5, new Uri("http://www.idealista.com/pictures/5"), ImageQuality.SD));
            pictures.Add(new PictureVO(6, new Uri("http://www.idealista.com/pictures/6"), ImageQuality.SD));
            pictures.Add(new PictureVO(7, new Uri("http://www.idealista.com/pictures/7"), ImageQuality.SD));
            pictures.Add(new PictureVO(8, new Uri("http://www.idealista.com/pictures/8"), ImageQuality.HD));
        }
    }
}
