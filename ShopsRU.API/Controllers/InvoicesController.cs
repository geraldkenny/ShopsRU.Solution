using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopRU.Core.ModelDTO;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceBillDTO invoiceBillModel)
        {
            // Do calculation

            var discount = _mapper.Map<Invoices>(invoiceBillModel);
            await _unitOfWork.InvoiceRepository.InsertAsync(discount);

            return Ok(discount);
        }
    }
}