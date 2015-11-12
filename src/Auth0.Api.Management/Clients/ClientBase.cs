namespace Auth0.Api.Management.Clients
{
    public class ClientBase
    {
        protected IApiConnection Connection { get; }

        public ClientBase(IApiConnection connection)
        {
            Connection = connection;
        }
    }
}