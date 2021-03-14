using Automat.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Infrastructure
{
    public class AutomatDbContext : DbContext
    {
        public AutomatDbContext(DbContextOptions<AutomatDbContext> options) : base(options)
        {
        }

        public DbSet<CampaingEntity> Campaings { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
    }

}
