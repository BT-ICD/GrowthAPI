using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models.Student
{
    /// <summary>
    /// To manipulate dashboard content for student role
    /// </summary>
    public class DashboardDTOStudent
    {
        public List<DashboardSessionSummary> SessionSummary { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class DashboardSessionSummary
    {
        public string SessionType { get; set; }
        public int NumberOfSessions { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
