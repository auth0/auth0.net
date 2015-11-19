namespace Api.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    
    public class JsonWebTokenValidationHandler : DelegatingHandler
    {
        public string SymmetricKey { get; set; }

        public string Audience { get; set; }
        
        public string Issuer { get; set; }

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;

            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                // Fail if no Authorization header or more than one Authorization headers  
                // are found in the HTTP request  
                return false;
            }

            // Remove the bearer token scheme prefix and return the rest as ACS token  
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;

            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token;
            HttpResponseMessage errorResponse = null;

            if (TryRetrieveToken(request, out token))
            {
                try
                {
                    var secret = this.SymmetricKey.Replace('-', '+').Replace('_', '/');

                    Thread.CurrentPrincipal = JsonWebToken.ValidateToken(
                        token,
                        secret,
                        audience: this.Audience,
                        checkExpiration: true,
                        issuer: this.Issuer);
                    
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = Thread.CurrentPrincipal;
                    }
                }
                catch (JWT.SignatureVerificationException ex)
                {
                    errorResponse = request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex);
                }
                catch (JsonWebToken.TokenValidationException ex)
                {
                    errorResponse = request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex);
                }
                catch (Exception ex)
                {
                    errorResponse = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }

            return errorResponse != null ?
                Task.FromResult(errorResponse) :
                base.SendAsync(request, cancellationToken);
        }
    }
}
