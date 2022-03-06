using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmpRegCon
{
    public class Employer
    {
        // public int EmpId { get; set; }
        public string EmpNameSname { get; set; }
        public int Age { get; set; }
        public DateTime EntryTime { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

    }
}
