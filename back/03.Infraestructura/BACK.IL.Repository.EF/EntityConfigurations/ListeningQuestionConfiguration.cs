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
    public class ListeningQuestionConfiguration : IEntityTypeConfiguration<ListeningQuestion>
    {
        public void Configure(EntityTypeBuilder<ListeningQuestion> builder)
        {
            builder.ToTable("ListeningQuestions");

            builder.HasKey(e => e.ListeningQuestionId);

            builder.Property(e => e.AudioUrl)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Options)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CorrectAnswer)
                .HasMaxLength(200);

            builder.Property(e => e.UserAnswer)
                .IsRequired()
                .HasMaxLength(300);

           
               

            
        }
    }
}
