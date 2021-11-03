using Microsoft.EntityFrameworkCore;
using ShopsRU.API.Persistance;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System.Collections.Generic;
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

        /// <summary>
        /// Gets all discounts types avaliable
        /// </summary>
        /// <returns>A <see cref="List{Discounts}"/></returns>
        public async Task<List<Discounts>> GetAllAsync()
        {
            return await _context.Discounts.ToListAsync();
        }

        /// <summary>
        /// Get a discount object using <paramref name="userType"/>
        /// </summary>
        /// <param name="userType"></param>
        /// <returns>A <see cref="Discounts"/> object</returns>
        public async Task<Discounts> GetByTypeAsync(UserType userType)
        {
            return await _context.Discounts.FirstOrDefaultAsync(x => x.UserType == userType);
        }

        /// <summary>
        /// Inserts <paramref name="discount"/> into the <see cref="Discounts"/>
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        public async Task InsertAsync(Discounts discount)
        {
            await _context.AddAsync(discount);
        }
    }
}