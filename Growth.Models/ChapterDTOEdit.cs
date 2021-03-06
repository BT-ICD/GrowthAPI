﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To edit details of existing chapter
    /// </summary>
    public class ChapterDTOEdit: ChapterDTOAdd
    {
        public int ChapterId { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
