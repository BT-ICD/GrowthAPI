using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get key value - pair for document types. List of documents types
    /// </summary>
    public class DocumentTypeDTOLookup
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
