using BACK.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.IL.Repository.EF.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NewId()");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(e => e.BirthDate)
                .HasColumnType("date");

            builder.Property(e => e.ID)
                .HasMaxLength(9);

            builder.Property(e => e.Gender)
                .HasMaxLength(1);

            builder.Property(e => e.CreateDate)
                .IsRequired()
                .HasColumnType("datetime");

            // Propiedades Navegacion
        }
    }
}
