using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class SubjectConfiguration:IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Description).HasMaxLength(60);
        builder.Property(s => s.Name).HasMaxLength(60);
    }
}