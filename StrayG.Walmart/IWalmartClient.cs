using StrayG.Walmart.Data.Contracts.Response;
using StrayG.Walmart.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Walmart
{
    public interface IWalmartClient
    {
        #region Getting Pertinent Information
        /// <summary>
        /// Gets the Uri that the WalmartClient is working with.
        /// </summary>
        /// <returns>Service uri.</returns>
        Uri GetServiceUri();
        #endregion Getting Pertinent Information

        Task<WalmartResult<ItemLookupResponse>> ItemLookupAsync(string itemIDs, string[] upcs);
    }
}
