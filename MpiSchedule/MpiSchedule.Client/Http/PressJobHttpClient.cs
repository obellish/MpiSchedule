using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Client.Http;

public class PressJobHttpClient(HttpClient client)
{
    public async Task<PressJob[]> GetAllJobsAsync() => await client.GetFromJsonAsync<PressJob[]>("api/PressJob") ?? [];

    public async Task<PressJob?> GetJobAsync(int id) => await client.GetFromJsonAsync<PressJob>($"api/PressJob/{id}");

    public async Task EditJobAsync(PressJob job) => await client.PatchAsJsonAsync("api/PressJob", job);
}