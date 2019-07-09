using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(u => u.Username)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(128)
                .IsRequired();

        }
    }
}
