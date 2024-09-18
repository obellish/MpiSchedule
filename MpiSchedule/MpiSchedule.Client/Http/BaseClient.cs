using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace MpiSchedule.Client.Http;

public abstract class BaseClient(HttpClient http)
{
    protected HttpClient Client { get; } = http;

    public static Action<HttpClient> ConfigureClient(IConfiguration config) => client =>
        client.BaseAddress = new Uri(config["BackendUrl"] ?? "http://localhost:5286");
}