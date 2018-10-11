namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using Newtonsoft.Json;

    public class PaymentMetadata
    {
        /// <summary>
        /// Gets or sets who ordered it.
        /// </summary>
        [JsonProperty("by_order_of")]
        public string ByOrderOf { get; set; }

        // <summary>
        /// Gets or sets payee.
        /// </summary>
        [JsonProperty("payee")]
        public string Payee { get; set; }

        // <summary>
        /// Gets or sets payer.
        /// </summary>
        [JsonProperty("payer")]
        public string Payer { get; set; }

        // <summary>
        /// Gets or sets payment method.
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        // <summary>
        /// Gets or sets payment processor.
        /// </summary>
        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        // <summary>
        /// Gets or sets ppd id.
        /// </summary>
        [JsonProperty("ppd_id")]
        public string PPDId { get; set; }

        // <summary>
        /// Gets or sets reason.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        // <summary>
        /// Gets or sets reference number.
        /// </summary>
        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }
    }
}
