using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastryctyre.Data.Configuration;

public class StudentConfiguration:IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.FirstName).HasMaxLength(60);
        builder.Property(s => s.LastName).HasMaxLength(60);
    }
}

public class TeacherConfiguration:IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.FirstName).HasMaxLength(60);
        builder.Property(s => s.LastName).HasMaxLength(60);
    }
    
}
public class ClassroomConfiguration:IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.RoomNumber).IsRequired();
        builder.Property(s => s.Capacity).IsRequired();
    }
    
}

public class ExamResultConfiguration:IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Grade).IsRequired();
        builder.Property(s => s.Score).IsRequired();
    }
}
public class SubjectConfiguration:IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Description).HasMaxLength(60);
        builder.Property(s => s.Name).HasMaxLength(60);
    }
}

public class GrooupConfiguration:IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        //Key we don't need because it automatically links
        builder.Property(s => s.Title).IsRequired().HasMaxLength(60);
        builder.Property(s => s.Description).HasMaxLength(60).IsRequired();
    }
}