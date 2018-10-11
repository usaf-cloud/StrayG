namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The response contract for a bank account.
    /// See https://plaid.com/docs/api/#accounts
    /// </summary>
    public class FinancialAccount
    {
        /// <summary>
        /// Gets or sets the unique id of the account.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account balance.
        /// </summary>
        /// <remarks>
        /// The Current Balance is the total amount of funds in the account. The Available Balance is the Current Balance 
        /// less any outstanding holds or debits that have not yet posted to the account. Note that not all institutions 
        /// calculate the Available Balance. In the case that Available Balance is unavailable from the institution, 
        /// Plaid will either return an Available Balance value of null or only return a Current Balance.
        /// </remarks>
        [JsonProperty("balances")]
        public Balances Balances { get; set; }

        /// <summary>
        /// The last four digits of the Account's number.
        /// </summary>
        [JsonProperty("mask")]
        public string Mask { get; set; }

        /// <summary>
        /// The name of the Account, either assigned by the user or the financial institution itself.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The official name of the Account as given by the financial institution.
        /// </summary>
        [JsonProperty("official_name")]
        public string OfficialName { get; set; }

        /// <summary>
        /// depository = checking, savings, money market, prepaid
        /// credit = credit, credit card, line of credit
        /// loan = auto, home, home equity, installment, mortgage
        /// mortgage = home
        /// brokerage = brokerage, cash management, ira
        /// other = cd, certificate of deposit, ira, mutual_fund
        /// </summary>
        [JsonProperty("subtype")]
        public string AccountSubtype { get; set; }

        /// <summary>
        /// depository = checking or savings accounts
        /// credit = Credit card
        /// loan = Loan account
        /// mortgage = Mortgage account
        /// brokerage = Brokerage account
        /// other = Non-specified account type
        /// </summary>
        [JsonProperty("type")]
        public string AccountType { get; set; }
    }
}