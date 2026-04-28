// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The JSON payload delivered in each SSE data line. The type field is injected from the SSE event field by the SDK. Discriminated by type: an event type name for events, "error" for errors, and "offset-only" for cursor-only heartbeats.
/// </summary>
[JsonConverter(typeof(EventStreamSubscribeEventsResponseContent.JsonConverter))]
[Serializable]
public record EventStreamSubscribeEventsResponseContent
{
    internal EventStreamSubscribeEventsResponseContent(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupCreated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupCreated value
    )
    {
        Type = "group.created";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupDeleted value
    )
    {
        Type = "group.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupMemberAdded"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupMemberAdded value
    )
    {
        Type = "group.member.added";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupMemberDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupMemberDeleted value
    )
    {
        Type = "group.member.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupRoleAssigned"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupRoleAssigned value
    )
    {
        Type = "group.role.assigned";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupRoleDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupRoleDeleted value
    )
    {
        Type = "group.role.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.GroupUpdated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupUpdated value
    )
    {
        Type = "group.updated";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationConnectionAdded"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionAdded value
    )
    {
        Type = "organization.connection.added";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationConnectionRemoved"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionRemoved value
    )
    {
        Type = "organization.connection.removed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationConnectionUpdated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionUpdated value
    )
    {
        Type = "organization.connection.updated";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationCreated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationCreated value
    )
    {
        Type = "organization.created";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationDeleted value
    )
    {
        Type = "organization.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleAssigned"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleAssigned value
    )
    {
        Type = "organization.group.role.assigned";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleDeleted value
    )
    {
        Type = "organization.group.role.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationMemberAdded"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberAdded value
    )
    {
        Type = "organization.member.added";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationMemberDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberDeleted value
    )
    {
        Type = "organization.member.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleAssigned"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleAssigned value
    )
    {
        Type = "organization.member.role.assigned";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleDeleted value
    )
    {
        Type = "organization.member.role.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OrganizationUpdated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationUpdated value
    )
    {
        Type = "organization.updated";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.UserCreated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserCreated value
    )
    {
        Type = "user.created";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.UserDeleted"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserDeleted value
    )
    {
        Type = "user.deleted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.UserUpdated"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserUpdated value
    )
    {
        Type = "user.updated";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.Error"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.Error value
    )
    {
        Type = "error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventStreamSubscribeEventsResponseContent with <see cref="EventStreamSubscribeEventsResponseContent.OffsetOnly"/>.
    /// </summary>
    public EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OffsetOnly value
    )
    {
        Type = "offset-only";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.created"
    /// </summary>
    public bool IsGroupCreated => Type == "group.created";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.deleted"
    /// </summary>
    public bool IsGroupDeleted => Type == "group.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.member.added"
    /// </summary>
    public bool IsGroupMemberAdded => Type == "group.member.added";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.member.deleted"
    /// </summary>
    public bool IsGroupMemberDeleted => Type == "group.member.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.role.assigned"
    /// </summary>
    public bool IsGroupRoleAssigned => Type == "group.role.assigned";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.role.deleted"
    /// </summary>
    public bool IsGroupRoleDeleted => Type == "group.role.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "group.updated"
    /// </summary>
    public bool IsGroupUpdated => Type == "group.updated";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.connection.added"
    /// </summary>
    public bool IsOrganizationConnectionAdded => Type == "organization.connection.added";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.connection.removed"
    /// </summary>
    public bool IsOrganizationConnectionRemoved => Type == "organization.connection.removed";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.connection.updated"
    /// </summary>
    public bool IsOrganizationConnectionUpdated => Type == "organization.connection.updated";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.created"
    /// </summary>
    public bool IsOrganizationCreated => Type == "organization.created";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.deleted"
    /// </summary>
    public bool IsOrganizationDeleted => Type == "organization.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.group.role.assigned"
    /// </summary>
    public bool IsOrganizationGroupRoleAssigned => Type == "organization.group.role.assigned";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.group.role.deleted"
    /// </summary>
    public bool IsOrganizationGroupRoleDeleted => Type == "organization.group.role.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.member.added"
    /// </summary>
    public bool IsOrganizationMemberAdded => Type == "organization.member.added";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.member.deleted"
    /// </summary>
    public bool IsOrganizationMemberDeleted => Type == "organization.member.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.member.role.assigned"
    /// </summary>
    public bool IsOrganizationMemberRoleAssigned => Type == "organization.member.role.assigned";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.member.role.deleted"
    /// </summary>
    public bool IsOrganizationMemberRoleDeleted => Type == "organization.member.role.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "organization.updated"
    /// </summary>
    public bool IsOrganizationUpdated => Type == "organization.updated";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user.created"
    /// </summary>
    public bool IsUserCreated => Type == "user.created";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user.deleted"
    /// </summary>
    public bool IsUserDeleted => Type == "user.deleted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user.updated"
    /// </summary>
    public bool IsUserUpdated => Type == "user.updated";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "error"
    /// </summary>
    public bool IsError => Type == "error";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "offset-only"
    /// </summary>
    public bool IsOffsetOnly => Type == "offset-only";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreated"/> if <see cref="Type"/> is 'group.created', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.created'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreated AsGroupCreated() =>
        IsGroupCreated
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.created'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeleted"/> if <see cref="Type"/> is 'group.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeleted AsGroupDeleted() =>
        IsGroupDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded"/> if <see cref="Type"/> is 'group.member.added', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.member.added'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded AsGroupMemberAdded() =>
        IsGroupMemberAdded
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.member.added'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted"/> if <see cref="Type"/> is 'group.member.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.member.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted AsGroupMemberDeleted() =>
        IsGroupMemberDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.member.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned"/> if <see cref="Type"/> is 'group.role.assigned', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.role.assigned'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned AsGroupRoleAssigned() =>
        IsGroupRoleAssigned
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.role.assigned'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted"/> if <see cref="Type"/> is 'group.role.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.role.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted AsGroupRoleDeleted() =>
        IsGroupRoleDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.role.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdated"/> if <see cref="Type"/> is 'group.updated', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'group.updated'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdated AsGroupUpdated() =>
        IsGroupUpdated
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'group.updated'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded"/> if <see cref="Type"/> is 'organization.connection.added', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.connection.added'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded AsOrganizationConnectionAdded() =>
        IsOrganizationConnectionAdded
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.connection.added'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved"/> if <see cref="Type"/> is 'organization.connection.removed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.connection.removed'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved AsOrganizationConnectionRemoved() =>
        IsOrganizationConnectionRemoved
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.connection.removed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated"/> if <see cref="Type"/> is 'organization.connection.updated', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.connection.updated'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated AsOrganizationConnectionUpdated() =>
        IsOrganizationConnectionUpdated
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.connection.updated'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgCreated"/> if <see cref="Type"/> is 'organization.created', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.created'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgCreated AsOrganizationCreated() =>
        IsOrganizationCreated
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgCreated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.created'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgDeleted"/> if <see cref="Type"/> is 'organization.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgDeleted AsOrganizationDeleted() =>
        IsOrganizationDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned"/> if <see cref="Type"/> is 'organization.group.role.assigned', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.group.role.assigned'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned AsOrganizationGroupRoleAssigned() =>
        IsOrganizationGroupRoleAssigned
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.group.role.assigned'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted"/> if <see cref="Type"/> is 'organization.group.role.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.group.role.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted AsOrganizationGroupRoleDeleted() =>
        IsOrganizationGroupRoleDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.group.role.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded"/> if <see cref="Type"/> is 'organization.member.added', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.member.added'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded AsOrganizationMemberAdded() =>
        IsOrganizationMemberAdded
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.member.added'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted"/> if <see cref="Type"/> is 'organization.member.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.member.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted AsOrganizationMemberDeleted() =>
        IsOrganizationMemberDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.member.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned"/> if <see cref="Type"/> is 'organization.member.role.assigned', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.member.role.assigned'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned AsOrganizationMemberRoleAssigned() =>
        IsOrganizationMemberRoleAssigned
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.member.role.assigned'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted"/> if <see cref="Type"/> is 'organization.member.role.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.member.role.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted AsOrganizationMemberRoleDeleted() =>
        IsOrganizationMemberRoleDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.member.role.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgUpdated"/> if <see cref="Type"/> is 'organization.updated', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'organization.updated'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgUpdated AsOrganizationUpdated() =>
        IsOrganizationUpdated
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgUpdated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'organization.updated'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreated"/> if <see cref="Type"/> is 'user.created', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user.created'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreated AsUserCreated() =>
        IsUserCreated
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'user.created'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeleted"/> if <see cref="Type"/> is 'user.deleted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user.deleted'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeleted AsUserDeleted() =>
        IsUserDeleted
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeleted)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'user.deleted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdated"/> if <see cref="Type"/> is 'user.updated', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user.updated'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdated AsUserUpdated() =>
        IsUserUpdated
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdated)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'user.updated'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventErrorMessage"/> if <see cref="Type"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'error'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventErrorMessage AsError() =>
        IsError
            ? (Auth0.ManagementApi.EventStreamCloudEventErrorMessage)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage"/> if <see cref="Type"/> is 'offset-only', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'offset-only'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage AsOffsetOnly() =>
        IsOffsetOnly
            ? (Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage)Value!
            : throw new global::System.Exception(
                "EventStreamSubscribeEventsResponseContent.Type is not 'offset-only'"
            );

    public T Match<T>(
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupCreated, T> onGroupCreated,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupDeleted, T> onGroupDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded, T> onGroupMemberAdded,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted, T> onGroupMemberDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned, T> onGroupRoleAssigned,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted, T> onGroupRoleDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventGroupUpdated, T> onGroupUpdated,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded,
            T
        > onOrganizationConnectionAdded,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved,
            T
        > onOrganizationConnectionRemoved,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated,
            T
        > onOrganizationConnectionUpdated,
        Func<Auth0.ManagementApi.EventStreamCloudEventOrgCreated, T> onOrganizationCreated,
        Func<Auth0.ManagementApi.EventStreamCloudEventOrgDeleted, T> onOrganizationDeleted,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned,
            T
        > onOrganizationGroupRoleAssigned,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted,
            T
        > onOrganizationGroupRoleDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded, T> onOrganizationMemberAdded,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted,
            T
        > onOrganizationMemberDeleted,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned,
            T
        > onOrganizationMemberRoleAssigned,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted,
            T
        > onOrganizationMemberRoleDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventOrgUpdated, T> onOrganizationUpdated,
        Func<Auth0.ManagementApi.EventStreamCloudEventUserCreated, T> onUserCreated,
        Func<Auth0.ManagementApi.EventStreamCloudEventUserDeleted, T> onUserDeleted,
        Func<Auth0.ManagementApi.EventStreamCloudEventUserUpdated, T> onUserUpdated,
        Func<Auth0.ManagementApi.EventStreamCloudEventErrorMessage, T> onError,
        Func<Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage, T> onOffsetOnly,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "group.created" => onGroupCreated(AsGroupCreated()),
            "group.deleted" => onGroupDeleted(AsGroupDeleted()),
            "group.member.added" => onGroupMemberAdded(AsGroupMemberAdded()),
            "group.member.deleted" => onGroupMemberDeleted(AsGroupMemberDeleted()),
            "group.role.assigned" => onGroupRoleAssigned(AsGroupRoleAssigned()),
            "group.role.deleted" => onGroupRoleDeleted(AsGroupRoleDeleted()),
            "group.updated" => onGroupUpdated(AsGroupUpdated()),
            "organization.connection.added" => onOrganizationConnectionAdded(
                AsOrganizationConnectionAdded()
            ),
            "organization.connection.removed" => onOrganizationConnectionRemoved(
                AsOrganizationConnectionRemoved()
            ),
            "organization.connection.updated" => onOrganizationConnectionUpdated(
                AsOrganizationConnectionUpdated()
            ),
            "organization.created" => onOrganizationCreated(AsOrganizationCreated()),
            "organization.deleted" => onOrganizationDeleted(AsOrganizationDeleted()),
            "organization.group.role.assigned" => onOrganizationGroupRoleAssigned(
                AsOrganizationGroupRoleAssigned()
            ),
            "organization.group.role.deleted" => onOrganizationGroupRoleDeleted(
                AsOrganizationGroupRoleDeleted()
            ),
            "organization.member.added" => onOrganizationMemberAdded(AsOrganizationMemberAdded()),
            "organization.member.deleted" => onOrganizationMemberDeleted(
                AsOrganizationMemberDeleted()
            ),
            "organization.member.role.assigned" => onOrganizationMemberRoleAssigned(
                AsOrganizationMemberRoleAssigned()
            ),
            "organization.member.role.deleted" => onOrganizationMemberRoleDeleted(
                AsOrganizationMemberRoleDeleted()
            ),
            "organization.updated" => onOrganizationUpdated(AsOrganizationUpdated()),
            "user.created" => onUserCreated(AsUserCreated()),
            "user.deleted" => onUserDeleted(AsUserDeleted()),
            "user.updated" => onUserUpdated(AsUserUpdated()),
            "error" => onError(AsError()),
            "offset-only" => onOffsetOnly(AsOffsetOnly()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreated> onGroupCreated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeleted> onGroupDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded> onGroupMemberAdded,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted> onGroupMemberDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned> onGroupRoleAssigned,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted> onGroupRoleDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdated> onGroupUpdated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded> onOrganizationConnectionAdded,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved> onOrganizationConnectionRemoved,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated> onOrganizationConnectionUpdated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgCreated> onOrganizationCreated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgDeleted> onOrganizationDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned> onOrganizationGroupRoleAssigned,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted> onOrganizationGroupRoleDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded> onOrganizationMemberAdded,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted> onOrganizationMemberDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned> onOrganizationMemberRoleAssigned,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted> onOrganizationMemberRoleDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgUpdated> onOrganizationUpdated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreated> onUserCreated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeleted> onUserDeleted,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdated> onUserUpdated,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventErrorMessage> onError,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage> onOffsetOnly,
        global::System.Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "group.created":
                onGroupCreated(AsGroupCreated());
                break;
            case "group.deleted":
                onGroupDeleted(AsGroupDeleted());
                break;
            case "group.member.added":
                onGroupMemberAdded(AsGroupMemberAdded());
                break;
            case "group.member.deleted":
                onGroupMemberDeleted(AsGroupMemberDeleted());
                break;
            case "group.role.assigned":
                onGroupRoleAssigned(AsGroupRoleAssigned());
                break;
            case "group.role.deleted":
                onGroupRoleDeleted(AsGroupRoleDeleted());
                break;
            case "group.updated":
                onGroupUpdated(AsGroupUpdated());
                break;
            case "organization.connection.added":
                onOrganizationConnectionAdded(AsOrganizationConnectionAdded());
                break;
            case "organization.connection.removed":
                onOrganizationConnectionRemoved(AsOrganizationConnectionRemoved());
                break;
            case "organization.connection.updated":
                onOrganizationConnectionUpdated(AsOrganizationConnectionUpdated());
                break;
            case "organization.created":
                onOrganizationCreated(AsOrganizationCreated());
                break;
            case "organization.deleted":
                onOrganizationDeleted(AsOrganizationDeleted());
                break;
            case "organization.group.role.assigned":
                onOrganizationGroupRoleAssigned(AsOrganizationGroupRoleAssigned());
                break;
            case "organization.group.role.deleted":
                onOrganizationGroupRoleDeleted(AsOrganizationGroupRoleDeleted());
                break;
            case "organization.member.added":
                onOrganizationMemberAdded(AsOrganizationMemberAdded());
                break;
            case "organization.member.deleted":
                onOrganizationMemberDeleted(AsOrganizationMemberDeleted());
                break;
            case "organization.member.role.assigned":
                onOrganizationMemberRoleAssigned(AsOrganizationMemberRoleAssigned());
                break;
            case "organization.member.role.deleted":
                onOrganizationMemberRoleDeleted(AsOrganizationMemberRoleDeleted());
                break;
            case "organization.updated":
                onOrganizationUpdated(AsOrganizationUpdated());
                break;
            case "user.created":
                onUserCreated(AsUserCreated());
                break;
            case "user.deleted":
                onUserDeleted(AsUserDeleted());
                break;
            case "user.updated":
                onUserUpdated(AsUserUpdated());
                break;
            case "error":
                onError(AsError());
                break;
            case "offset-only":
                onOffsetOnly(AsOffsetOnly());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreated"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupCreated(out Auth0.ManagementApi.EventStreamCloudEventGroupCreated? value)
    {
        if (Type == "group.created")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupDeleted(out Auth0.ManagementApi.EventStreamCloudEventGroupDeleted? value)
    {
        if (Type == "group.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupMemberAdded(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded? value
    )
    {
        if (Type == "group.member.added")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupMemberDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted? value
    )
    {
        if (Type == "group.member.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupRoleAssigned(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned? value
    )
    {
        if (Type == "group.role.assigned")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupRoleDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted? value
    )
    {
        if (Type == "group.role.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdated"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroupUpdated(out Auth0.ManagementApi.EventStreamCloudEventGroupUpdated? value)
    {
        if (Type == "group.updated")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationConnectionAdded(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded? value
    )
    {
        if (Type == "organization.connection.added")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationConnectionRemoved(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved? value
    )
    {
        if (Type == "organization.connection.removed")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationConnectionUpdated(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated? value
    )
    {
        if (Type == "organization.connection.updated")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgCreated"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationCreated(
        out Auth0.ManagementApi.EventStreamCloudEventOrgCreated? value
    )
    {
        if (Type == "organization.created")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgCreated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventOrgDeleted? value
    )
    {
        if (Type == "organization.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationGroupRoleAssigned(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned? value
    )
    {
        if (Type == "organization.group.role.assigned")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationGroupRoleDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted? value
    )
    {
        if (Type == "organization.group.role.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationMemberAdded(
        out Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded? value
    )
    {
        if (Type == "organization.member.added")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationMemberDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted? value
    )
    {
        if (Type == "organization.member.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationMemberRoleAssigned(
        out Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned? value
    )
    {
        if (Type == "organization.member.role.assigned")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationMemberRoleDeleted(
        out Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted? value
    )
    {
        if (Type == "organization.member.role.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgUpdated"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrganizationUpdated(
        out Auth0.ManagementApi.EventStreamCloudEventOrgUpdated? value
    )
    {
        if (Type == "organization.updated")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgUpdated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreated"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserCreated(out Auth0.ManagementApi.EventStreamCloudEventUserCreated? value)
    {
        if (Type == "user.created")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserCreated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeleted"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserDeleted(out Auth0.ManagementApi.EventStreamCloudEventUserDeleted? value)
    {
        if (Type == "user.deleted")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserDeleted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdated"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserUpdated(out Auth0.ManagementApi.EventStreamCloudEventUserUpdated? value)
    {
        if (Type == "user.updated")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserUpdated)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventErrorMessage"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out Auth0.ManagementApi.EventStreamCloudEventErrorMessage? value)
    {
        if (Type == "error")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventErrorMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage"/> and returns true if successful.
    /// </summary>
    public bool TryAsOffsetOnly(
        out Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage? value
    )
    {
        if (Type == "offset-only")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupCreated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupMemberAdded value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupMemberDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupRoleAssigned value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupRoleDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.GroupUpdated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionAdded value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionRemoved value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationConnectionUpdated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationCreated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleAssigned value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberAdded value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleAssigned value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OrganizationUpdated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserCreated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserDeleted value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.UserUpdated value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.Error value
    ) => new(value);

    public static implicit operator EventStreamSubscribeEventsResponseContent(
        EventStreamSubscribeEventsResponseContent.OffsetOnly value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamSubscribeEventsResponseContent>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(EventStreamSubscribeEventsResponseContent).IsAssignableFrom(typeToConvert);

        public override EventStreamSubscribeEventsResponseContent Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("type");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "group.created" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupCreated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupCreated"
                        ),
                "group.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupDeleted"
                        ),
                "group.member.added" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded"
                        ),
                "group.member.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted"
                        ),
                "group.role.assigned" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned"
                        ),
                "group.role.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted"
                        ),
                "group.updated" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventGroupUpdated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventGroupUpdated"
                        ),
                "organization.connection.added" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded"
                        ),
                "organization.connection.removed" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved"
                        ),
                "organization.connection.updated" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated"
                        ),
                "organization.created" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgCreated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgCreated"
                        ),
                "organization.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgDeleted"
                        ),
                "organization.group.role.assigned" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned"
                        ),
                "organization.group.role.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted"
                        ),
                "organization.member.added" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded"
                        ),
                "organization.member.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted"
                        ),
                "organization.member.role.assigned" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned"
                        ),
                "organization.member.role.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted"
                        ),
                "organization.updated" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOrgUpdated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOrgUpdated"
                        ),
                "user.created" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventUserCreated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventUserCreated"
                        ),
                "user.deleted" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventUserDeleted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventUserDeleted"
                        ),
                "user.updated" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventUserUpdated?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventUserUpdated"
                        ),
                "error" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventErrorMessage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventErrorMessage"
                        ),
                "offset-only" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new EventStreamSubscribeEventsResponseContent(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsResponseContent value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "group.created" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.member.added" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.member.deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.role.assigned" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.role.deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "group.updated" => JsonSerializer.SerializeToNode(value.Value, options),
                    "organization.connection.added" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.connection.removed" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.connection.updated" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.created" => JsonSerializer.SerializeToNode(value.Value, options),
                    "organization.deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "organization.group.role.assigned" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.group.role.deleted" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.member.added" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.member.deleted" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.member.role.assigned" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.member.role.deleted" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "organization.updated" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user.created" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user.deleted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "user.updated" => JsonSerializer.SerializeToNode(value.Value, options),
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "offset-only" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override EventStreamSubscribeEventsResponseContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new EventStreamSubscribeEventsResponseContent(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsResponseContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for group.created
    /// </summary>
    [Serializable]
    public struct GroupCreated
    {
        public GroupCreated(Auth0.ManagementApi.EventStreamCloudEventGroupCreated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupCreated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupCreated(
            Auth0.ManagementApi.EventStreamCloudEventGroupCreated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.deleted
    /// </summary>
    [Serializable]
    public struct GroupDeleted
    {
        public GroupDeleted(Auth0.ManagementApi.EventStreamCloudEventGroupDeleted value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupDeleted(
            Auth0.ManagementApi.EventStreamCloudEventGroupDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.member.added
    /// </summary>
    [Serializable]
    public struct GroupMemberAdded
    {
        public GroupMemberAdded(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupMemberAdded(
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAdded value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.member.deleted
    /// </summary>
    [Serializable]
    public struct GroupMemberDeleted
    {
        public GroupMemberDeleted(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupMemberDeleted(
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.role.assigned
    /// </summary>
    [Serializable]
    public struct GroupRoleAssigned
    {
        public GroupRoleAssigned(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupRoleAssigned(
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssigned value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.role.deleted
    /// </summary>
    [Serializable]
    public struct GroupRoleDeleted
    {
        public GroupRoleDeleted(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupRoleDeleted(
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for group.updated
    /// </summary>
    [Serializable]
    public struct GroupUpdated
    {
        public GroupUpdated(Auth0.ManagementApi.EventStreamCloudEventGroupUpdated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventGroupUpdated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.GroupUpdated(
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.connection.added
    /// </summary>
    [Serializable]
    public struct OrganizationConnectionAdded
    {
        public OrganizationConnectionAdded(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationConnectionAdded(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAdded value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.connection.removed
    /// </summary>
    [Serializable]
    public struct OrganizationConnectionRemoved
    {
        public OrganizationConnectionRemoved(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationConnectionRemoved(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionRemoved value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.connection.updated
    /// </summary>
    [Serializable]
    public struct OrganizationConnectionUpdated
    {
        public OrganizationConnectionUpdated(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationConnectionUpdated(
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.created
    /// </summary>
    [Serializable]
    public struct OrganizationCreated
    {
        public OrganizationCreated(Auth0.ManagementApi.EventStreamCloudEventOrgCreated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgCreated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationCreated(
            Auth0.ManagementApi.EventStreamCloudEventOrgCreated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.deleted
    /// </summary>
    [Serializable]
    public struct OrganizationDeleted
    {
        public OrganizationDeleted(Auth0.ManagementApi.EventStreamCloudEventOrgDeleted value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.group.role.assigned
    /// </summary>
    [Serializable]
    public struct OrganizationGroupRoleAssigned
    {
        public OrganizationGroupRoleAssigned(
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleAssigned(
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssigned value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.group.role.deleted
    /// </summary>
    [Serializable]
    public struct OrganizationGroupRoleDeleted
    {
        public OrganizationGroupRoleDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationGroupRoleDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.member.added
    /// </summary>
    [Serializable]
    public struct OrganizationMemberAdded
    {
        public OrganizationMemberAdded(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationMemberAdded(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberAdded value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.member.deleted
    /// </summary>
    [Serializable]
    public struct OrganizationMemberDeleted
    {
        public OrganizationMemberDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationMemberDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.member.role.assigned
    /// </summary>
    [Serializable]
    public struct OrganizationMemberRoleAssigned
    {
        public OrganizationMemberRoleAssigned(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleAssigned(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleAssigned value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.member.role.deleted
    /// </summary>
    [Serializable]
    public struct OrganizationMemberRoleDeleted
    {
        public OrganizationMemberRoleDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationMemberRoleDeleted(
            Auth0.ManagementApi.EventStreamCloudEventOrgMemberRoleDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for organization.updated
    /// </summary>
    [Serializable]
    public struct OrganizationUpdated
    {
        public OrganizationUpdated(Auth0.ManagementApi.EventStreamCloudEventOrgUpdated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOrgUpdated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OrganizationUpdated(
            Auth0.ManagementApi.EventStreamCloudEventOrgUpdated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user.created
    /// </summary>
    [Serializable]
    public struct UserCreated
    {
        public UserCreated(Auth0.ManagementApi.EventStreamCloudEventUserCreated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventUserCreated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.UserCreated(
            Auth0.ManagementApi.EventStreamCloudEventUserCreated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user.deleted
    /// </summary>
    [Serializable]
    public struct UserDeleted
    {
        public UserDeleted(Auth0.ManagementApi.EventStreamCloudEventUserDeleted value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventUserDeleted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.UserDeleted(
            Auth0.ManagementApi.EventStreamCloudEventUserDeleted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for user.updated
    /// </summary>
    [Serializable]
    public struct UserUpdated
    {
        public UserUpdated(Auth0.ManagementApi.EventStreamCloudEventUserUpdated value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventUserUpdated Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.UserUpdated(
            Auth0.ManagementApi.EventStreamCloudEventUserUpdated value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(Auth0.ManagementApi.EventStreamCloudEventErrorMessage value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventErrorMessage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.Error(
            Auth0.ManagementApi.EventStreamCloudEventErrorMessage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for offset-only
    /// </summary>
    [Serializable]
    public struct OffsetOnly
    {
        public OffsetOnly(Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator EventStreamSubscribeEventsResponseContent.OffsetOnly(
            Auth0.ManagementApi.EventStreamCloudEventOffsetOnlyMessage value
        ) => new(value);
    }
}
