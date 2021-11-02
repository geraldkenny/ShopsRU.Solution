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
using System.Net.Mime;
using System.Threading.Tasks;

namespace ShopsRU.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<CustomersController> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Gets all available customers
        /// </summary>
        /// <returns></returns>
        // GET: api/v1/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("HttpGet CustomersController.Get called.");

            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customersDto);
        }

        // GET api/v1/<CustomersController>/5
        /// <summary>
        /// Get a specific customer by ID
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

            _logger.LogInformation("HttpGet CustomersController.Get.id called.");

            var customer = await _unitOfWork.CustomerRepository.GetByIdentiferAsync(id.Value);

            if (customer == null)
            {
                return NotFound(new ErrorResponse
                {
                    ErrorDescription = $"{id} is not found or does not exist"
                });
            }
            var customerDto = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDto);
        }

        // GET api/v1/<CustomersController>/gerald
        /// <summary>
        /// Get a specific customer by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation("HttpGet CustomersController.Get.Name called.");

            var customer = await _unitOfWork.CustomerRepository.GetByIdentiferAsync(name);

            if (customer == null)
            {
                return NotFound(new ErrorResponse
                {
                    ErrorDescription = $"{name} is not found or does not exist"
                });
            }

            var customerDto = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDto);
        }

        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        // POST api/v1/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO customerModel)
        {
            _logger.LogInformation("HttpPost CustomersController.Post called.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.GetModelStateErrors(ModelState.Values));
            }

            var customer = _mapper.Map<Customers>(customerModel);

            await _unitOfWork.CustomerRepository.InsertAsync(customer);

            await _unitOfWork.CommitAsync();

            return Ok(customerModel);
        }
    }
}