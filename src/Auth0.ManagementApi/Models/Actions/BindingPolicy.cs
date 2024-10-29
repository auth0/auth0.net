using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// In order to execute an Action, it must be bound to a trigger using a binding. trigger-bound means that
    /// bindings are managed by the tenant. entity-bound means that the bindings are automatically managed by Auth0
    /// and other internal resources will control those bindings. Tenants cannot manage entity-bound bindings.
    /// </summary>
    public enum BindingPolicy
    {
        [EnumMember(Value = "trigger-bound")]
        TriggerBound,
        
        [EnumMember(Value = "entity-bound")]
        EntityBound
    }
}