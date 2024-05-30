using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;
using EconoTrack.Domain.Debts;
using EconoTrack.Domain.Installments;
using Microsoft.EntityFrameworkCore;

namespace EconoTrack.Infra
{
    public class EconoTrackContext : DbContext, IUnitOfWork
    {
        public DbSet<Debit> Debts { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public EconoTrackContext(DbContextOptions<EconoTrackContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EconoTrackContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
