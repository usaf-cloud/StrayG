using Newtonsoft.Json;

namespace StrayG.Boats.Data.Contracts.Responses.Models
{
    /// <summary>
    /// See <see cref="http://api.boats.com/docs/services/details?s=inventory#ids"/>
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the positive integer that uniquely identifies an item.
        /// </summary>
        [JsonProperty("DocumentID")]
        public int ItemId { get; set; }
    }
}
