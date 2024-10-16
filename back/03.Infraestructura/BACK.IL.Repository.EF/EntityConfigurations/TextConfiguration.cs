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
    
    public class TextConfiguration : IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.ToTable("Texts");

            builder.HasKey(e => e.TextId);

            /*
            builder.Property(e => e.UserId)
               .IsRequired()
               .HasMaxLength(50);
            */
            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(20);

            
            
           /* builder.Property(e => e.Exams)
                .HasMaxLength(200);*/
            

            // Propiedades Navegacion
        }
    }
}
