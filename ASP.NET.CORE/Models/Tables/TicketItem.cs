using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.CORE.Models.Tables
{
    public static class TicketItem
    {
        public static string SQLQueryInsert(string Type, int ItemId, int TicketId) =>
            $"INSERT glpi_items_tickets (itemtype,items_id,tickets_id)" +
            $"VALUES ('{Type}', {ItemId}, {TicketId})";
    }
}