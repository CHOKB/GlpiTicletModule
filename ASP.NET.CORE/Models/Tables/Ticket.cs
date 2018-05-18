using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.CORE.Models.Tables
{
    public enum TicketPriority
    {
        VeryLow = 1, Low, Medium, High, VeryHigh
    }

    public enum TicketStatus
    {
        New = 1, Appointed, IsPlanned, Expectation, Resolved, Closed
    }

    public enum TicketType
    {
        Incident = 1, Query
    }

    public class Ticket
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type;
        public int UserId;

        public Ticket()
        {
            Name     = Content = Date = string.Empty;
            Priority = TicketPriority.Medium;
            Status   = TicketStatus.New;
            Type     = TicketType.Incident;
            UserId   = 0;
        }

        public Ticket(string name, string content, string date, TicketPriority priority, TicketStatus status, TicketType type, int userid)
        {
            Name     = name;
            Content  = content;
            Date     = date;
            Priority = priority;
            Status   = status;
            Type     = type;
            UserId   = userid;
        }

        public string SQLQueryCreate() => $"INSERT glpi_tickets(name, content,date,priority,`status`,`type`," +
                $"users_id_recipient,users_id_lastupdater,requesttypes_id,urgency,impact,itilcategories_id,solutiontypes_id,global_validation," +
                $"slas_ttr_id,slas_tto_id,ttr_slalevels_id,sla_waiting_duration,ola_waiting_duration,olas_tto_id,olas_ttr_id," +
                $"ttr_olalevels_id,waiting_duration,close_delay_stat,solve_delay_stat,takeintoaccount_delay_stat,actiontime," +
                $"is_deleted,locations_id,validation_percent,entities_id)" +
                $"VALUES ('{Name}', '{Content}', '{Date}', {(int)Priority}, {(int)Status}, {(int)Type}," +
                $"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";

        public string SQLQueryGetId() => $"SELECT Id " +
            $"FROM glpi_tickets " +
            $"WHERE content = '{Content}'";
    }

}