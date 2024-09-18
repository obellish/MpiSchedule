using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Client.Http;

public class PressHttpClient(HttpClient client) : BaseClient(client)
{
    public async Task<Press[]> GetAllPressesAsync(bool includeJobs = false) => await Client.GetFromJsonAsync<Press[]>($"api/Press?includeJobs={includeJobs}") ?? [];

    public async Task<Press?> GetPressAsync(int id, bool loadJobs = false) => await Client.GetFromJsonAsync<Press>($"api/Press/{id}?loadJobs={loadJobs}");
}