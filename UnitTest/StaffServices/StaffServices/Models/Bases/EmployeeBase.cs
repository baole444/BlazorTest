using Microsoft.AspNetCore.Components;
using StaffServices.Respository;

namespace StaffServices.Models
{
    public class EmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeRespository StaffRespo { get; set; }

        public IEnumerable<EmployeeModel>  Staff {  get; set; }

        protected override async Task OnInitializedAsync() {
            Staff = await StaffRespo.GetEmployee();
        }
    }
}
