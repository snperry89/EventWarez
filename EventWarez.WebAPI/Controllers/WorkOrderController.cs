using EventWarez.Models;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Allows Access To Functions Regarding the Management of WorkOrder Objects.
    /// </summary>
    [Authorize]
    public class WorkOrderController : ApiController
    {
        /// <summary>
        /// Create a New Work Order to be filled.
        /// </summary>
        /// <param name="workOrder">Takes in a Work Order by the Parameters in the Body, and Adds the New Object to the Database</param>
        /// <returns>Success Message.</returns>
        [HttpPost]
        public IHttpActionResult PostWorkOrder(WorkOrderCreate workOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService();

            if (!service.CreateWorkOrder(workOrder))
                return InternalServerError();

            return Ok("Work Order Created");
        }
        /// <summary>
        /// Returns a List of ALL Work Orders
        /// </summary>
        /// <returns>Full List of All Current Work Orders in System.</returns>
        [HttpGet]
        public IHttpActionResult GetAllWorkOrders()
        {
            var service = new WorkOrderService();
            var workOrders = service.GetAllWorkOrders();
            return Ok(workOrders);
        }
        /// <summary>
        /// Returns a list of work orders associated with a specific show that HAVE been assigned a Staff Member.
        /// </summary>
        /// <param name="showId">Takes in a ShowId as a URI Parameter, and Returns That Object.</param>
        /// <returns>Returns Work Orders Associated with Id input.</returns>
        [Route("api/GetClosedWorkOrders")]
        [HttpGet]
        public IHttpActionResult GetStaffRoster(int showId)
        {
            var service = new WorkOrderService();
            return Ok(service.GetFilledWorkOrders(showId));
        }
        /// <summary>
        /// Returns a list of work orders associated with a specific show that HAVE NOT yet been assigned a Staff Member.
        /// </summary>
        /// <param name="showId">Takes in a showID as a URI parameter.</param>
        /// <returns>Appropriate Work Order Rows.</returns>
        [Route("api/GetOpenWorkOrders")]
        [HttpGet]
        public IHttpActionResult GetOpenWorkOrders(int showId)
        {
            var service = new WorkOrderService();
            return Ok(service.GetUnfilledWorkOrders(showId));
        }
        /// <summary>
        /// Allows the user to search for a specific work order.
        /// </summary>
        /// <param name="id">Takes in a Work Order Id as at URI parameter.</param>
        /// <returns>The Appropriate Datarow.</returns>
        [Route("api/GetWorkOrderById")]
        [HttpGet]
        public IHttpActionResult GetSingleWorkOrder(int id)
        {
            var service = new WorkOrderService();
            var workOrders = service.GetWorkOrder(id);
            return Ok(workOrders);
        }
        /// <summary>
        /// Allows a User to Alter the Details of an Existing Work Order Object.
        /// </summary>
        /// <param name="workOrderEdit">Takes in the parameters defined in the body, and updates that Work Order Object in the Database.</param>
        /// <returns>Success Message.</returns>
        [Route("api/UpdateWorkOrder")]
        [HttpPut]
        public IHttpActionResult UpdateWorkOrder(WorkOrderEdit workOrderEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService().UpdateWorkOrder(workOrderEdit);

            if (!service)
                return InternalServerError();

            return Ok("Work Order Updated");
        }
        /// <summary>
        /// Allows the User to assign a Staff Member to an Open Work Order.
        /// </summary>
        /// <param name="assignmentInfo">Takes in a WorkOrderId and a Staff Id in the body.</param>
        /// <returns>Success Message</returns>
        [Route("api/Assign")]
        [HttpPut]
        public IHttpActionResult FillWorkOrder(WorkOrderAssign assignmentInfo)
        {
            var service = new WorkOrderService();

            if (!service.AddStaffToWorkOrder(assignmentInfo))
                return InternalServerError();

            return Ok("Employee added to work order");
        }
        /// <summary>
        /// Deletes a Work Order Object.
        /// </summary>
        /// <param name="id">Takes in a WorkOrderId as a URI Parameter, and Deletes that Object from the Database.</param>
        /// <returns>Success Message.</returns>
        [HttpDelete]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            var service = new WorkOrderService();
            if (!service.DeleteWorkOrder(id))
                return InternalServerError();

            return Ok("Work Order Deleted");
        }
    }
}
