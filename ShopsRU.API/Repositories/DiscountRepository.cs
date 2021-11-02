using ShopsRU.API.Persistance;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly CoreApplicationDbContext _context;

        public DiscountRepository(CoreApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Discounts>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Discounts> GetByTypeAsync(int discountType)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Discounts discount)
        {
            throw new NotImplementedException();
        }
    }
}