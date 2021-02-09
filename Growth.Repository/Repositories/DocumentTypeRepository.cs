using Dapper;
using Growth.DAL;
using Growth.Models;
using Growth.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Growth.Repository.Repositories
{
    public class DocumentTypeRepository:IDocumentType
    {
        private readonly AppConnectionString appConnectionString;
        public DocumentTypeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public List<DocumentTypeDTOLookup> Lookup()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DocumentTypeDTOLookup>("DocumentType_Lookup", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
