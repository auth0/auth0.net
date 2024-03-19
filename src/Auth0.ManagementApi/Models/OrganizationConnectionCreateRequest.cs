﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationConnectionCreateRequest
    {
        /// <summary>
        /// ID of the connection.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Whether or not users that login will automatically be granted membership to the organization.
        /// </summary>
        [JsonProperty("assign_membership_on_login")]
        public bool AssignMembershipOnLogin { get; set; }

        /// <summary>
        /// Determines whether a connection should be displayed on this organization’s login prompt.
        /// </summary>
        [JsonProperty("show_as_button")]
        public bool? ShowAsButton { get; set; }
    }
}
