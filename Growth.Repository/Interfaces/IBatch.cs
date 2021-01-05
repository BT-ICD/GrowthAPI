using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IBatch
    {
        List<BatchDTOList> GetList();
        BatchDTODetail GetById(int batchId);
        List<BatchDTOLookup> Lookup();
    }
}
