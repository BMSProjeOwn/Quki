using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Context
{
    public class ProjeDBZuposDBContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionZuposDB"));


            //optionsBuilder.UseSqlServer("server=94.73.145.8; database=u0556292_Quki; user id=u0556292_Quki; password=ESwm40T1DNey93O;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<RvcMenuItemDef> RvcMenuItemDef { get; set; }
        public DbSet<RvcOptionsRight> RvcOptionsRight { get; set; }
        public DbSet<RvcMenuItemPrice> RvcMenuItemPrice { get; set; }
        public DbSet<MenuItemBarcodeDef> MenuItemBarcodeDef { get; set; }
        public DbSet<SluDef> SluDef { get; set; }
        public DbSet<slu_Rvc_Relation> slu_Rvc_Relation { get; set; }
        
     


    }
}
