using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class ExamResultConfiguration:IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Grade).IsRequired();
        builder.Property(s => s.Score).IsRequired();
    }
}