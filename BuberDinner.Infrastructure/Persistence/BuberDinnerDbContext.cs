using BuberDinner.Domain.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder            
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
