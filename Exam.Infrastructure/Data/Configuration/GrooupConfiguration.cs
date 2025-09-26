using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class GrooupConfiguration:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Title).IsRequired().HasMaxLength(60);
        builder.Property(s => s.Description).HasMaxLength(60).IsRequired();
    }
}