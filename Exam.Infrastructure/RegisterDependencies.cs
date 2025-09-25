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
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<IDbContext,DataContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}