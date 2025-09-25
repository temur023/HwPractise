using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Abstractions;

public interface IDbContext
{
    DbSet<Student> Students { get; set; }
    DbSet<Teacher> Teachers{ get; set; }
    DbSet<Classroom> Classrooms { get; set; }
    DbSet<Domain.Entities.Exam> Exams { get; set; }
    DbSet<ExamResult> ExamResults { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<StudentGroup> StudentGroups { get; set; }
    DbSet<Subject> Subjects{ get; set; }
    DbSet<TimeTable> TimeTables{ get; set; }
    DbSet<Attendance> Attendances { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}