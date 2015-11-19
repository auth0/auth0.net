namespace Auth0.ManagementApi.Client.Clients
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