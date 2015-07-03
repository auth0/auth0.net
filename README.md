.Net client library for the Auth0 platform.

## Installation

    Install-Package Auth0

## Usage

Create an instance of Client with the credentials provided in the [settings section](https://app.auth0.com/#/settings) of the dashboard.

~~~csharp
var client = new Auth0.Client(
  clientID:     "your-client-id",
  clientSecret: "your-client-secret",
  domain:       "yourdomain.auth0.com"
);
~~~

### client.GetConnections()

Return a list of all the connections in your application:

~~~csharp
var connections = client.GetConnections();
~~~

Returns an IEnumerable<Connection>. Additionally there is a ```GetSocialConnections``` and ```GetEnterpriseConnections```.

### client.CreateConnection(connection)

Let's say one of your customers wants to use its own directory to authenticate to your app. You will have to create a **connection** in Auth0 for this customer and if you want to automate that for N customers, you will want to use the API. Typically, you will ask the customer domain name and depending on the directory you are connecting to, some metadata.

~~~csharp
var connectionTicket =  new Auth0.Connection("office365", "contoso.com");

var newConnection = client.CreateConnection(connectionTicket);

// newConnection will have ProvisioningTicketUrl
~~~

Because this example uses Office 365, the returned connection object will have a ```ProvisioningTicketUrl``` property to which you have to redirect the client in order to complete the authorization process.

### client.CreateConnection(provisioningTicket)

Create connection using a provisioning ticket.

~~~csharp
var newConnection = client.CreateConnection(provisioningTicket);
~~~

### client.DeleteConnection(string connectionName)

Delete a connection identified by connectionName.

~~~csharp
client.DeleteConnection(connectionName);
~~~

### client.GetUsersByConnection(connectionName, search = "")

This method returns a list of users of the connection.

It will search the users on the directory of the connection. Suppose it is a **Windows Azure Active Directory** connection it will fetch all the users from the directory. If the connection doesn't have a directory or it is a Social connection like **Google OAuth 2** it will return all the users that have logged in to your application at least once.

~~~csharp
var users = client.GetUsersByConnection("contoso.com");
// or
var users = client.GetUsersByConnection("contoso.com", "jdoe");
~~~

The result is an IEnumerable<Auth0.User>.

### client.GetSocialUsers(search = "")

The same than ```GetUsersByConnection``` but this method returns users for all social connections ie: not enterprise connections.

~~~csharp
var users = client.GetSocialUsers("mary@gmail.com");
// or
var users = client.GetSocialUsers();
~~~

### client.GetEnterpriseUsers(search = "")

The same than ```GetUsersByConnection``` but this method returns users for all enterprise connections ie: not social connections.

~~~csharp
var users = client.GetEnterpriseUsers("jdoe@contoso.com");
// or
var users = client.GetEnterpriseUsers();
~~~

### client.GenerateVerificationTicket(userId, resultUrl = "")

Generate an email verification link which can be added to custom emails an be used for email verification. Clicking this link will set ```email_verified``` to true for the user and optionally redirect to a page in the application.

~~~csharp
var verificationUrl = client.GenerateVerificationTicket("auth0|54c6322f6936d15310dca942");
// or
var verificationUrl = client.GenerateVerificationTicket("auth0|54c6322f6936d15310dca942",
   "http://myapp.com/activated");
~~~

### client.ValidateUser(username, password, connection)

Verify if the username and password are correct for a given connection.

~~~csharp
var validationResult = client.ValidateUser("some@user.com", "Passw0rd!", "Username-Password-Authentication");
if (validationResult.IsValid)
{
    return "User is valid.";
}
else
{
    return "Invalid user. Details: " + validationResult.Message;
}
~~~

## Diagnostic Headers

By default this SDK will send the diagnostic HTTP request header `Auth0-Client` to the Auth0 REST API.  The header contains information about the version of the SDK, its dependencies, and the execution environment.

If you do not wish to pass this header, you can opt out by passing the `DiagnosticsHeader.Suppress` instance to the `diagnostics` `Auth0.Client` constructor parameter:

~~~csharp
var client = new Auth0.Client(
  clientID:     "your-client-id",
  clientSecret: "your-client-secret",
  domain:       "yourdomain.auth0.com",
  //suppress the Auth0-Client header
  diagnostics: Auth0.DiagnosticsHeader.Suppress
);
~~~

Alternatively, if you'd like to pass additional diagnostic information to Auth0 you can easily add environment information using the `DiagnosticsHeader.Default` instance:

~~~csharp
var client = new Auth0.Client(
  clientID:     "your-client-id",
  clientSecret: "your-client-secret",
  domain:       "yourdomain.auth0.com",
  //the AddEnvironment method takes a name and a version
  diagnostics: Auth0.DiagnosticsHeader.Default
    .AddEnvironment("SharePoint", "2010")
    .AddEnvironment("VMWare ESXi", "6.0")
);
~~~

## Authentication

This library is useful to consume the http api of Auth0, in order to authenticate users you can use our platform specific SDKs:
* [ASP.NET OWIN](https://github.com/auth0/auth0-aspnet-owin)
* [ASP.NET](https://github.com/auth0/auth0-aspnet)
* [Winforms or WPF](https://github.com/auth0/Auth0.WinformsWPF)
* [Windows Phone](https://github.com/auth0/Auth0.WindowsPhone)
* [Windows 8 C#](https://github.com/auth0/Auth0.Windows8.Cs)
* [Windows 8 JS](https://github.com/auth0/Auth0.Windows8.Js)
* [WCF](https://docs.auth0.com/wcf-tutorial)

## Documentation

For more information about [auth0](http://auth0.com) visit our [documentation page](http://docs.auth0.com/).

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## Author

[Auth0](auth0.com)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE.txt) file for more info.
