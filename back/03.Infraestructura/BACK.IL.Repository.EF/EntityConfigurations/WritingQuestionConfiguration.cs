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
    public class WritingQuestionConfiguration : IEntityTypeConfiguration<WritingQuestion>
    {
        public void Configure(EntityTypeBuilder<WritingQuestion> builder)
        {
            builder.ToTable("WritingQuestions");

            builder.HasKey(e => e.WritingQuestionId);

            
            builder.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.UserAnswer)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(e => e.Feedback)
                .IsRequired()
                .HasMaxLength(200);

           
               

            
        }
    }
}
