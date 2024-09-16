namespace MpiSchedule.Services;

public class AuthMessageSenderOptions
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? EmailServerAddress { get; set; }

    public int Port { get; set; }
}