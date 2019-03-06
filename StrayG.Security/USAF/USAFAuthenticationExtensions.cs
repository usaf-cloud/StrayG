using System;
using StrayG.Security.USAF;

namespace Owin
{
    /// <summary>
    /// Extension methods for using <see cref="USAFOAuth2AuthenticationMiddleware"/>
    /// </summary>
    public static class USAFAuthenticationExtensions
    {
        /// <summary>
        /// Authenticate users using USAF OAuth 2.0
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="options">Middleware configuration options</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
            Justification = "OAuth2 is a valid word.")]
        public static IAppBuilder UseUSAFAuthentication(this IAppBuilder app, USAFOAuth2AuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(USAFOAuth2AuthenticationMiddleware), app, options);
            return app;
        }

        /// <summary>
        /// Authenticate users using USAF OAuth 2.0
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="clientId">The USAF assigned client id</param>
        /// <param name="clientSecret">The USAF assigned client secret</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
            Justification = "OAuth2 is a valid word.")]
        public static IAppBuilder UseUSAFAuthentication(
            this IAppBuilder app,
            string clientId,
            string clientSecret)
        {
            return UseUSAFAuthentication(
                app,
                new USAFOAuth2AuthenticationOptions
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                });
        }
    }
}
