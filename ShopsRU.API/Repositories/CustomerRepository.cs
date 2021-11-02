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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CoreApplicationDbContext _context;

        public CustomerRepository(CoreApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customers> GetByIdentiferAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task<Customers> GetByIdentiferAsync(string customerName)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Name == customerName);
        }

        public async Task InsertAsync(Customers customer)
        {
            await _context.AddAsync(customer);
        }
    }
}