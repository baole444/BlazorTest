
using Microsoft.AspNetCore.Mvc;
using StaffServices.Respository;

namespace StaffServices.Models;

[Route("api/[controller]")]
[ApiController]

public class StaffController : ControllerBase 
{
    private readonly IEmployeeRespository employeeRespository;

    public IEmployeeRespository EmployeeRespository => employeeRespository;

    public StaffController(IEmployeeRespository employeeRespository) 
    { 
        this.employeeRespository = employeeRespository;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployee() 
    {
        try 
        { 
            return Ok(await employeeRespository.GetEmployee());

        } 
        catch (Exception e) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"There was an error communicating with the database!\nError: {e}");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeModel>> GetEmployee(int id)
    {
        try
        {
            var result = await employeeRespository.GetEmployee(id);

            if (result == null) return NotFound();

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "There was an error communicating with the database!");
        }
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeModel>> CreateEmployee(EmployeeModel employee) 
    {
        try
        {
            if (employee == null) return BadRequest();

            var createE = await employeeRespository.AddEmployee(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = createE.EmployeeID }, createE);
        }
        catch (Exception) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add the employee.");
        }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeModel>> UpdateEmployee(int id, EmployeeModel employee) 
    {
        try
        {
            if (id != employee.EmployeeID) return BadRequest("Conflict in Employee ID found where input ID=" + id + " vs  model ID=" + employee.EmployeeID);

            var needToUpdate = await employeeRespository.GetEmployee(id);

            if (needToUpdate == null)
            {
                return NotFound($"Employee with ID = {id} was not found!");
            }
            return await employeeRespository.UpdateEmployee(employee);
        }
        catch (Exception) 
        { 
            return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem during database update!");
        }

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<EmployeeModel>> DeleteEmployee(int id) 
    {
        try
        {
            var toDelete = await employeeRespository.GetEmployee(id);

            if (toDelete == null)
            {
                return NotFound($"No such employee with ID {id}.");
            }

            return await employeeRespository.DeleteEmployee(id);
        }
        catch (Exception) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Cannot delete employee data!");
        }

    }


}