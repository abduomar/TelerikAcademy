using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.Property(t => t.Ammount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
              .HasOne(t => t.SenderAccount)
              .WithMany(sa => sa.OutgoingTransactions)
              .HasForeignKey(t => t.SenderAccountId)
              .OnDelete(DeleteBehavior.Restrict);


            builder
               .HasOne(t => t.RecieverAccount)
               .WithMany(ra => ra.IncomingTransactions)
               .HasForeignKey(t => t.RecieverAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
