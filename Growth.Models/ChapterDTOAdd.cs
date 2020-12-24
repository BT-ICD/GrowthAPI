using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    public class ChapterDTOAdd
    {
        
        public int ChapterSrNo { get; set; }
        
        [Required(ErrorMessage ="Chapter Name is required")]
        [StringLength(200,ErrorMessage ="Length of Name must within 5 and 200", MinimumLength =5)]
        public string Name { get; set; }
       
        public int SubjectId { get; set; }

        [StringLength(4000, ErrorMessage = "Too much content, maximum length of notes is {0}")]
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
