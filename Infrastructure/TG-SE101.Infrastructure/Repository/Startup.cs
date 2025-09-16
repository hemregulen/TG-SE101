using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TG_SE101.Domain;
using TG_SE101.Infrastructure.Product;
using TG_SE101.Infrastructure.Repository.Category;
using TG_SE101.Infrastructure.Repository.Order;
using TG_SE101.Infrastructure.Repository.OrderItem;
using TG_SE101.Infrastructure.Repository.UnitOfWork;
using TG_SE101.Infrastructure.Repository.User;
using TG_SE101.Infrastructure.Repository.Waybill;
namespace TG_SE101.Infrastructure.Repository
{
    public static class Startup
    {
        public static void AddRepositoryies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWaybillRepository,WaybillRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
