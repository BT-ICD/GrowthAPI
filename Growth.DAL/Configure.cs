using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.DAL
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddSingleton<AppConnectionString>(new AppConnectionString(connectionString));
        }
    }
}
