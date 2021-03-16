using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate list of questions with subject and chapter
    /// </summary>
    public class QuestionDTOList
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string HtmlText { get; set; }
        public int QueTypeId { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
