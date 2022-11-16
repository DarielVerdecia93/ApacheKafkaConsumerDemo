using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApacheKafkaConsumerDemo
{
    public class Source
    {
        public string Version { get; set; }
        public string Connector { get; set; }
        public string Name { get; set; }

        [JsonProperty("ts_ms")]
        public long TsMs { get; set; }
        public string Db { get; set; }
        public string Snapshot { get; set; }
        public string Sequence { get; set; }
        public string Schema { get; set; }
        public string Table { get; set; }

        [JsonProperty("change_lsn")]
        public string Changelsn { get; set; }

        [JsonProperty("commit_lsn")]
        public string Commitlsn { get; set; }

        [JsonProperty("event_serial_no")]
        public string EventSerialNo { get; set; }
    }
}
