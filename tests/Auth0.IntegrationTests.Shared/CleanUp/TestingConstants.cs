namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class TestingConstants
    {
        private static readonly string Suffix = "int-test";

        public static string ActionPrefix = $"{Suffix}";
        public static string RulesRefix = $"{Suffix}";
        public static string ClientPrefix = $"{Suffix}";
        public static string ConnectionPrefix = $"{Suffix}";
        public static string HooksPrefix = $"{Suffix}";
        public static string ResourceServerPrefix = $"{Suffix}";
        public static string OrganizationPrefix = $"{Suffix}";
        public static string UserEmailDomain = $"{Suffix}@nonexistingdomain.aaa";
    }
}