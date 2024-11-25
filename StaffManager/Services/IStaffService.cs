//namespace StaffManager.Services

using Services.Models;

namespace System.Net.Http
{
    public interface IStaffService
    {
        Task<EmployeeModel> CreateStaff(EmployeeModel detail);
        Task<EmployeeModel> DeleteStaff(int id);
        Task<EmployeeModel> EditStaff(EmployeeModel detail);
        Task<IEnumerable<EmployeeModel>> GetAllStaffs();
        Task<EmployeeModel> GetStaff(int id);
    }
}