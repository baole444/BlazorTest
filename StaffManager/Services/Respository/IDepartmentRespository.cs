using Services.Models;

namespace Services.Respository
{
    public interface IDepartmentRespository
    {
        DepartmentModel GetDepartment(int dID);
        IEnumerable<DepartmentModel> GetDepartments();
    }
}