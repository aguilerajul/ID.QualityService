using ID.QualityService.Domain.Ads;
using System;
using System.Collections.Generic;

namespace ID.QualityService.Infrastructure.Tests.Mocks
{
    public static class AdVOMocks
    {
        public static IList<AdVO> OneItem()
        {
            return new List<AdVO>() {
                new AdVO(1,
                Domain.Enums.Typology.CHALET,
                "Test description whit just few Characters",
                new List<int>(),
                100)
            };
        }

        public static IList<AdVO> MultipleItems()
        {
            return new List<AdVO>() {
                new AdVO(1,
                    Domain.Enums.Typology.CHALET,
                    "Test description whit just few Characters",
                     new List<int>(),
                     100),
                new AdVO(2,
                    Domain.Enums.Typology.FLAT,
                    "Test description whit just few Characters and it's a FLAT",
                    new List<int>(){ 1, 2 },
                    300),
                new AdVO(3,
                    Domain.Enums.Typology.GARAGE,
                    "Test description whit just few Characters using a Garage as Example",
                    new List<int>() { 3 },
                    200),
                 new AdVO(4,
                    Domain.Enums.Typology.FLAT,
                    "Test Flat with Irrelevant Date",
                    new List<int>(),
                    200, irrelevantSince: DateTime.UtcNow.AddDays(-2)),
                 new AdVO(4,
                    Domain.Enums.Typology.CHALET,
                    "Test description whit just few Characters using a CHALET with all the data",
                    new List<int>() { 4, 5, 6 },
                    400,
                    1000),
                  new AdVO(5,
                    Domain.Enums.Typology.CHALET,
                    "Test description",
                    new List<int>() { 6 },
                    200,
                    500),
                  new AdVO(6,
                    Domain.Enums.Typology.FLAT,
                    "description",
                    new List<int>() { 3,5 },
                    50),
                   new AdVO(7,
                    Domain.Enums.Typology.FLAT,
                    "amazing FLAT",
                    new List<int>() { 3 },
                    50,
                    irrelevantSince: DateTime.UtcNow.AddDays(-1)),
                   new AdVO(8,
                    Domain.Enums.Typology.FLAT,
                    "New",
                    new List<int>(),
                    50),
            };
        }
    }
}
