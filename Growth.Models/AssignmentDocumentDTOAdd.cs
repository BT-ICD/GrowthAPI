using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new document record for a particular assignment
    /// </summary>
    public class AssignmentDocumentDTOAdd
    {
        public int AssignmentId { get; set; }
      
        public int DocumentTypeId { get; set; }
        public string ActualFileName { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
