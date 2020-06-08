using Microsoft.Extensions.DependencyInjection;
using psl.API.Infrastructure.Lookup;
using psl.API.Features.Widgets;
using Microsoft.AspNetCore.Identity;
using psl.Entity.DataClasses;
using Microsoft.AspNetCore.Http;
using psl.API.Infrastructure.Auth;
using psl.API.Infrastructure.Authentication;
using psl.API.Features.Users;
using psl.API.Features.Accounts;
using psl.API.Features.Carriers;
using psl.API.Features.Dealers;
using psl.API.Features.Orders;
using psl.API.Features.Products;
using psl.API.Features.Routings;

namespace psl.API
{
    public partial class Startup
    {
        public static void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<ITokenProviderService, TokenProviderService>();

            //Accounts
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();

            //Carriers
            services.AddScoped<ICarriersService, CarriersService>();
            services.AddScoped<ICarriersRepository, CarriersRepository>();

            //Dealers
            services.AddScoped<IDealersService, DealersService>();
            services.AddScoped<IDealersRepository, DealersRepository>();

            //Orders
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            //Products
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            //Routings
            services.AddScoped<IRoutingsService, RoutingsService>();
            services.AddScoped<IRoutingsRepository, RoutingsRepository>();

            //Shared
            services.AddScoped<ILookupRepository, LookupRepository>();

            //Users
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            //Widgets
            services.AddScoped<IWidgetsService, WidgetsService>();
            services.AddScoped<IWidgetsRepository, WidgetsRepository>();

            //services.AddScoped<IPasswordHasher<ApplicationUser>, psl.API.Infrastructure.Authentication.HashUtility>();

            services.AddScoped<IAuthRepository, AuthRepository>();

            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
