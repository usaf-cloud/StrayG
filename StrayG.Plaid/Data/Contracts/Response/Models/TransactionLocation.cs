namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using Newtonsoft.Json;

    public class TransactionLocation
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the latitude in degrees.
        /// </summary>
        [JsonProperty("lat")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude in degrees.
        /// </summary>
        [JsonProperty("lon")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the store number.
        /// </summary>
        [JsonProperty("store_number")]
        public string StoreNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [JsonProperty("zip")]
        public string ZipCode { get; set; }
    }
}
