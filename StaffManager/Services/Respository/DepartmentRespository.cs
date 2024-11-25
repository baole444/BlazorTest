using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Respository
{
    public class DepartmentRespository : IDepartmentRespository
    {
        private readonly StaffContex staffContex;

        public DepartmentRespository(StaffContex staffContex)
        {
            this.staffContex = staffContex;
        }

        public DepartmentModel GetDepartment(int dID)
        {
            return staffContex.Department.FirstOrDefault(e => e.DepartmentID == dID);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return staffContex.Department;
        }
    }
}
