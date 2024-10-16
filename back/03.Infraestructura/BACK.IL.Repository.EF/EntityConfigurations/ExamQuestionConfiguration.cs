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
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestion");

            builder.HasKey(e => e.QuestionId);

            builder.Property(e => e.GramaticalExamId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CorrectAnswer)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.UserAnswer)
                .HasMaxLength(200);

            builder.Property(e => e.IsCorrect)
                .HasMaxLength(20);

            
        }
    }
}
