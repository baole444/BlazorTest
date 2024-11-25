using Microsoft.AspNetCore.Components;

namespace Services.Models
{
    public class StaffEditBase : ComponentBase
    {
        public EmployeeModel Staff { get; set; } = new EmployeeModel();
        [Inject]
        public IStaffService StaffService { get; set; }

        [Parameter]
        public string Id { get; set; }
        
        [Parameter]
        public EmployeeModel NewDetail { get; set; } = new EmployeeModel();
        
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Staff = await StaffService.GetStaff(int.Parse(Id));
            NewDetail = Staff;
        }

        protected async Task UpdateDetail() 
        {
            NewDetail = await StaffService.EditStaff(NewDetail);
        }
    }
}
