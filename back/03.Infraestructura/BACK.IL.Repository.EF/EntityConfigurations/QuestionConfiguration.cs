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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(e => e.QuestionId);

            builder.Property(e => e.IdExam)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.TextQuestion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CorrectAnswer)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.UserAnswer)
                .HasMaxLength(200);

            builder.Property(e => e.IsCorrect)
                .HasMaxLength(20);
            
            builder.Property(e => e.Feedback)
                .HasMaxLength(200);

            builder.Property(e => e.Score)
                .HasMaxLength(20);


            
        }
    }
}
