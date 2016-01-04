# Auth0 + ASP.NET WebAPI Seed
This is the seed project you need to use if you're going to create an ASP.NET WebAPI application.

This example is deployed in an Azure Web Site at https://auth0-aspnet-webapi.azurewebsites.net.

#Running the example
In order to run the example you need to have Visual Studio 2013 installed.

Install package Auth0.ASPNET via Package Manager or running the following command:

```Powershell
Install-Package Auth0-ASPNET
```

You also need to set the ClientSecret and ClientId of your Auth0 app in the web.config file. To do that just find the following lines and modify accordingly:
```CSharp
<add key="Auth0ClientID" value="{CLIENT_ID}"/>
<add key="Auth0ClientSecret" value="{CLIENT_SECRET}"/>
```

Run `Install-Package Microsoft.AspNet.WebApi.Cors` from VS2013's package manager console.


After that just press **F5** to run the application. It will start running in port **3001**. If you browse to [http://localhost:3001/ping](http://localhost:3001/ping) you should receive a response message.