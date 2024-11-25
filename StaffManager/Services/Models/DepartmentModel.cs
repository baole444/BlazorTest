using System.Text.Json.Serialization;

namespace Services.Models
{
    public partial class DepartmentModel
    {
        public int? DepartmentID { get; set; }

        public String? DepartmentName { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
