using Microsoft.EntityFrameworkCore;
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
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discounts> GetByTypeAsync(UserType userType)
        {
            return await _context.Discounts.FirstOrDefaultAsync(x => x.UserType == userType);
        }

        public async Task InsertAsync(Discounts discount)
        {
            await _context.AddAsync(discount);
        }
    }
}