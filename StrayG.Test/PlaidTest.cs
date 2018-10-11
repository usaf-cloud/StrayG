using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrayG.Plaid;
using StrayG.Plaid.Data.Results;
using System.Threading.Tasks;
using StrayG.Plaid.Data.Contracts.Response;

namespace StrayG.Test
{
    [TestClass]
    public class PlaidTest
    {
        public const string QF_Plaid_Client_ID = "59595c954e95b8407ec699a6";
        public const string QF_Plaid_Public_Key = "58b776a5e741bff84ad58ad0bf6fb6";
        public const string QF_Plaid_Client_Secret = "eee289a23a202e5e1ad397a2cac0e9";

        public const string Plaid_Sandbox_URL = "https://sandbox.plaid.com";
        public const string Plaid_Sandbox_Access_Token = "access-sandbox-7c69d345-fd46-461f";
        public const string Plaid_Sandbox_Public_Token = "public-sandbox-fb7cca4a-82e6-4707";
        public const string Plaid_Sandbox_Username = "user_good";
        public const string Plaid_Sandbox_User_Password = "pass_good";
        public const string Plaid_Sandbox_User_PIN = "credential_good";

        public const string Plaid_Development_URL = "https://development.plaid.com";
        public const string Plaid_Production_URL = "https://production.plaid.com";

        public const string Plaid_Tartan_URL = "https://tartan.plaid.com";
        public const string Plaid_Tartan_Client_ID = "test_id";
        public const string Plaid_Tartan_Client_Secret = "test_secret";
        public const string Plaid_Tartan_Username = "plaid_test";
        public const string Plaid_Tartan_User_Password = "plaid_good";
        public const string Plaid_Tartan_User_MFA_Answer1 = "tomato";

