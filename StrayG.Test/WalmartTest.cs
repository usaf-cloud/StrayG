using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using StrayG.Walmart;
using StrayG.Walmart.Data.Results;
using StrayG.Walmart.Data.Contracts.Response;

namespace StrayG.Test
{
    [TestClass]
    public class WalmartTest
    {
        [TestMethod]
        public async Task ItemSearch()
        {
            IWalmartClient walmartClient = new HttpWalmartClient();
            WalmartResult<ItemLookupResponse> result = await walmartClient.ItemLookupAsync("12417832,19336123", null);
            //WalmartResult<ItemLookupResponse> result = await walmartClient.ItemLookupAsync("12417832", null);

            Assert.IsFalse(result.IsError);
        }
    }
}
