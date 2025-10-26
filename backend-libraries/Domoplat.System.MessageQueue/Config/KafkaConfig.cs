namespace Domoplat.System.MessageQueue.Config;

public class KafkaConfig
{
    public string BootstrapServers { get; set; }
    
    public string GroupId { get; set; }
}