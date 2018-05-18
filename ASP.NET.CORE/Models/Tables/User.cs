using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.CORE.Models.Tables
{
    public enum UserType
    {
        Applicant = 1, Recipient
    }

    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string SQLQueryGetId() => $"SELECT Id " +
            $"FROM glpi_users " +
            $"WHERE firstname = '{Name}' AND realname = '{Surname}'";
    }
}