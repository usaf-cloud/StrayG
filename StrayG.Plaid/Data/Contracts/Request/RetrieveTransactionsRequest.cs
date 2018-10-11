namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The get transactions request.
    /// </summary>
    internal class RetrieveTransactionsRequest : PlaidRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveTransactionsRequest"/> class.
        /// </summary>
        /// <param name="clientId">The client id provided on signup.</param>
        /// <param name="secret">The client secret provided on signup.</param>
        /// <param name="accessToken">The access token associated with the request.</param>
        /// <param name="startDate">The start date of transactions.</param>
        /// <param name="endDate">The end date of transactions.</param>
        /// <param name="count">The number of transactions to retrieve.</param>
        /// <param name="offset">The offset of transactions.</param>
        public RetrieveTransactionsRequest(string clientId, string secret, string accessToken, DateTimeOffset startDate, DateTimeOffset endDate, int count = 500, int offset = 0)
            : base(clientId, secret, accessToken)
        {
            Options = new CountOffsetRequest(count, offset);
            StartDate = startDate.ToString("yyyy-MM-dd");
            EndDate = endDate.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Gets or sets the start date in yyyy-mm-dd format.
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date in yyyy-mm-dd format.
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        [JsonProperty("options")]
        public CountOffsetRequest Options { get; set; }
    }
}