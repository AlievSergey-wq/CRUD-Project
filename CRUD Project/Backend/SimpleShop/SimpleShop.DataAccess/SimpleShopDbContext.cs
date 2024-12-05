using Microsoft.EntityFrameworkCore;
using SimpleShop.DataAccess.Entities;
using System.Collections.Generic;
namespace SimpleShop.DataAccess
{
    public class SimpleShopDBContext : DbContext
    {
        public SimpleShopDBContext(DbContextOptions<SimpleShopDBContext> options)
            : base(options)
        {

        }
        public DbSet<ItemEntity> Items { get; set; }
    }
}
