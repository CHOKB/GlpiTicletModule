using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.CORE.Models.Tables
{
    public class Item
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string OtherSerial { get; set; }

        public string SQLQueryGetId() => 
            $"SELECT Id " +
            $"FROM glpi_{Type} " +
            $"WHERE otherserial='{OtherSerial}'";
    }
}