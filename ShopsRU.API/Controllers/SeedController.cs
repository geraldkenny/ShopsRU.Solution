using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopRU.Core.Helpers;
using ShopsRU.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SeedController> _logger;

        public SeedController(IUnitOfWork unitOfWork, ILogger<SeedController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("HttpGet SeedController called.");

            var customers = SeedHelper.GetCustomersSeed();
            var discounts = SeedHelper.GetDiscountsSeed();

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    await _unitOfWork.CustomerRepository.InsertAsync(customers[i]);
                    await _unitOfWork.DiscountRepository.InsertAsync(discounts[i]);
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured");

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { ErrorDescription = "Can not insert duplicate of user type in discounts" });
            }

            _logger.LogInformation("HttpGet SeedController Done.");

            return Ok(new { message = "Done seeding" });
        }
    }
}