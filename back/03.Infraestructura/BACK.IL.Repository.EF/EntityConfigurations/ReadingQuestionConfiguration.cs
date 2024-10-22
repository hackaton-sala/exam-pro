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
    public class ReadingQuestionConfiguration : IEntityTypeConfiguration<ReadingQuestion>
    {
        public void Configure(EntityTypeBuilder<ReadingQuestion> builder)
        {
            builder.ToTable("ReadingQuestions");

            builder.HasKey(e => e.ReadingQuestionId);

            builder.Property(e => e.Text)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Options)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CorrectAnswer)
                .HasMaxLength(100);

            builder.Property(e => e.UserAnswer)
                .IsRequired()
                .HasMaxLength(200);

           
               

            
        }
    }
}
