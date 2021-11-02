using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopRU.Core.Helpers;
using ShopRU.Core.ModelDTO;
using ShopsRU.API.BL.Interfaces;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ShopsRU.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class InvoicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceLogic _invoiceLogic;
        private readonly ILogger<InvoicesController> _logger;

        //TODO
        // Add controller handlers
        public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper, IInvoiceLogic discountLogic, ILogger<InvoicesController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _invoiceLogic = discountLogic;
            _logger = logger;
        }

        // POST api/v1/<InvoicesController
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceBillRequestDTO invoiceBillModel)
        {
            _logger.LogInformation("HttpPost InvoicesController called.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.GetModelStateErrors(ModelState.Values));
            }

            InvoiceBillDTO invoiceBill = _mapper.Map<InvoiceBillDTO>(invoiceBillModel);
            invoiceBill.Customer = await _unitOfWork.CustomerRepository.GetByIdentiferAsync(invoiceBillModel.CustomerName);

            // Do invoice discount calculation
            var invoiceAmount = await _invoiceLogic.CalculateInvoiceDiscountAsync(invoiceBill);

            var invoice = _mapper.Map<Invoices>(invoiceBill);

            await _unitOfWork.InvoiceRepository.InsertAsync(invoice);
            await _unitOfWork.CommitAsync();

            return Ok(invoiceAmount);
        }
    }
}