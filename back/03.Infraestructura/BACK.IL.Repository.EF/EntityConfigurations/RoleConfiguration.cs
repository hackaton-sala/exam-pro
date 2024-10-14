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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.RoleId);


            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.RoleType)
                .IsRequired()
                .HasMaxLength(2);

            // Propiedades Navegacion
        }
    }
}
