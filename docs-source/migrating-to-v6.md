# Migration Guide

## Migrating from v5 to v6

Various breaking changes to the management API exist in v6. They are as follows:

### Removal of non-paging GetAll methods

Previously various Auth0 management endpoints were exposed with GetAll methods that did not take a PagingInfo parameter.  These have been deprecated server-side and most were marked as `[Obsolete]` in v5.

Now, in v6 those methods have been removed entirely.  If you were previously calling a Client class's GetAll method without thinking about paging you should now consider how you want to handle pages of results in your application and use the equivalent overload with a PagingInfo parameter.

### Removal of IManagementApi interface

This interface was removed as adding new endpoints such as Roles and Guardian - now in v6 - are a breaking change because we need to add them both to our concrete ManagementApi class *and* the IManagementApi interface.  As this library is a concrete implementation of calling the Auth0 management APIs and not a general abstraction layer over management this interface served no purpose.  

It has therefore been removed.

### Removal of I*Client interfaces

Each management client - e.g. UsersClient - had an equivalent IUserClient interface that replicated the API signature and in a lot of cases the XML documentation.

Again, having this interface means that as Auth0 add server endpoints we break the interface contract every single time.

This is again, unacceptable given the purpose of this SDK and so these interfaces have been removed.
