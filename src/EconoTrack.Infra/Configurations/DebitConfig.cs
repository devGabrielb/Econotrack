using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Categories;
using EconoTrack.Domain.Debts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EconoTrack.Infra.Configurations
{
    public class DebtConfig : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("Debts");

            builder.HasKey(debit => debit.Id);

            builder.Property(debit => debit.Title)
                .HasMaxLength(200);
            builder.Property(debit => debit.Description).IsRequired()
                .HasMaxLength(500);
            builder.Property(debit => debit.CategoryId).IsRequired();
            builder.Property(debit => debit.CreatedAt).IsRequired();
            builder.Property(debit => debit.UpdatedAt).IsRequired();
            builder.Property(debit => debit.FrequencyRecurrence)
            .HasConversion(
            v => v.ToString(),
            v => (FrequencyRecurrence)Enum.Parse(typeof(FrequencyRecurrence), v));

            builder.Property(debit => debit.IsRecurrent);
            builder.Property(debit => debit.TotalPrice).IsRequired();

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(debit => debit.CategoryId);

            builder.HasMany(debit => debit.Installments)
                .WithOne()
                .HasForeignKey(installment => installment.DebitId);
        }
    }
}
