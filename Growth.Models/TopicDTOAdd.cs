using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new topic details
    /// </summary>
    public class TopicDTOAdd
    {
        public int TopicSrNo { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public int ChapterId { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
