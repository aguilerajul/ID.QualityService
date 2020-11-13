using System.Collections.Generic;
using AutoMapper;
using ID.QualityService.Api.Models;
using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ID.QualityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : Controller
    {
        private readonly IMapper mapper;
        private IRepository<AdVO> adVOService;
        private IRepository<PictureVO> pictureVOService;

        public AdsController(IMapper mapper, IRepository<AdVO> adVOService, IRepository<PictureVO> pictureVOService)
        {
            this.mapper = mapper;
            this.adVOService = adVOService;
            this.pictureVOService = pictureVOService;
        }

        // GET api/Ads        
        [Route("qualityListing")]
        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> qualityListing()
        {
            try
            {
                var pictures = this.pictureVOService.GetAll();
                return Ok(this.mapper.Map<IEnumerable<PictureVO>>(pictures));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("publicListing")]
        public ActionResult<IEnumerable<PublicAd>> publicListing()
        {
            try
            {
                var pictures = this.adVOService.GetAll();
                return Ok(this.mapper.Map<IEnumerable<AdVO>>(pictures));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("calculateScore")]
        public ActionResult calculateScore()
        {
            return NotFound();
        }
    }
}
