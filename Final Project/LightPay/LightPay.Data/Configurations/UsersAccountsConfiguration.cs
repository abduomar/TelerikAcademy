using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Data.Configurations
{
    public class UsersAccountsConfiguration : IEntityTypeConfiguration<UsersAccounts>
    {
        public void Configure(EntityTypeBuilder<UsersAccounts> builder)
        {
            builder
                .HasKey(ua => new { ua.AccountId, ua.UserId });

            builder
               .HasOne(ua => ua.Account)
               .WithMany(a => a.UsersAccounts)
               .HasForeignKey(ua => ua.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(ua => ua.User)
              .WithMany(lpu => lpu.UsersAccounts)
              .HasForeignKey(ua => ua.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
