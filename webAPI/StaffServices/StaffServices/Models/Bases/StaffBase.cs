using Microsoft.AspNetCore.Components;
using StaffServices.Respository;

namespace StaffServices.Models
{
    public class StaffBase : ComponentBase
    {
        public EmployeeModel Staff { get; set; } = new EmployeeModel();
        [Inject]
        public IEmployeeRespository StaffRespo { get; set; }

        [Parameter]
        public string StaffId { get; set; }

        protected async override Task OnInitializedAsync() {
            StaffId = StaffId ?? "1";
            Staff = await StaffRespo.GetEmployee(int.Parse(StaffId));
        }
    }
}
