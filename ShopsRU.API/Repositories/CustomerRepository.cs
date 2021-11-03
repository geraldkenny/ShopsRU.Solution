using Microsoft.EntityFrameworkCore;
using ShopsRU.API.Persistance;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CoreApplicationDbContext _context;

        public CustomerRepository(CoreApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the list of all customers
        /// </summary>
        /// <returns>A <see cref="List{Customers}"/></returns>
        public async Task<List<Customers>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        /// <summary>
        /// Gets a <see cref="Customers"/> object using <paramref name="customerId"/>
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>A <see cref="Customers"/> object</returns>
        public async Task<Customers> GetByIdentiferAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        /// <summary>
        /// Gets a <see cref="Customers"/> object using <paramref name="customerName"/>
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns>A <see cref="Customers"/> object</returns>
        public async Task<Customers> GetByIdentiferAsync(string customerName)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Name == customerName);
        }

        /// <summary>
        /// Inserts <paramref name="customer"/> into the <see cref="Customers"/>
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task InsertAsync(Customers customer)
        {
            await _context.AddAsync(customer);
        }
    }
}