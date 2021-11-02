using ShopsRU.Entities;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task InsertAsync(Invoices invoice);
    }
}