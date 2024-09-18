using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MpiSchedule.Hubs;

public class RefreshScheduleHub : Hub
{
    public async Task RefreshSchedule(int pressId) => await Clients.Others.SendAsync(nameof(RefreshSchedule), pressId);

    public async Task AddJob(int pressId, int jobId) => await Clients.Others.SendAsync(nameof(AddJob), pressId, jobId);

    public async Task EditJob(int pressId, int jobId) =>
        await Clients.Others.SendAsync(nameof(EditJob), pressId, jobId);
}