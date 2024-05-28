using Microsoft.AspNetCore.Identity;
using System.Reflection;
using TechGamer.Application.Interfaces;
using TechGamer.Application.Services;
using TechGamer.Domain.Interfaces;
using TechGamer.Domain.Shared.Transaction;
using TechGamer.Infra.Data.Context;
using TechGamer.Infra.Data.Repositories;
using TechGamer.Infra.Data.UoW;
using TechGamer.Infra.Identity.Data;
using TechGamer.Infra.Identity.Services;

namespace TechGamer.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TechGamerDbContext>();
            services.AddScoped<IdentityDataContext>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IBasketAppService, BasketAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVoucherAppService, VoucherAppService>();
        }
    }
}
