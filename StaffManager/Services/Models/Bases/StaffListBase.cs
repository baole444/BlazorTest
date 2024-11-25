using Microsoft.AspNetCore.Components;
using Services.Models;

namespace Services.Models
{
    public class StaffListBase : ComponentBase
    {
        [Inject]

        public IStaffService StaffService { get; set; }

        public IEnumerable<EmployeeModel> Staffs { get; set; }

        protected override async Task OnInitializedAsync() {
            Staffs = await StaffService.GetAllStaffs();
        }
    }
}
