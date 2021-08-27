namespace Auth0.ManagementApi.Actions
{
    public class GetActionsRequest
    {
        public string TriggerId { get; set; }
        public string ActionName { get; set; }
        public bool? Deployed { get; set; }
        public bool? Installed { get; set; }
    }
}