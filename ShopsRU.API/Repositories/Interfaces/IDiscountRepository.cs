using ShopsRU.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<List<Discounts>> GetAllAsync();

        Task<Discounts> GetByTypeAsync(UserType userType);

        Task InsertAsync(Discounts discount);
    }
}