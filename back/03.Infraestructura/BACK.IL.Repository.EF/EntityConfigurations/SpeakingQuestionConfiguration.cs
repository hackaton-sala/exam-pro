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
    public class SpeakingQuestionConfiguration : IEntityTypeConfiguration<SpeakingQuestion>
    {
        public void Configure(EntityTypeBuilder<SpeakingQuestion> builder)
        {
            builder.ToTable("SpeakingQuestions");

            builder.HasKey(e => e.SpeakingQuestionId);

            
            builder.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.TextAnswer)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(e => e.AudioAnswer)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Feedback)
                .HasMaxLength(500);

            

           
               

            
        }
    }
}
