using Microsoft.Extensions.DependencyInjection;
using ShopsRU.API.BL;
using ShopsRU.API.BL.Interfaces;
using ShopsRU.API.Repositories;
using ShopsRU.API.Repositories.Interfaces;

namespace ShopsRU.API
{
    public partial class Startup
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoiceLogic, InvoiceLogic>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}