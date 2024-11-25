namespace StaffServices.Models
{
    public class EmployeeModel
    {
        public int? EmployeeID { get; set; }

        public String? FirstName { get; set; }

        public String? LastName { get; set; }

        public String? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? GenderID { get; set; }

        public int? DepartmentID { get; set; }

        public GenderModel? Gender { get; set; }

        public DepartmentModel? Department { get; set; }


    }
}
