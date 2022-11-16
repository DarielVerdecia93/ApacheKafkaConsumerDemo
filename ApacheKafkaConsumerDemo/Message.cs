using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheKafkaConsumerDemo
{
    public class Payload<T>
    {
        public T After { get; set; }
        public T Before { get; set; }
        public Source Source { get; set; }
        public string Op { get; set; }

        [JsonProperty("ts_ms")]
        public long TsMs { get; set; }
    }
}
