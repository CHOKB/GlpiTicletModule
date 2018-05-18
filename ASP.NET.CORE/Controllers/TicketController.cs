using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ASP.NET.CORE.Models.Tables;

namespace ASP.NET.CORE.Controllers
{
    public class TicketController : MainController
    {     
        public IActionResult Add([FromBody] Tuple<Ticket, Item, User, User> container)
        {       
            int ComputerId;
            using (MySqlCommand GetComputerId = new MySqlCommand(container.Item2.SQLQueryGetId(), Connection))
            {
                MySqlDataReader reader = GetComputerId.ExecuteReader();
                if (reader.Read())
                    ComputerId = (int)reader.GetValue(0);
                else return BadRequest("Invalid getting computer id");
            }

            int TicketId;
            using (MySqlCommand GetIdTicket = new MySqlCommand(container.Item1.SQLQueryGetId(), Connection))
            {
                MySqlDataReader reader = GetIdTicket.ExecuteReader();
                if (reader.Read())
                    TicketId = (int)reader.GetValue(0);
                else return BadRequest("Invalid getting ticket id");
            }

            int UserApplicantId;
            using (MySqlCommand GetUserId = new MySqlCommand(container.Item3.SQLQueryGetId(), Connection))
            {
                MySqlDataReader reader = GetUserId.ExecuteReader();
                if (reader.Read())
                    UserApplicantId = (int)reader.GetValue(0);
                else return BadRequest("Invalid gettting applicant id");
            }

            int UserRecipientId;
            using (MySqlCommand GetUserId = new MySqlCommand(container.Item4.SQLQueryGetId(), Connection))
            {
                MySqlDataReader reader = GetUserId.ExecuteReader();
                if (reader.Read())
                    UserRecipientId = (int)reader.GetValue(0);
                else return BadRequest("Invalid gettting applicant id");
            }

            using (MySqlCommand CreateTicket = new MySqlCommand(container.Item1.SQLQueryCreate(), Connection))
            {
                if (CreateTicket.ExecuteNonQuery() == 0) return BadRequest("Error create ticket");
            }

            using (MySqlCommand CreateTicketItems = new MySqlCommand(TicketItem.SQLQueryInsert("Computer", ComputerId, TicketId), Connection))
            {
                if (CreateTicketItems.ExecuteNonQuery() == 0) BadRequest("Error create note ticket-items");
            }     

            MySqlCommand CreateTicketUserApplicant = new MySqlCommand(UsersTickets.SQLQueryInsert(UserType.Applicant, TicketId, UserApplicantId), Connection);
            if (CreateTicketUserApplicant.ExecuteNonQuery() == 0) BadRequest("Error create note applicant-ticket");

            MySqlCommand CreateTicketUserRecipient = new MySqlCommand(UsersTickets.SQLQueryInsert(UserType.Recipient, TicketId, UserRecipientId), Connection);
            if (CreateTicketUserRecipient.ExecuteNonQuery() == 0) BadRequest("Error create note recipient-ticket");

            return Ok();
        }
    }
}
