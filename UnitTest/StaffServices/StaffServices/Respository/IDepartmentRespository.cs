using StaffServices.Models;

namespace StaffServices.Respository
{
    public interface IDepartmentRespository
    {
        DepartmentModel GetDepartment(int dID);
        IEnumerable<DepartmentModel> GetDepartments();
    }
}