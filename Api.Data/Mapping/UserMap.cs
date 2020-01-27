using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Email)
                .IsUnique();
            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(60); ;
        }
    }
}
