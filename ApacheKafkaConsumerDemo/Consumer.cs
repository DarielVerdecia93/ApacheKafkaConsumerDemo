using ApacheKafkaProducerDemo.Models;
using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApacheKafkaConsumerDemo
{
    public class Consumer
    {

        private readonly ConsumerConfig _consumerConfig;
        public void StartReceivingMessages(string topicName)
        {
            IConsumer<string, string> consumer = NewMethod();
            try
            {
                consumer.Subscribe(topicName);
                Console.WriteLine("\nConsumer loop started...\n\n");
                while (true)
                {
                    var result =
                        consumer.Consume(
                            TimeSpan.FromMilliseconds(_consumerConfig.MaxPollIntervalMs - 1000 ?? 250000));
                    var message = result?.Message?.Value;
                    if (message == null)
                    {
                        continue;
                    }

                    /*if (dataRead.State == "dariel")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Received ");
                    }*/
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Received ");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(
                        $"{result.Message.Key}:{message}");

                    consumer.Commit(result);
                    consumer.StoreOffset(result);
                }
            }
            catch (KafkaException e)
            {
                Console.WriteLine($"Consume error: {e.Message}");
                Console.WriteLine("Exiting producer...");
            }
            finally
            {
                consumer.Close();
            }
        }
        private IConsumer<string, string> NewMethod()
        {
            return new ConsumerBuilder<string, string>(_consumerConfig)
                            .SetKeyDeserializer(Deserializers.Utf8)
                            .SetValueDeserializer(Deserializers.Utf8)
                            .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                            .Build();
        }
        public Consumer(string bootstrapServer)
        {
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = bootstrapServer,
                EnableAutoCommit = false,
                EnableAutoOffsetStore = false,
                MaxPollIntervalMs = 300000,
                GroupId = "default",

                // Read messages from start if no commit exists.
                AutoOffsetReset = AutoOffsetReset.Latest
            };
        }
    }
}
