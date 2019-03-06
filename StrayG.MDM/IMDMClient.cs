using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrayG.MDM
{
    public interface IMDMClient
    {
        #region Getting Pertinent Information
        /// <summary>
        /// Gets the Uri that the MDMClient is working with.
        /// </summary>
        /// <returns>Service uri.</returns>
        Uri GetServiceUri();
        #endregion Getting Pertinent Information

    }
}