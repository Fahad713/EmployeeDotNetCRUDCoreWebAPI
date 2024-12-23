using AdminPortal.Data;
using AdminPortal.Models;
using AdminPortal.Models.Entities;
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

        //Gets All Employees
        [HttpGet]
        public IActionResult GetAllEmployees() {
            var allEmployees = DbContext.Employees.ToList();
            return Ok(allEmployees);

        }

        // Get Employee by id 
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // Set New Employees
        [HttpPost]
        public IActionResult SetEmployee(AddEmployeeDTO AddEmployee)
        {
            var employeeEntity = new Employee()
            {
                Name = AddEmployee.Name,
                Email = AddEmployee.Email,
                Phone = AddEmployee.Phone,
                Salary = AddEmployee.Salary,
            };

            DbContext.Employees.Add(employeeEntity);
            DbContext.SaveChanges();
            return Ok(employeeEntity);
        }

        //Update a Employee
        [HttpPut]
        [Route("{id:guid}")]
        public  IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updatedEmployee)
        {
            var employee = DbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Phone = updatedEmployee.Phone;
            employee.Salary = updatedEmployee.Salary;
            DbContext.SaveChanges();
            return Ok(employee);
        }

        // Delete A Employee 
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee is null) { 
                return NotFound();
            }
            
            DbContext.Employees.Remove(employee);
            DbContext.SaveChanges();
            return Ok();
        }
    }
}
 