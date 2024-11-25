using Microsoft.AspNetCore.Components;
using Services.Respository;

namespace Services.Models
{
    public class StaffDetailBase : ComponentBase
    {
        public EmployeeModel Staff { get; set; } = new EmployeeModel();
        [Inject]
        public IStaffService StaffService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync() {
            Id = Id ?? "1";
            Staff = await StaffService.GetStaff(int.Parse(Id));
        }
    }
}
