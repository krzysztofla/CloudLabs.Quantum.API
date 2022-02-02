using StackExchange.Redis;

namespace CloudLabs.Quantum.API.BackgroundTasks;

public class RedisSubscriber : BackgroundService
{
    private readonly IConnectionMultiplexer _multiplexer;

    public RedisSubscriber(IConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriber = _multiplexer.GetSubscriber();
        return subscriber.SubscribeAsync("messages", (channel, value) =>
        {
            Console.WriteLine($"Message payload was: {value}");
        } );
    }
}