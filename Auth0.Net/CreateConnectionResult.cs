namespace Auth0
{
    public class CreateConnectionResult
    {
        public bool worked { get; set; }
        public string provisioning_ticket_url { get; set; }
        public string error { get; set; }
    }
}