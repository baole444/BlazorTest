using Services.Models;

namespace Services.Respository
{
    public interface IEmployeeRespository
    {
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task<EmployeeModel> DeleteEmployee(int employee);
        Task<IEnumerable<EmployeeModel>> GetEmployee();
        Task<EmployeeModel> GetEmployee(int employee);

        Task<EmployeeModel> GetEmployee(string email);
        Task<EmployeeModel> UpdateEmployee(EmployeeModel employee);
    }
}