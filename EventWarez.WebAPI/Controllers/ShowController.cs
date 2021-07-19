using EventWarez.Models.Show;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Access to Venue-Side Functionality
    /// </summary>
    [Authorize]

    public class ShowController : ApiController
    {
        private ShowService CreateShowService()
        {
            var showService = new ShowService();
            return showService;
        }
        /// <summary>
        /// Allows User to Post a new Show Object to the database
        /// </summary>
        /// <param name="show">Takes in show properties and adds them to the database.</param>
        /// <returns>Success Message</returns>
        [HttpPost]
        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();

            return Ok("Show Successfully Added!");
        }
        /// <summary>
        /// Return a List of All Shows
        /// </summary>
        /// <returns>All Current Shows in Database.</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }
        /// <summary>
        /// Returns one show by ShowId
        /// </summary>
        /// <param name="id">Takes a ShowId number as a URI parameter, and returns that object.</param>
        /// <returns>Show associated with Id input.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }
        /// <summary>
        /// Allows user to update the ShowTime/Feature properties of an existing show object.
        /// </summary>
        /// <param name="show">Takes in new Showtime/Feature information for update.</param>
        /// <returns>Success Message.</returns>
        [HttpPut]
        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();

            return Ok("Show Successfully Updated");
        }
        /// <summary>
        /// Deletes a Show Object from the Show Database
        /// </summary>
        /// <param name="id">Takes in a ShowId as a URI parameter, and deletes the object from the database.</param>
        /// <returns>Success Message.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            {
                var service = CreateShowService();

                if (!service.DeleteShow(id))
                    return InternalServerError();

                return Ok("Show Successfully Deleted");
            }
        }
    }
}
