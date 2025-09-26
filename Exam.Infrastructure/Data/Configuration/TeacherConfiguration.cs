using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class TeacherConfiguration:IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.FirstName).HasMaxLength(60);
        builder.Property(s => s.LastName).HasMaxLength(60);
    }
    
}