using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.CORE.Models.SQL
{
    public class GlpiContext
    {
        string ConnectionString;

        public GlpiContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public MySqlConnection GetConnection() => new MySqlConnection(ConnectionString);
    }
}
