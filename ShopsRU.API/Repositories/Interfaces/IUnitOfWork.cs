using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IDiscountRepository DiscountRepository { get; }

        Task CommitAsync();
    }
}