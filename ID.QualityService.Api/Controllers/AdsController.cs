using System;
using System.Collections.Generic;
using AutoMapper;
using ID.QualityService.Api.Models;
using ID.QualityService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ID.QualityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : Controller
    {
        private readonly IMapper mapper;
        private ILogger<AdsController> logger;
        private IAdVOService adVOService;
        
        public AdsController(IMapper mapper, ILogger<AdsController> logger, IAdVOService adVOService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.adVOService = adVOService;
        }

        // GET api/Ads        
        [Route("qualityListing/{irrelevantDate}")]
        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> qualityListing(DateTime? irrelevantDate)
        {
            try
            {
                var irrelevantAds = this.adVOService.GetIrrelevantAds(irrelevantDate);
                if (irrelevantAds == null)
                    return NoContent();

                var mapping = this.mapper.Map<IEnumerable<QualityAd>>(irrelevantAds);
                return Ok(mapping);
            }
            catch (Exception ex)
            {
                logger.LogError("Error on AdsController -> qualityListing: ", ex);
                return NotFound();
            }
        }

        [HttpGet]
        [Route("publicListing")]
        public ActionResult<IEnumerable<PublicAd>> publicListing()
        {
            try
            {
                var ads = this.adVOService.GetQualityAds();
                var mapping = this.mapper.Map<IEnumerable<PublicAd>>(ads);

                return Ok(this.mapper.Map<IEnumerable<PublicAd>>(mapping));
            }
            catch (Exception ex)
            {
                logger.LogError("Error on AdsController -> publicListing: ", ex);
                return NotFound();
            }
        }

        [HttpGet]
        [Route("calculateScore")]
        public ActionResult calculateScore()
        {
            try
            {
                var score = this.adVOService.GetTotalScore();
                return Ok(score);
            }
            catch (Exception ex)
            {
                logger.LogError("Error on AdsController -> calculateScore: ", ex);
                return NotFound();
            }
        }
    }
}
