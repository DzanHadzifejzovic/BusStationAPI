using Sieve.Attributes;

namespace Mappings.DTOs.SerilogSeq
{
    public class SeqLogData
    {
        [Sieve(CanSort = true)]
        public DateTime Timestamp { get; set; }
        [Sieve(CanSort = true, CanFilter = true)]
        public string RequestMethod { get; set; }
        [Sieve(CanFilter = true)]
        public string RequestPath{ get; set; }
        [Sieve(CanSort = true)]
        public string StatusCode { get; set; }

        public SeqLogData(DateTime timestamp, string requestMethod, string requestPath, string statusCode)
        {
            Timestamp = timestamp;
            RequestMethod = requestMethod;
            RequestPath = requestPath;
            StatusCode = statusCode;
        }
    }
}
