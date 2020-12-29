using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To edit details of particular Chapter
    /// </summary>
    public class ChapterDTODetail: ChapterDTOAdd
    {
        public int ChapterId { get; set; }
        public string SubjectName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
   
}
