using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    public class AssignmentDocumentDTOEdit:AssignmentDocumentDTOAdd
    {
        public int AssignmentDocumentId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
