using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace StrayG.Security.USAF.Provider
{
    /// <summary>
    /// Provides context information to middleware providers.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
        Justification = "OAuth2 is a valid word.")]
    public class USAFOAuth2ReturnEndpointContext : ReturnEndpointContext
    {
        /// <summary>
        /// Initialize a <see cref="USAFOAuth2ReturnEndpointContext"/>
        /// </summary>
        /// <param name="context">OWIN environment</param>
        /// <param name="ticket">The authentication ticket</param>
        public USAFOAuth2ReturnEndpointContext(
            IOwinContext context,
            AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }
    }
}
