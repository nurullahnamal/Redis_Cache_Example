
using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1453");

ISubscriber subscriber = connection.GetSubscriber();

await subscriber.SubscribeAsync("myChannel.*", (channel, message) =>
{
    Console.WriteLine(message);
});

Console.Read();