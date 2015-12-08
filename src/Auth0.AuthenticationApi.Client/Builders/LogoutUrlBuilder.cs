using JetBrains.Annotations;

namespace Auth0.AuthenticationApi.Client.Builders
{
    public class LogoutUrlBuilder : UrlBuilderBase<LogoutUrlBuilder>
    {
        public LogoutUrlBuilder(string baseUrl) 
            : base(baseUrl, "logout")
        {
        }

        public LogoutUrlBuilder WithReturnUrl(string url)
        {
            AddQueryString("returnTo", url);

            return this;
        }
    }
}