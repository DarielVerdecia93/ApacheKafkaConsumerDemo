using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheKafkaConsumerDemo
{
    internal class Program
    {

        /* private const string BootstrapServer = "localhost:29092";
         private const string TopicName = "test";*/

        private const string BootstrapServer = "10.0.0.181:9092";
        //private const string BootstrapServer = "localhost:29092";
        private const string TopicName = "consumer.agent.changes";

        
        static void Main(string[] args)
        {
            var consumer = new Consumer(BootstrapServer);
            consumer.StartReceivingMessages(TopicName);
        }
    }
}
