using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DBConnect
    {
        public SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-8M2NJ75\SQLEXPRESS;Initial Catalog=QUANLYKFC;User ID=sa;Password=123456");

    }
}
