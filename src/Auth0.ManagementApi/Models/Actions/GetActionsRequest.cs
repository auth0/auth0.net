namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for retrieving all actions.
    /// </summary>
    public class GetActionsRequest
    {
        /// <summary>
        /// An actions extensibility point.
        /// </summary>
        public string TriggerId { get; set; }

        /// <summary>
        /// The name of the action to retrieve.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        ///  Optional filter to only retrieve actions that are deployed.
        /// </summary>
        public bool? Deployed { get; set; }

        /// <summary>
        /// Optional. When true, return only installed actions. When false, return only custom actions. Returns all actions by default.
        /// </summary>
        public bool? Installed { get; set; }
    }
}