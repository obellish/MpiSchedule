using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Client.Http;

public class PressHttpClient(HttpClient client)
{
    public static Action<HttpClient> ConfigureClient(IConfiguration config) => client =>
        client.BaseAddress = new Uri(config["BackendUrl"] ?? "https://localhost:7088");

    public async Task<Press[]> GetAllPressesAsync() => await client.GetFromJsonAsync<Press[]>("api/Press") ?? [];

    public async Task<Press?> GetPressAsync(int id) => await client.GetFromJsonAsync<Press>($"api/Press/{id}");
}