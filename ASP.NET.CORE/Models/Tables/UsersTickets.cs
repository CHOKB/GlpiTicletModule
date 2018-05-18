using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.CORE.Models.Tables
{
    public static class UsersTickets
    {
        public static string SQLQueryInsert(UserType type, int TicketId, int UserId) =>
            $"INSERT glpi_tickets_users (tickets_id, users_id, `type`, use_notification) " +
            $"VALUES({TicketId},{UserId},{(int)type},1)";
    }
}