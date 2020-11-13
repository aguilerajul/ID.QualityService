using FluentAssertions;
using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ID.QualityService.Infrastructure.Tests
{
    public class AdVOServiceTests
    {
        private IAdVOService adVOService;
        private Mock<IMemoryData> memoryData;

        public AdVOServiceTests()
        {
            memoryData = new Mock<IMemoryData>();
            adVOService = new AdVOService(memoryData.Object);
        }

        [Fact]
        public void Get_All_Empty_Test()
        {
            var emptyResult = new List<AdVO>();

            memoryData.Setup(m => m.GetAds()).Returns(new List<AdVO>());

            var result = adVOService.GetAll();

            result.Should().BeEmpty();
        }

        [Fact]
        public void Get_All_With_Data_Success_Test()
        {
            var mockItem = Mocks.AdVOMocks.OneItem();

            memoryData.Setup(m => m.GetAds()).Returns(new List<AdVO>() {
                new AdVO(1,
                Domain.Enums.Typology.CHALET,
                "Test description whit just few Characters",
                new List<int>(),
                100)
            });

            var result = adVOService.GetAll();

            result.Should().NotBeEmpty();
            result.FirstOrDefault().Description.Should().NotBeEmpty();
            result.FirstOrDefault().Should().Equals(result);
        }

        [Fact]
        public void Get_Quality_Ads_Success_Test()
        {
            var mockItem = Mocks.AdVOMocks.MultipleItems();

            memoryData.Setup(m => m.GetAds()).Returns(Mocks.AdVOMocks.MultipleItems());

            var result = adVOService.GetQualityAds();

            result.Should().NotBeEmpty();
            result.Count().Should().BeGreaterThan(1);
            result.FirstOrDefault().Description.Should().NotBeEmpty();
            result.FirstOrDefault().Description.Length.Should().BeGreaterThan(40);
        }

        [Fact]
        public void Get_Irrelevant_Ads_Without_Date_Success_Test()
        {
            var mockItem = Mocks.AdVOMocks.MultipleItems();

            memoryData.Setup(m => m.GetAds()).Returns(Mocks.AdVOMocks.MultipleItems());

            var result = adVOService.GetIrrelevantAds();

            result.Should().NotBeEmpty();
            result.Count().Should().BeGreaterOrEqualTo(1);
            result.FirstOrDefault().Description.Should().NotBeEmpty();
            result.FirstOrDefault().Description.Length.Should().BeLessThan(40);
        }

        [Fact]
        public void Get_Irrelevant_Ads_With_Date_Success_Test()
        {
            var mockItem = Mocks.AdVOMocks.MultipleItems();

            memoryData.Setup(m => m.GetAds()).Returns(Mocks.AdVOMocks.MultipleItems());

            var result = adVOService.GetIrrelevantAds(DateTime.UtcNow.AddDays(-4));

            result.Should().NotBeEmpty();
            result.Count().Should().BeGreaterOrEqualTo(1);
            result.FirstOrDefault().Description.Should().NotBeEmpty();
            result.FirstOrDefault().Description.Length.Should().BeLessThan(40);
        }

        [Fact]
        public void Get_Total_Score_Success_Test()
        {
            var mockItem = Mocks.AdVOMocks.MultipleItems();

            memoryData.Setup(m => m.GetAds()).Returns(Mocks.AdVOMocks.MultipleItems());

            var result = adVOService.GetTotalScore();

            result.Should().BeGreaterThan(40);
        }
    }
}
