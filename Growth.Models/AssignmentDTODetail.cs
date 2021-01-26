﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    public class AssignmentDTODetail
    {
        public int AssignmentId { get; set; }
        public string QueTitle { get; set; }
        public string QueText { get; set; }
        public string QueHtml { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
