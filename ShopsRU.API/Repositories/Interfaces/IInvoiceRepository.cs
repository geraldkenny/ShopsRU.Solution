using ShopsRU.Entities;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Inserts <paramref name="invoice"/> into the <see cref="Invoices"/>
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        Task InsertAsync(Invoices invoice);
    }
}