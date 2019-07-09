using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.Property(a => a.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();


            builder
                  .HasOne(a => a.Client)
                  .WithMany(cl => cl.Accounts)
                  .HasForeignKey(a => a.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
