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
    
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(e => e.ExamId);

            /*
            builder.Property(e => e.UserId)
               .IsRequired()
               .HasMaxLength(50);
            */

            builder.Property(e => e.StartDate)
                .HasColumnType("date");

            builder.Property(e => e.FinishDate)
                .HasColumnType("date");

            builder.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Part)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(e => e.User)
                  .WithMany(u => u.Exams)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            /* builder.Property(e => e.Questions)
                 .IsRequired()
                 .HasMaxLength(200);
             */

            // Propiedades Navegacion
        }
    }
}
