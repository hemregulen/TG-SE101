using TG_SE101.Domain;
using TG_SE101.Domain.Model;

namespace TG_SE101.Infrastructure
{
    public static class DbInitializer
    {
        public static void Seed(ECommerceDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.Add(
                    new Category 
                    {
                        Name = "Genel" 
                    });
                context.SaveChanges();
            }
            if (!context.Product.Any())
            {
                var category=context.Category.FirstOrDefault();
                for (int i = 0; i < 10; i++)
                {
                    context.Product.Add(
                        new Domain.Model.Product
                        { 
                            Name = "Ürün "+i,
                            Price=100M,
                            Stock=i*10,
                            CategoryId= category.Id 
                        });
                }
                context.SaveChanges();
            }
            if (!context.User.Any())
            {
                context.User.Add(
                    new User 
                    {
                        Email="h.emregulen@gmail.com",
                        Phone="5316215565",
                        FirstName="Hüseyin Emre",
                        LastName="Gülen",
                        Password="1234",
                        Username="hemregulen" 
                    });
                context.SaveChanges();
            }
        }
    }
}
