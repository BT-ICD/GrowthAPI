using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get list of chapters
    /// </summary>
    public class ChapterDTOList
    {
        public int ChapterId { get; set; }
        public int ChapterSrNo { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
}
