using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_SE101.Domain
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ECommerceDbContext>();
            var connectionString = "Server=.;Database=ECommerceDb;TrustServerCertificate=True;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new ECommerceDbContext(builder.Options);
        }
    }
}
