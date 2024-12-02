
using Microsoft.Extensions.Hosting;

namespace Inventory.Infrastructure.Kafka;

public class KafkaHostedService(KafkaDispatcher dispatcher) : BackgroundService
{
    protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();
        var consumingTasks = new List<Task>
        {
            Task.Run(() => dispatcher.StartConsumingProductCreated(stoppingToken), stoppingToken)
        };

        await Task.WhenAll(consumingTasks);
    }
    
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stopping Kafka consumer...");
        await base.StopAsync(cancellationToken);
    }
}