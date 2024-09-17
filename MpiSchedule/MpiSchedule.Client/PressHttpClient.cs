using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Client;

public class PressHttpClient(HttpClient client)
{
    public async Task<Press[]> GetAllPressesAsync() => await client.GetFromJsonAsync<Press[]>("api/Press") ?? [];
}