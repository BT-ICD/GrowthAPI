using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
 /// <summary>
 /// To add new question with possible answer to provide as a choice
 /// </summary>
    public class QuestionDTOAdd
    {
        public string Title { get; set; }
        public string HtmlText { get; set; }
        public string PlainText { get; set; }

        public int ChapterId { get; set; }

        public int QueTypeId { get; set; }
        public string Notes { get; set; }
        public List<AnswerOptionDTOAdd> AnswerOptions{ get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
