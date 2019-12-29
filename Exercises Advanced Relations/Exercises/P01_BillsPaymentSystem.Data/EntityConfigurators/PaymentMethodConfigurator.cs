using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfigurators
{
    public class PaymentMethodConfigurator : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasIndex(pm => new { pm.UserId,pm.BankAccountId,pm.CreditCardId})
                .IsUnique();

            builder
                .HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder
                .HasOne(pm => pm.CreditCard)
                .WithOne(u => u.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder
               .HasOne(pm => pm.BankAccount)
               .WithOne(u => u.PaymentMethod)
               .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(false);
        }
    }
}
