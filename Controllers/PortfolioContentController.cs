using System.Collections.Generic;
using asp_net_microservice_template.Models;
using asp_net_microservice_template.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_microservice_template.Controllers
{
    [Route("api/portfolio/")]
    [ApiController]
    public class PortfolioContentController : ControllerBase
    {
        private readonly PortfolioContentService _portfolioContentService;

        public PortfolioContentController(PortfolioContentService portfolioContentService)
        {
            _portfolioContentService = portfolioContentService;
        }

        [HttpGet("about")]
        public ActionResult<PortfolioContentDTO> GetAbout() => _portfolioContentService.GetAbout();

        [HttpPost("about")]
        public ActionResult<PortfolioContentDTO> UpdateAbout([FromBody] string newAboutContent)
        {
            _portfolioContentService.UpdateAbout(newAboutContent);
            return GetAbout();
        }
    }
}