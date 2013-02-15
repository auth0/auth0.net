.Net client library for the Auth0 platform.

## Installation

    Install-Package Auth0

## Usage

Initialize your client class with the credentials in the [settings section](https://app.auth0.com/#/settings) of the dashboard.

~~~csharp
var client = new Auth0.Client(
  clientID:     'your-client-id',
  clientSecret: 'your-client-secret'
  domain:       'yourdomain.auth0.com'
);
~~~

### client.getConnections(callback)

Return a list of all the connections in your application:

~~~csharp
var connections = client.GetConnections();
~~~

Returns an IEnumerable<Connection>. Additionally there is a ```GetSocialConnections``` and ```GetEnterpriseConnections```.

### client.CreateConnection(Connection)

Let's say one of your customers wants to use its own directory to authenticate to your app. You will have to create a **connection** in Auth0 for this customer and if you want to automate that for N customers, you will want to use the API. Typically, you will ask the customer domain name and depending on the directory you are connecting to, some metadata.

~~~csharp
var connectionTicket =  new Auth0.Connection("office365", "contoso.com");

var newConnection = client.createConnection(connectionTicket);

newConnection //will have ProvisioningTicketUrl 
~~~

Because this example uses Office 365, the returned connection object will have a ```ProvisioningTicketUrl``` property to which you have to redirect the client in order to complete the authorization process.

### client.GetUsersByConnection(connectionName)

This method returns a list of users of the connection.

It will search the users on the directory of the connection. Suppose it is a **Windows Azure Active Directory** connection it will fetch all the users from the directory. If the connection doesn't have a directory or it is a Social connection like **Google OAuth 2** it will return all the users that have logged in to your application at least once.

~~~csharp
var users = client.GetUsers('contoso.com'});
~~~

The result is an IEnumerable<Auth0.User>.


### client.GetSocialUsers()

The same than ```GetUsersByConnection``` but this method returns users for all social connections ie: not enterprise connections.

## Authentication

This library is useful to consume the http api of Auth0, in order to authenticate users you can use the our [DotNetOpenAuth client](https://github.com/auth0/aspnet-auth0). 

## Documentation

For more information about [auth0](http://auth0.com) visit our [documentation page](http://docs.auth0.com/).

## License

This client library is MIT licensed.