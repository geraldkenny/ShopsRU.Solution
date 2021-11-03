using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopRU.Core.Helpers;
using ShopRU.Core.ModelDTO;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ShopsRU.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class DiscountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DiscountsController> _logger;

        public DiscountsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DiscountsController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets all available discount types
        /// </summary>
        /// <returns></returns>
        // GET: api/<DiscountsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var discounts = await _unitOfWork.CustomerRepository.GetAllAsync();
            var discountsDto = _mapper.Map<IEnumerable<DiscountDTO>>(discounts);

            return Ok(discountsDto);
        }

        // GET api/<DiscountsController>/5
        /// <summary>
        ///Get a specific discount percentage by type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null || !id.HasValue)
            {
                return NotFound(new ErrorResponse
                {
                    ErrorDescription = $"{nameof(id)} is required"
                });
            }

            var discount = await _unitOfWork.DiscountRepository.GetByTypeAsync((UserType)id.Value);

            if (discount == null)
            {
                return NotFound(new ErrorResponse
                {
                    ErrorDescription = $"{id} is not found or does not exist"
                });
            }
            var discountDto = _mapper.Map<DiscountDTO>(discount);

            return Ok(discountDto);
        }

        /// <summary>
        /// Add a new discount type
        /// </summary>
        /// <param name="discountModel"></param>
        /// <returns></returns>
        // POST api/<DiscountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiscountDTO discountModel)
        {
            _logger.LogInformation("HttpPost CustomersController.Post called.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.GetModelStateErrors(ModelState.Values));
            }

            var discount = _mapper.Map<Discounts>(discountModel);
            try
            {
                await _unitOfWork.DiscountRepository.InsertAsync(discount);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured");

                return Ok(new ErrorResponse { ErrorDescription = "Can not insert duplicate of user type in discounts" });
            }

            return Ok(discount);
        }
    }
}