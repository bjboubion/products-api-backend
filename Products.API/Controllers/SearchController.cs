using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using products_api.Products.API.Interfaces;
using products_api.Products.API.ViewModel;

namespace products_api.Products.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class SearchController : ProductsControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IKitService _kitService;

        public SearchController(ILogger<SearchController> logger, IKitService kitService)
        {
            _logger = logger;
            _kitService = kitService;
        }

        /// <summary>
        /// Retrieves a list of ALL kits
        /// </summary>
        /// <returns>A list of KitViewModel</returns>
        /// <response code="200">Returns the list of Kits</response>
        /// <response code="404">If no kits exist</response>
        [HttpGet("", Name = "SearchAllKits")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<KitViewModel>>> Get()
        {
   
            _logger.LogInformation("Getting list of kits");

            var variantList = new List<KitViewModel>();

            try
            {
                if (ModelState.IsValid)
                {
                    variantList = await _kitService.GetAll();
                    _logger.LogInformation("Successfully retrieved list of Variants");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting list of kits");
                return BadRequest(e);
            }

            return Ok(variantList);
        }
    }
}