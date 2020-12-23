using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface ISubject
    {
        public List<SubjectListDTO> GetList();
    }
}
