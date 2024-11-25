using Microsoft.EntityFrameworkCore;
using StaffServices.Models;

namespace StaffServices.Respository
{
    public class EmployeeRespository : IEmployeeRespository
    {
        private readonly StaffContex staffContex;

        public EmployeeRespository(StaffContex staffContex)
        {
            this.staffContex = staffContex;
        }

        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            var result = await staffContex.Employee.AddAsync(employee);
            await staffContex.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmployeeModel> DeleteEmployee(int employee)
        {
            var result = await staffContex.Employee.FirstOrDefaultAsync(e => e.EmployeeID == employee);
            if (result != null)
            {
                staffContex.Employee.Remove(result);
                await staffContex.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployee()
        {
            return await staffContex.Employee.ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployee(int employee)
        {
            return await staffContex.Employee.Include(e => e.Department).Include(e => e.Gender).FirstOrDefaultAsync(e => e.EmployeeID == employee);
        }

        public async Task<EmployeeModel> GetEmployee(string email) 
        { 
            return await staffContex.Employee.Include(e => e.Department).Include(e => e.Gender).FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<EmployeeModel> UpdateEmployee(EmployeeModel employee)
        {
            var result = await staffContex.Employee.FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.DateOfBirth = employee.DateOfBirth;
                await staffContex.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
