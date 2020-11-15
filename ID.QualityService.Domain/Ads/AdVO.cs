using ID.QualityService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ID.QualityService.Domain.Ads
{
    public class AdVO : EntityBase
    {
        public Typology Typology { get; private set; }
        public string Description { get; private set; }
        public IList<int> PictureIds { get; private set; }
        public int? HouseSize { get; private set; }
        public int? GardenSize { get; private set; }
        public int? Score { get; private set; }
        public DateTime? IrrelevantSince { get; set; }


        private IList<string> SpecificWords = new List<string> { "Luminoso", "Nuevo", "Céntrico", "Reformado", "Ático" };

        public AdVO(int id, Typology typology, string description, IList<int> pictures, int houseSize, int? gardenSize = null, DateTime? irrelevantSince = null)
            : base(id)
        {
            this.Typology = typology;
            this.Description = description;
            this.PictureIds = pictures;
            this.HouseSize = houseSize;
            this.GardenSize = gardenSize;
            this.Score = 0;
            this.IrrelevantSince = irrelevantSince;

            SetScore();
        }

        public void AddPictures(int pictureVoId)
        {
            this.PictureIds.Add(pictureVoId);
        }

        internal void SetScore()
        {
            SetScoreByPicture();
            SetScoreByDescription();
            SetScoreBySpecificWords();
            SetScoreByCompleteAds();
        }

        private void SetScoreByPicture()
        {
            if (this.PictureIds == null)
                this.Score -= 10;

            if (this.PictureIds != null && this.PictureIds.Any())                
                this.Score = this.PictureIds.Sum(p => { return 20; });

            ClampScore();
        }

        private void SetScoreByDescription()
        {
            if (!string.IsNullOrWhiteSpace(this.Description))
                this.Score += 5;

            if (this.Description.Length >= 20 && this.Description.Length <= 49)
                this.Score += 10;

            if (this.Typology != Typology.CHALET && this.Description.Length >= 50)
                this.Score += 30;

            if (this.Typology == Typology.CHALET && this.Description.Length >= 50)
                this.Score += 20;

            ClampScore();
        }

        private void SetScoreBySpecificWords()
        {
            foreach (var specificWord in SpecificWords)
            {
                if (this.Description.ToLower().Contains(specificWord.ToLower()))
                    this.Score += 5;
            }

            ClampScore();
        }

        private void SetScoreByCompleteAds()
        {
            if (!string.IsNullOrWhiteSpace(this.Description) &&
                (this.PictureIds != null && this.PictureIds.Any())
                && (
                    (this.Typology == Typology.FLAT && this.HouseSize != null)
                    || (this.Typology == Typology.CHALET && this.HouseSize != null && this.GardenSize != null)
                    || (this.Typology == Typology.GARAGE)
                    )
                )
                this.Score += 40;

            ClampScore();
        }

        private void ClampScore()
        {
            this.Score = Math.Clamp(this.Score.Value, 0, 100);
        }
    }
}
