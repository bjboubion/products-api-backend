using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using products_api.Products.API.Interfaces;
using products_api.Products.API.ViewModel;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class KitsController : ProductsControllerBase
    {
        private readonly ILogger<KitsController> _logger;
        private readonly IKitService _kitService;

        public KitsController(ILogger<KitsController> logger, IKitService kitService)
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
        [HttpGet("", Name = "GetAllKits")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<KitViewModel>>> Get()
        {
   
            _logger.LogInformation("Getting list of kits");

            var variantList = new List<KitViewModel>();

            try
            {
                variantList = await _kitService.GetAll();
                _logger.LogInformation("Successfully retrieved list of Kits");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting list of Kits");
                return BadRequest(e);
            }

            return Ok(variantList);
        }

        // GET api/values
        [HttpGet("{sku}", Name = "GetKitBySku")]
        public async Task<ActionResult<KitViewModel>> GetBySku(string sku)
        {
            if (String.IsNullOrEmpty(sku))
            {
                return NotFound();
            }
            _logger.LogInformation("Getting list of kits");

            var kit = new KitViewModel();

            try
            {
                kit = await _kitService.GetBySku(sku);
                _logger.LogInformation("Successfully retrieved list of Variants");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting list of variants");
                return BadRequest(e);
            }

            return kit;
        }

        [HttpGet("{kitSku}/components", Name = "GetKitComponents")]
        public async Task<ActionResult<List<DbComponent>>> GetKitComponents(string kitSku)
        {
            var componentsList = new List<DbComponent>();

            try
            {
                componentsList = await _kitService.GetKitComponents(kitSku);
                _logger.LogInformation("Successfully retrieved component");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting component");
                return NotFound(e);
            }

            return Ok(componentsList);
        }

        /// <summary>
        /// Creates a new Kit
        /// </summary>
        /// <returns>Newly created Kit Id</returns>
        /// <response code="201">Returns the list of Kits</response>
        /// <response code="404">If no kits exist</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("", Name = "InsertKit")]
        public async Task<ActionResult<string>> Post([FromBody] KitAddRequest kitIn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _kitService.InsertKit(kitIn);
                    _logger.LogInformation("Successfully inserted kit");
                    return Created(nameof(GetBySku), response);
                }
            }
            catch (Exception e)
            {
                // throw new InvalidOperationException(e.ToString());
                return BadRequest(e);
            }

            return "error";
        }
    }
}