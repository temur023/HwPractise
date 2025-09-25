namespace Exam.Domain.Entities;

public class Classroom
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public ICollection<TimeTable> TimeTables { get; set; }
}