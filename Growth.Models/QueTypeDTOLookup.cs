using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get list of question types as a look up values
    /// </summary>
    public class QueTypeDTOLookup
    {
        public int QueTypeId { get; set; }
        public string QuestionType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
