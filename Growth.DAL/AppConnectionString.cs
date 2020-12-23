using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.DAL
{
    /// <summary>
    /// To get or set connection string to connect with Database
    /// </summary>
    public class AppConnectionString
    {
        public string ConnectionString { get; }
        public AppConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