        [TestMethod]
        public async Task GetItem()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret, QF_Plaid_Public_Key);
            PlaidResult<ItemResponse> result = await plaidClient.GetItemAsync(Plaid_Sandbox_Access_Token);

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task ExchangeToken()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret, QF_Plaid_Public_Key);
            PlaidResult<AccessTokenResponse> result = await plaidClient.ExchangePublicTokenForAccessTokenAsync(Plaid_Sandbox_Public_Token);

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task GetInstitutions()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret, QF_Plaid_Public_Key);
            PlaidResult<ListOfInstitutionsWithTotalResponse> result = await plaidClient.GetListOfInstitutionsAsync(500, 0);

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task GetUsBank()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret, QF_Plaid_Public_Key);
            PlaidResult<ListOfInstitutionsResponse> result = await plaidClient.SearchInstitutions("us bank");

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task GetCategories()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret, QF_Plaid_Public_Key);
            PlaidResult<ListOfCategoriesResponse> result = await plaidClient.GetListOfCategoriesAsync();

            Assert.IsFalse(result.IsError);
        }

        /*public async Task<AddUserResult> AuthenticateUser()
        {
            //IPlaidClient plaidClient = new HttpPlaidClient(new Uri("https://sandbox.plaid.com"), "59595c954e95b8407ec699a6", "eee289a23a202e5e1ad397a2cac0e9");
            //IPlaidClient plaidClient = new HttpPlaidClient(new Uri("https://tartan.plaid.com"), "59595c954e95b8407ec699a6", "eee289a23a202e5e1ad397a2cac0e9");

            //create the PlaidClient with the Client_ID and Client_Secret
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Tartan_URL), Plaid_Tartan_Client_ID, Plaid_Tartan_Client_Secret);

            //Add User which actually just means attempt to Authenticate a user with the user name, password, and institution
            AddUserResult toReturn = await plaidClient.AddUserAsync(Plaid_Tartan_Username, Plaid_Tartan_User_Password, InstitutionType.UsBank);

            //Assertions
            Assert.IsNotNull(toReturn);
            Assert.IsFalse(toReturn.IsError);
            Assert.IsNotNull(toReturn.AccessToken);

            //return
            return toReturn;
        }

        [TestMethod]
        public async Task GetNewPublicToken()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret);
            //TokenExchangeResult result = await plaidClient.ExchangeTokenAsync("public-sandbox-"+QF_Plaid_Public_Key);
            TokenExchangeResult result = await plaidClient.GetNewPublicTokenAsync("access-sandbox-"+QF_Plaid_Public_Key);

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task ExchangeToken()
        {
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret);
            //TokenExchangeResult result = await plaidClient.ExchangeTokenAsync("public-sandbox-"+QF_Plaid_Public_Key);
            TokenExchangeResult result = await plaidClient.ExchangeTokenAsync(Plaid_Sandbox_Public_Key);

            Assert.IsFalse(result.IsError);
        }

        [TestMethod]
        public async Task AuthenticateUserGetAccounts()
        {
            //IPlaidClient plaidClient = new HttpPlaidClient(new Uri("https://sandbox.plaid.com"), "59595c954e95b8407ec699a6", "eee289a23a202e5e1ad397a2cac0e9");
            //IPlaidClient plaidClient = new HttpPlaidClient(new Uri("https://tartan.plaid.com"), "59595c954e95b8407ec699a6", "eee289a23a202e5e1ad397a2cac0e9");

            //Add User which actually just means attempt to Authenticate a user with the user name, password, and institution
            AddUserResult result = await AuthenticateUser();

            //Assertions
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsError);
            Assert.IsNotNull(result.AccessToken);

            //Multi-Factor Authentication
            if (result.IsMfaRequired && result.AuthPrompt != null)
            {
                Console.WriteLine("---Start MFA Questions---");
                foreach (string question in result.AuthPrompt.Questions)
                {
                    Console.WriteLine(question);
                }
                Console.WriteLine("---End MFA Questions---");
                Console.WriteLine();
            }

            //create the PlaidClient with the Client_ID and Client_Secret
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Tartan_URL), Plaid_Tartan_Client_ID, Plaid_Tartan_Client_Secret);

            //authenticate user using the access token and the default answer of tomato
            AddUserResult mfaResult = await plaidClient.AuthenticateUserAsync(result.AccessToken, false, ApiType.Connect, new string[] { Plaid_Tartan_User_MFA_Answer1 });

            //Assertions
            Assert.IsNotNull(mfaResult);
            Assert.IsFalse(mfaResult.IsError);
            Assert.IsNotNull(mfaResult.AccessToken);
            Assert.IsFalse(mfaResult.IsMfaRequired);
            Assert.IsNotNull(mfaResult.Accounts);

            //Accounts
            Console.WriteLine("---Start Account Listing---");
            foreach (Account acc in mfaResult.Accounts)
            {

                Console.WriteLine();
                Console.WriteLine("-Start Account-");
                Console.WriteLine("User ID: " + acc.UserId);
                Console.WriteLine("Account ID: " + acc.Id);
                Console.WriteLine("Item ID: " + acc.ItemId);
                Console.WriteLine("Institution Type: " + acc.InstitutionType);
                Console.WriteLine("Account Type: " + acc.AccountType);
                Console.WriteLine("Account Subtype: " + acc.AccountSubtype);
                Console.WriteLine("Available Balance: " + acc.AvailableBalance);
                Console.WriteLine("Current Balance: " + acc.CurrentBalance);
                Console.WriteLine("-End Account-");
            }
            Console.WriteLine("---End Account Listing---");
            Console.WriteLine();

            TransactionResult transactionResult = await plaidClient.GetTransactionsAsync(mfaResult.AccessToken);

            Console.WriteLine();
            Console.WriteLine("---Start Transaction Listing---");
            foreach (Transaction trans in transactionResult.Transactions)
            {
                Console.WriteLine();
                Console.WriteLine("-Start Transaction-");
                Console.WriteLine("Name: " + trans.Name);

                if (trans.Categories != null)
                {
                    string category = string.Empty;
                    foreach (string cat in trans.Categories)
                    {
                        category += cat + ", ";
                    }
                    Console.WriteLine("Category: " + category);
                }
                
                Console.WriteLine("Street: " + trans.Location.Street);
                Console.WriteLine("City: " + trans.Location.City);
                Console.WriteLine("State: " + trans.Location.State);

                Console.WriteLine("Amount: " + string.Format("{0:c}", trans.Amount));
                Console.WriteLine("-End Transaction-");
            }
            Console.WriteLine("---End Transaction Listing---");
        }

        [TestMethod]
        public async Task GetCategories()
        {
            //create the PlaidClient with the Client_ID and Client_Secret
            //IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Tartan_URL), Plaid_Tartan_Client_ID, Plaid_Tartan_Client_Secret);
            IPlaidClient plaidClient = new HttpPlaidClient(new Uri(Plaid_Sandbox_URL), QF_Plaid_Client_ID, QF_Plaid_Client_Secret);

            //get the categories
            var categoriesResult = await plaidClient.GetCategoriesAsync();

            //Assertions
            Assert.IsNotNull(categoriesResult);
            Assert.IsFalse(categoriesResult.IsError);
            Assert.IsNotNull(categoriesResult.Value);

            //print the categories
            Console.WriteLine("---Start Categories---");
            foreach (Category cat in categoriesResult.Value)
            {
                String line = String.Empty;
                foreach (string s in cat.Hierarchy)
                {
                    line += s + ", ";
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("---End Categories---");
            Console.WriteLine("");
        }*/
    }
}
