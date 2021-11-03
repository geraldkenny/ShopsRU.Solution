using ShopRU.Core.ModelDTO;
using ShopsRU.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get the list of all customers
        /// </summary>
        /// <returns>A <see cref="List{Customers}"/></returns>
        Task<List<Customers>> GetAllAsync();

        /// <summary>
        /// Gets a <see cref="Customers"/> object using <paramref name="customerId"/>
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>A <see cref="Customers"/> object</returns>
        Task<Customers> GetByIdentiferAsync(int customerId);

        /// <summary>
        /// Gets a <see cref="Customers"/> object using <paramref name="customerName"/>
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns>A <see cref="Customers"/> object</returns>
        Task<Customers> GetByIdentiferAsync(string customerName);

        /// <summary>
        /// Inserts <paramref name="customer"/> into the <see cref="Customers"/>
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task InsertAsync(Customers customers);
    }
}