using Growth.Repository.Interfaces;
using Growth.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            DAL.Configure.ConfigureServices(services, connectionString);
            services.AddScoped<ISubject, SubjectRepository>();
            services.AddScoped<IChapter, ChapterRepository>();
            services.AddScoped<ITopic, TopicRepository>();
            services.AddScoped<IBatch, BatchRepository>();
            services.AddScoped<ISchedule, ScheduleRepository>();
            services.AddScoped<IAttendance, AttendanceRepository>();
            services.AddScoped<IDashboard, DashboardRepository>();
            services.AddScoped<IAssignment, AssignmentRepository>();
            services.AddScoped<IAssignmentDocument, AssignmentDocumentRepository>();
            
        }
    }
}
