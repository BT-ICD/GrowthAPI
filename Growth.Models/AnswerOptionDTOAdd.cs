using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new choice of as answer for a particular question
    /// </summary>
    public class AnswerOptionDTOAdd
    {
        public string HtmlText { get; set; }
        public string PlainText { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
