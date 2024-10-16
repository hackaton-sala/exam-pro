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
    
    public class GrammarExamConfiguration : IEntityTypeConfiguration<GrammarExam>
    {
        public void Configure(EntityTypeBuilder<GrammarExam> builder)
        {
            builder.ToTable("GrammarExams");

            builder.HasKey(e => e.IdExam);

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

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(20);


            /*
            builder.Property(e => e.Questions)
                .IsRequired()
                .HasMaxLength(20);
            */

            // Propiedades Navegacion
        }
    }
}
