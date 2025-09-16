using MediatR;
using Microsoft.EntityFrameworkCore;
using TG_SE101.Application.Behavior;
using TG_SE101.Application.Handler.Product;
using TG_SE101.Domain;
using TG_SE101.Infrastructure;
using TG_SE101.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
Startup.AddRepositoryies(builder.Services, builder.Configuration);                                                                          
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommandHandler).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
    DbInitializer.Seed(context);
}
app.Run();
