namespace StrayG.Plaid.Data.Contracts.Request
{
    using Newtonsoft.Json;

    internal class CountOffsetRequest
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        public CountOffsetRequest(int count = 500, int offset = 0)
        {
            Count = count;
            Offset = offset;
        }
    }
}
