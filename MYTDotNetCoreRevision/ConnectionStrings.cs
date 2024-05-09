using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MYTDotNetCoreRevision
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "AARONDGRANT\\MSSQL",
            InitialCatalog = "MYTDotNetCoreRevision",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };    }
}
