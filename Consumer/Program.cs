// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092", AutoOffsetReset = AutoOffsetReset.Earliest,
    GroupId = "kafka-dotnet-getting-started"
};
const string topic = "purchases";


using var consumer = new ConsumerBuilder<string, string>(config).Build();

consumer.Subscribe(topic);

while (true)
{
    var consumeResult = consumer.Consume(CancellationToken.None);
    if (consumeResult is not null)
    {
        var message = consumeResult.Message;
        // Process the message
        Console.WriteLine($"Received message: Key={message.Key}, Value={message.Value}");
    }
}