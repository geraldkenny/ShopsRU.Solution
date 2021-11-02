using ShopRU.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.BL.Interfaces
{
    public interface IInvoiceLogic
    {
        decimal CalculateDiscount(InvoiceBillDTO bill);
    }
}