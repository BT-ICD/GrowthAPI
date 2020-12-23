using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new subject detail
    /// </summary>
    public class SubjectDTOAdd
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, ErrorMessage ="Name length cannot be more than 100 characters")]
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
