using ShopRU.Core.ModelDTO;
using ShopsRU.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetAllAsync();

        Task<Customers> GetByIdentiferAsync(int customerId);

        Task<Customers> GetByIdentiferAsync(string customerName);

        Task InsertAsync(Customers customers);
    }
}