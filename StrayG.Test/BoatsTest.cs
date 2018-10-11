using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using StrayG.Boats;
using StrayG.Boats.Data.Results;
using StrayG.Boats.Data.Contracts.Responses;

namespace StrayG.Test
{
    [TestClass]
    public class BoatsTest
    {
        [TestMethod]
        public async Task ItemSearch()
        {
            IBoatsClient boatsClient = new HttpBoatsClient();
            BoatsResult<ItemLookupResponse> result = await boatsClient.ItemLookupAsync("12417832");

            Assert.IsFalse(result.IsError);
        }
    }
}
