using FluentAssertions;
using ID.QualityService.Domain.Ads;
using System;
using System.Collections.Generic;
using Xunit;

namespace ID.QualityService.Domain.Tests
{
    public class AdVOTests
    {
        public AdVOTests()
        {
            
        }

        [Fact]
        public void Not_Empty_Success_Test()
        {
            var ad = new AdVO(1, Enums.Typology.CHALET, "Test Description", new List<int>(), 100);
            ad.Should().NotBeNull();
        }

        [Fact]
        public void Set_Min_Score_By_No_Picture_Test()
        {
            var ad = new AdVO(1, Enums.Typology.CHALET, "Test Description", null, 100);

            ad.Should().NotBeNull();
            ad.PictureIds.Should().BeNullOrEmpty();
            ad.Score.Should().BeGreaterOrEqualTo(5);
        }

        [Fact]
        public void Set_Score_By_Pictures_Test()
        {
            var ad = new AdVO(1, Enums.Typology.CHALET, "Test Description", new List<int>() { 1, 2 }, 100);
            ad.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(40);
        }

        [Fact]
        public void Set_Score_By_Description_Test()
        {
            var ad = new AdVO(1, Enums.Typology.CHALET, "Test Description", null,0);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(5);
        }

        [Fact]
        public void Set_Score_By_Description_less_than_50_and_greater_than_20_Test()
        {
            var ad = new AdVO(1, Enums.Typology.FLAT, "Test Description with minimun 49 characters CH", null, 0);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(15);
        }

        [Fact]
        public void Set_Score_By_Description_more_than_50_And_Not_Chalet_Test()
        {
            var ad = new AdVO(1, Enums.Typology.FLAT, "Test Description with minimun 49 characters CHALET", null, 0);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(35);
        }

        [Fact]
        public void Set_Score_By_Description_more_than_50_Chalet_Test()
        {
            var ad = new AdVO(1, Enums.Typology.FLAT, "Test Description with minimun 49 characters CHALET", null, 0);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(25);
        }

        [Theory]
        [InlineData("Piso Luminoso muy bonito y listo para ser habitado")]
        [InlineData("Piso totalmente nuevo listo para estrenar")]
        [InlineData("Piso muy Luminoso, Céntrico y muy bonito")]
        [InlineData("Piso totalmente Reformado")]
        [InlineData("Ático muy Céntrico y bastante Luminoso")]
        public void Set_Score_By_Description_Specific_Word(string description)
        {
            var ad = new AdVO(1, Enums.Typology.FLAT, description, null, 0);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(15);
        }

        [Theory]
        [InlineData(Enums.Typology.FLAT, 300, 0)]
        [InlineData(Enums.Typology.CHALET, 300, 0)]
        public void Set_Score_By_Full_Data_Test(Enums.Typology typology, int homeSize, int gardenSize)
        {
            var ad = new AdVO(1, typology, "Test Description with minimun 49 characters CHALET", new List<int> { 1, 2}, homeSize, gardenSize);
            ad.Should().NotBeNull();
            ad.Description.Should().NotBeNull();
            ad.Score.Should().BeGreaterOrEqualTo(40);
        }
    }
}
