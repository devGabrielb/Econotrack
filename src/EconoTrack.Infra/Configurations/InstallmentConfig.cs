using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Installments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EconoTrack.Infra.Configurations
{
    public class InstallmentConfig : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            builder.ToTable("Installments");

            builder.HasKey(installment => installment.Id);

            builder.Property(installment => installment.InstallmentPrice).IsRequired();
            builder.Property(installment => installment.IsPaid).IsRequired()
                .HasMaxLength(500);
            builder.Property(installment => installment.DueDate).IsRequired();
            builder.Property(installment => installment.CreatedAt).IsRequired();
            builder.Property(installment => installment.UpdatedAt).IsRequired();

        }
    }
}
