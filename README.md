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

## Authentication

This library is useful to consume the http api of Auth0, in order to authenticate users you can use the our [DotNetOpenAuth client](https://github.com/auth0/auth0-aspnet). 

## Documentation

For more information about [auth0](http://auth0.com) visit our [documentation page](http://docs.auth0.com/).

## License

This client library is MIT licensed.
