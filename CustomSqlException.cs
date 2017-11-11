using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EasySQL
{
    public class CustomSqlException: Exception
    {
        public CustomSqlException()
        {
        }

        public CustomSqlException(string message, SqlException innerException)
            : base(message, innerException)
        {
        }
    }
}
