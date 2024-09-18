using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MpiSchedule.Hubs;

public class RefreshScheduleHub : Hub
{
    public async Task RefreshSchedule(int pressId) => await Clients.Others.SendAsync(nameof(RefreshSchedule), pressId);
}