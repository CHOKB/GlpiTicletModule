using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ASP.NET.CORE.Controllers
{
    public class MainController : Controller
    {
        MySqlConnection Connection;

        public MainController()
        {
            Connection = new MySqlConnection("user id=root;password=Roman12356;host=127.0.0.1;database=db_glpi;persist security info=True;SslMode=none;Charset=utf8;");
            Connection.Open();
        }
    }
}