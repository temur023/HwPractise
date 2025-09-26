using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class ClassroomConfiguration:IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.RoomNumber).IsRequired();
        builder.Property(s => s.Capacity).IsRequired();
    }
    
}