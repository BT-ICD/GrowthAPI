using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get list of documents related to particular assignment
    /// </summary>
    public class AssignmentDocumentDTOList
    {
        public int AssignmentDocumentId { get; set; }
        public int AssignmentId { get; set; }
        public string QueTitle { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string ActualFileName { get; set; }
        public string StoreAsFileName { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
