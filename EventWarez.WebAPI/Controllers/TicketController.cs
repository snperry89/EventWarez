using EventWarez.Models.Ticket;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Allows Access to Functions regarding Tickets.
    /// </summary>
    [Authorize]
    public class TicketController : ApiController
    {
        private readonly AttendeeService _attendeeService = new AttendeeService();
        private readonly TicketService _ticketService = new TicketService();
        private TicketService CreateTickService()
        {
            var tickService = new TicketService();
            return tickService;
        }
        /// <summary>
        /// Allows user to add individual tickets to a show object.
        /// </summary>
        /// <param name="model">Takes in all ticket properties and adds them as an object to the database.</param>
        /// <returns>Success Message.</returns>
        [HttpPost]
        public IHttpActionResult AddTicketsToShow(TicketCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.CreateTicket(model))
                return InternalServerError();
            return Ok("Ticket Successfully Added To Show!");
        }
        /// <summary>
        /// Returns a list of all tickets by Show Id
        /// </summary>
        /// <param name="showId">Takes a Show Id in as a URI parameter, and returns all ticket objects attached to that show.</param>
        /// <returns>All tickets associated with Show Id input..</returns>
        [HttpGet]
        public IHttpActionResult GetTicketsByShow(int showId)
        {

            TicketService tickService = new TicketService();
            var ticket = tickService.GetTicketByShow(showId);
            return Ok(ticket);
        }
        /// <summary>
        /// Allows an Attendee to purchase a ticket
        /// </summary>
        /// <param name="ticket">Takes in a Ticket object, defined in the body by Id #, and adds the appropriate Attendee Id to that ticket.</param>
        /// <returns>Success Message.</returns>
        [HttpPut]
        public IHttpActionResult PurchaseTicket(TicketEdit ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.AddAttendeeToTicket(ticket))
                return BadRequest("Show Is Sold Out");

            return Ok("Ticket Successfully Purchased.");
        }
        /// <summary>
        /// Returns List of Tickets By Attendee Id.
        /// </summary>
        /// <param name="attId">Insert an Attendee Id into the uri arguments, and return a list of relevant tickets.</param>
        /// <returns>Attendee associated with Id input.</returns>
        [HttpGet]
        [Route("api/GetTicketById")]
        public IHttpActionResult GetTicketsByAttendee(int attId)
        {
            var attendees = _attendeeService.GetTicketByAttendee(attId);
            return Ok(attendees);
        }
        /// <summary>
        /// Use to Remove a Ticket row from the Database
        /// </summary>
        /// <param name="tickId">Takes a Ticket Id as a URI parameter</param>
        /// <returns>Success Message.</returns>
        public IHttpActionResult DeleteTicket(int tickId)
        {
            if (!_ticketService.DeleteTicket(tickId))
                return InternalServerError();

            return Ok("Successfully Deleted Attendee!");
        }
    }
}
