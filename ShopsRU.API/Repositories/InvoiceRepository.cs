using ShopsRU.API.Persistance;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CoreApplicationDbContext _context;

        public InvoiceRepository(CoreApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Inserts <paramref name="invoice"/> into the <see cref="Invoices"/>
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public async Task InsertAsync(Invoices invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }
    }
}