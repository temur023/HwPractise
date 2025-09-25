using Exam.Application.Abstractions;
using Exam.Application.Services;
using Exam.Infrastryctyre.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Infrastryctyre;

public static class RegisterDependencies
{
    public static IServiceCollection RegisterInfrasctructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IStudentServices, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IExamResultsService,ExamResultsService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IGroupServices, GroupService>();
        services.AddScoped<ISiService,SiService>();
        services.AddScoped<ISgService,SgService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<ITTService,TTService>();
        services.AddScoped<IClassroomServices, ClassroomService>();
        services.AddScoped<IAttendanceService,AttendanceService>();
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<IDbContext,DataContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}