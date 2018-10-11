namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Models;

    /// <summary>
    /// Contract for a transaction response from Plaid.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the id of the account in which this transaction occurred.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account owner.
        /// </summary>
        [JsonProperty("account_owner")]
        public string AccountOwner { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <remarks>
        /// The settled dollar value. Positive values when money moves out of the account; negative values when money moves in.
        /// </remarks>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// An hierarchical array of the categories to which this transaction belongs.
        /// </summary>
        [JsonProperty("category")]
        public IList<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the id of the category to which this transaction belongs.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the date that the transaction was posted by the financial institution (in ISO 8601 format).
        /// </summary>
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// Gets or sets the date that the transaction was posted by the financial institution (in ISO 8601 format).
        /// </summary>
        [JsonProperty("location")]
        public TransactionLocation Location { get; set; }

        /// <summary>
        /// Gets or sets the transaction name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the payment meta information name.
        /// </summary>
        [JsonProperty("payment_meta")]
        public PaymentMetadata PaymentMetadata { get; set; }

        /// <summary>
        /// Gets or sets the pending transaction id.
        /// </summary>
        [JsonProperty("pending")]
        public bool Pending { get; set; }

        /// <summary>
        /// Gets or sets the pending transaction id.
        /// </summary>
        [JsonProperty("pending_transaction_id")]
        public string PendingTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction id.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction type. Can be Place, Digital, or Special.
        /// TODO: Parse this explicitly.
        /// </summary>
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
    }
}