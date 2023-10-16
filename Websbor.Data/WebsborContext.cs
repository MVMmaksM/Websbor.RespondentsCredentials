using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.Data
{
    public class WebsborContext : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<CatalogWebsborAsgs> Catalog { get; set; }

        public WebsborContext(DbContextOptions<WebsborContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
