using AdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeeController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {
            var allEmployees = DbContext.Employees.ToList();
            return Ok(allEmployees);

        }
    }
}
 