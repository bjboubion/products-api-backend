using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using products_api.Products.API.Interfaces;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class ComponentsController : ProductsControllerBase
    {
        private readonly ILogger<ComponentsController> _logger;
        private readonly IComponentService _componentService;

        public ComponentsController(ILogger<ComponentsController> logger, IComponentService componentService)
        {
            _logger = logger;
            _componentService = componentService;
        }

        /// <summary>
        /// Get All Components
        /// </summary>
        /// <returns>New List of components</returns>
        /// <response code="200">Returns List of components</response>
        /// <response code="404">If there are no components</response>
        [HttpGet("", Name = "GetAllComponents")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<DbComponent>>> Get()
        {
   
            _logger.LogInformation("Getting list of kits");

            var variantList = new List<DbComponent>();

            try
            {
                variantList = await _componentService.GetAll();
                _logger.LogInformation("Successfully retrieved list of Components");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting list of variants");
                return NotFound(e);
            }

            return variantList;
        }
    }
}