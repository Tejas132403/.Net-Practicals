using Microsoft.AspNetCore.Mvc;
using StudentCampusPortal.DAL;
using StudentCampusPortal.Models;
using System.Collections.Generic;

namespace StudentCampusPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceApiController : ControllerBase
    {
        private readonly ServiceRequestDAL _dal;

        public ServiceApiController(ServiceRequestDAL dal)
        {
            _dal = dal;
        }

        // GET: api/ServiceApi
        [HttpGet]
        public ActionResult<IEnumerable<ServiceRequest>> GetRequests()
        {
            var requests = _dal.GetAll();
            return Ok(requests);
        }

        // GET: api/ServiceApi/5
        [HttpGet("{id:int}")]
        public ActionResult<ServiceRequest> GetRequest(int id)
        {
            var req = _dal.GetById(id);
            if (req == null)
            {
                return NotFound(new { message = $"Request with ID {id} not found." });
            }
            return Ok(req);
        }

        // POST: api/ServiceApi
        [HttpPost]
        public IActionResult CreateRequest([FromBody] ServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int newId = _dal.Insert(request);
            request.RequestId = newId;

            return CreatedAtAction(nameof(GetRequest), new { id = newId }, new
            {
                message = "Service request created successfully",
                data = request
            });
        }

        // PUT: api/ServiceApi/UpdateStatus/5
        [HttpPut("UpdateStatus/{id:int}")]
        public IActionResult UpdateStatus(int id, [FromBody] StatusUpdateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Status))
            {
                return BadRequest(new { message = "Status is required." });
            }

            bool updated = _dal.UpdateStatus(id, dto.Status);
            if (!updated)
            {
                return NotFound(new { message = $"Request with ID {id} not found." });
            }

            return Ok(new { message = $"Status for request #{id} updated to '{dto.Status}' successfully." });
        }
    }

    public class StatusUpdateDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
