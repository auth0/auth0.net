using System;
using System.Configuration;

namespace Auth0.AuthenticationApi.Client.IntegrationTests
{
    public class TestBase
    {
        protected bool IsRunningUnderAppVeyorCi()
        {
            bool isAppVeyor = Environment.GetEnvironmentVariable("APPVEYOR") == "True";
            bool IsCi = Environment.GetEnvironmentVariable("CI") == "True";

            return isAppVeyor && IsCi;
        }
        protected string GetVariable(string variableName)
        {
            // Check to see whether we are running inside AopVeyor CI environment
            if (IsRunningUnderAppVeyorCi())
                return Environment.GetEnvironmentVariable(variableName);

            // By default return variable from config file
            return ConfigurationManager.AppSettings[variableName];
        }
    }
}