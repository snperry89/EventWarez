using EventWarez.Models.Attendee;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Allows Access to All Attendee-Side Functions
    /// </summary>
    [Authorize]
    public class AttendeeController : ApiController
    {
        private readonly AttendeeService _attendeeService = new AttendeeService();
        /// <summary>
        /// Create a new Attendee Row
        /// </summary>
        /// <param name="att">This Endpoint Creates an Entirely new Attendee Row in the Attendee Database.</param>
        /// <returns>Success Message.</returns>
        public IHttpActionResult PostAttendee(AttendeeCreate att)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_attendeeService.AddAttendee(att))
                return InternalServerError();

            return Ok("Attendee Row Added to Database");
        }
        /// <summary>
        /// Returns Full List of all Existing Attendees
        /// </summary>
        /// <returns>All current Attendee Rows.</returns>
        public IHttpActionResult GetAttendeesFull()
        {
            var attendees = _attendeeService.GetAttendees();
            return Ok(attendees);
        }
        /// <summary>
        /// Use to Remove an Attendee row from the Database
        /// </summary>
        /// <param name="attId">Takes an Attendee Id as a URI parameter</param>
        /// <returns>Success Message.</returns>
        [Route("api/DeleteAttendee")]
        public IHttpActionResult DeleteAttendee(int attId)
        {
            if (!_attendeeService.DeleteAttendee(attId))
                return InternalServerError();
            return Ok("Successfully Deleted Attendee!");
        }
    }
}
