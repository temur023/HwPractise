using Exam.Application.Abstractions;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Infrastryctyre.Data;

public class DataContext:DbContext,IDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Domain.Entities.Exam> Exams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TimeTable> TimeTables { get; set; }
    public DbSet<Attendance> Attendances { get; set; }

    public DataContext(DbContextOptions<DataContext> options):base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}