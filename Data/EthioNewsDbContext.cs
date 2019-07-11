using EthioNews.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthioNews.Data
{
    public class EthioNewsDbContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EthioNewsDbContext(DbContextOptions options)
            : base(options)
        {
          
        }
    }
}
