using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new assignment
    /// </summary>
   public class AssignmentDTOAdd
    {
        [Required(ErrorMessage ="Question Title is required")]
        public string QueTitle { get; set; }
        public string QueHtml { get; set; }
        public string Notes { get; set; }
        public int SubjectId { get; set; }
        public bool IsFileSubmitRequired { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
