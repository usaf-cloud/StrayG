namespace StrayG.Plaid.Data.Link
{
    using Newtonsoft.Json;

    public class OnSuccessMetadata
    {
        [JsonProperty("institution")]
        public Institution Institution { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        public static OnSuccessMetadata DeserializeFromJson(string metaDataString)
        {
            return JsonConvert.DeserializeObject<OnSuccessMetadata>(metaDataString);
        }
    }
}
