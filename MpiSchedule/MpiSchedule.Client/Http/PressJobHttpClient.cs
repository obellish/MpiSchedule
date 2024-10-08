﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Client.Http;

public class PressJobHttpClient(HttpClient client) : BaseClient(client)
{
    public async Task<PressJob[]> GetAllJobsAsync() => await Client.GetFromJsonAsync<PressJob[]>("api/PressJob") ?? [];

    public async Task<PressJob?> GetJobAsync(int id) => await Client.GetFromJsonAsync<PressJob>($"api/PressJob/{id}");

    public async Task EditJobAsync(PressJob job) => await Client.PatchAsJsonAsync("api/PressJob", job);

    public async Task<HttpResponseMessage> CreateJobAsync(PressJob job) => await Client.PostAsJsonAsync("api/PressJob", job);

    public async Task DeleteJobAsync(int id) => await Client.DeleteAsync($"/api/PressJob/{id}");
}