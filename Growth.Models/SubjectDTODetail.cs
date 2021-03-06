﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate details of particular subject
    /// </summary>
    public class SubjectDTODetail: SubjectDTOAdd
    {
        public int SubjectId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
