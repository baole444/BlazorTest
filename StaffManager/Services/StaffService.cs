//namespace StaffManager.Services

using Services.Models;

namespace System.Net.Http
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient _httpClient;

        public StaffService(HttpClient httpClient) { this._httpClient = httpClient; }

        public async Task<IEnumerable<EmployeeModel>> GetAllStaffs()
        {
            return await _httpClient.GetFromJsonAsync<EmployeeModel[]>("api/Staff");
        }

        public async Task<EmployeeModel> GetStaff(int id)
        {
            return await _httpClient.GetFromJsonAsync<EmployeeModel>($"api/Staff/{id}");
        }

        public async Task<EmployeeModel> EditStaff(EmployeeModel detail)
        {
            HttpResponseMessage res = await _httpClient.PutAsJsonAsync($"api/Staff/{detail.EmployeeID}", detail);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return await res.Content.ReadFromJsonAsync<EmployeeModel>();
            }
            else
            {
                throw new Exception($"Failed to edit {detail.FirstName}\'s details with error {res.StatusCode}");
            }
        }

        public async Task<EmployeeModel> CreateStaff(EmployeeModel detail)
        {
            HttpResponseMessage res = await _httpClient.PostAsJsonAsync($"api/Staff", detail);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return await res.Content.ReadFromJsonAsync<EmployeeModel>();
            }
            else
            {
                throw new Exception($"Failed to add {detail.FirstName}\'s details to database with error {res.StatusCode}");
            }
        }

        public async Task<EmployeeModel> DeleteStaff(int id)
        {
            HttpResponseMessage res = await _httpClient.DeleteAsync($"api/Staff/{id}");

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return await res.Content.ReadFromJsonAsync<EmployeeModel>();
            }
            else
            {
                throw new Exception($"Failed to remove Staff with ID:{id} from database with error {res.StatusCode}");
            }
        }
    }
}
