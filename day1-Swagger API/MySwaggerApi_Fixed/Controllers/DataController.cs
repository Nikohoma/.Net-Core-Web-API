using Microsoft.AspNetCore.Mvc;
using MySwaggerApi.Models;

namespace MySwaggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private static List<Employee> _employees { get; set; } = new List<Employee>()
    {
         new Employee { Id = 1, Name = "Narendar", Designation = "Developer" },
        new Employee { Id = 2, Name = "Babu", Designation = "Designer" },
        new Employee { Id = 3, Name = "Prabhu", Designation = "Manager" }
    };
    public static List<string> Data { get; set; } = new List<string>()
    {
        "Some Data",
        "Another One"
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Forecast = "Sunny", Temperature = 32 },
            new { Id = 2, Forecast = "Cloudy", Temperature = 28 },
            new { Id = 3, Forecast = "Rainy", Temperature = 24 }
        });
    }

    [HttpPost]   // To add/post something new
    public IActionResult Addstring(string newString)
    {
        Data.Add(newString);
        return Ok(new { m = "String added Successfully", Data });
    }

    [HttpPost("EmployeesAdd")]   // To add/post something new
    public IActionResult AddEmployee(Employee emp)
    {
        _employees.Add(emp);
        return Ok(new { m = "Employee added Successfully", _employees });
    }

    [HttpPut("{id}")]   // To Modify field, have to pass a whole new object 
    public IActionResult UpdateEmployeeName(int id, Employee updatedEmployee)
    {
        var emp = _employees.FirstOrDefault(i => i.Id == id);
        if (emp == null)
        {
            return NotFound(new { m = "Employee not found" });
        }
        emp.Name = updatedEmployee.Name;
        emp.Designation = updatedEmployee.Designation;

        return Ok(new { m = "Employee Details Updated", _employees });

    }

    [HttpPatch("{id}")]   // To modify, dont need to pass whole object for updation
    public IActionResult PatchEmployee(int id, string empName)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound(new { Message = "Employee not found" });
        }
        if (!string.IsNullOrEmpty(empName))
        {
            employee.Name = empName;
        }

        return Ok(new { Message = "Employee patched successfully", Employee = employee });
    }

    [HttpGet("Employees")]
    public IActionResult GetAllEmployees()
    {
        return Ok(new { _employees });
    }

}