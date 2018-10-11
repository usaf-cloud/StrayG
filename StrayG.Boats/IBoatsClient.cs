namespace StrayG.Boats
{
    using StrayG.Boats.Data.Contracts.Responses;
    using StrayG.Boats.Data.Results;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The BoatsClient interface.
    /// </summary>
    public interface IBoatsClient
    {
        #region Getting Pertinent Information
        /// <summary>
        /// Gets the Uri that the BoatsClient is working with.
        /// </summary>
        /// <returns>Service uri.</returns>
        Uri GetServiceUri();
        #endregion Getting Pertinent Information

        Task<BoatsResult<ItemLookupResponse>> ItemLookupAsync(string itemID);
    }
}
