using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmpRegCon
{
    class DataAccessLayer
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=ALICO\MSSQL;Initial Catalog=Employed;Integrated Security=True");
        public static SqlCommand com;
        public static SqlDataReader reader;
       
    }
}