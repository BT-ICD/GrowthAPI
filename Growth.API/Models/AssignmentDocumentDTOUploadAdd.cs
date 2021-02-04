using Growth.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.Models
{
    public class AssignmentDocumentDTOUploadAdd
    {
        public int AssignmentId { get; set; }

        public int DocumentTypeId { get; set; }
        public string Notes { get; set; }
        public IFormFile file { get; set; }
    }
}
