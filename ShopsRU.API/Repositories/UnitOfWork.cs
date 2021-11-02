using Microsoft.EntityFrameworkCore;
using ShopsRU.API.Persistance;
using ShopsRU.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ICustomerRepository CustomerRepository { get; private set; }
        public IInvoiceRepository InvoiceRepository { get; private set; }
        public IDiscountRepository DiscountRepository { get; private set; }

        private readonly CoreApplicationDbContext _context;

        public UnitOfWork(CoreApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            CustomerRepository = new CustomerRepository(_context);
            InvoiceRepository = new InvoiceRepository(_context);
            DiscountRepository = new DiscountRepository(_context);
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}