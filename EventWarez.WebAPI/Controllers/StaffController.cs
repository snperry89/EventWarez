using EventWarez.Models.Staff;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Access to Staff-Side Functionality.
    /// </summary>
    [Authorize]
    public class StaffController : ApiController
    {
        /// <summary>
        /// Creates a New Staff Member
        /// </summary>
        /// <param name="staff">Takes in a Staff Object by the Parameters Defined in the Body, and Adds the New Object to the Database.</param>
        /// <returns>Success Message.</returns>
        public IHttpActionResult Post(StaffCreate staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var staffService = new StaffService();

            if (!staffService.CreateStaff(staff))
                return InternalServerError();

            return Ok("Staffmember Created");
        }
        /// <summary>
        /// Returns a List of All Staff Members.
        /// </summary>
        /// <returns>All current Staff Members in Database.</returns>
        public IHttpActionResult Get()
        {
            var staffService = new StaffService();
            var staffDetails = staffService.GetStaffDetails();
            return Ok(staffDetails);
        }
        /// <summary>
        /// Returns a single Staff Member.
        /// </summary>
        /// <param name="id">Takes in a StaffId as a URI Parameter, and returns that Object.</param>
        /// <returns>Staff Member associated with Id input.</returns>
        public IHttpActionResult Get(int id)
        {
            var staffMember = new StaffService().GetStaffById(id);
            return Ok(staffMember);
        }
        /// <summary>
        /// Use to Update an Existing Staff Member.
        /// </summary>
        /// <param name="staff">Takes in a Model of the Staff Object, as Defined by Body Parameters, and Updates that Object in the DataBase</param>
        /// <returns>Success Message.</returns>
        public IHttpActionResult Put(StaffEdit staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool service = new StaffService().UpdateStaff(staff);
            if (!service)
                return InternalServerError();

            return Ok("Staff Updated");
        }
        /// <summary>
        /// Use to Delete a Staff Member From the Database.
        /// </summary>
        /// <param name="id">Takes in a StaffId as a URI Parameter, and Deletes that Object from the DataBase.</param>
        /// <returns>Success Message.</returns>
        public IHttpActionResult Delete(int id)
        {
            bool service = new StaffService().DeleteStaff(id);

            if (!service)
                return InternalServerError();

            return Ok("Staff Deleted");
        }
    }
}
