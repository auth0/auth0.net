// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PageComponent.JsonConverter))]
[Serializable]
public record PageComponent
{
    internal PageComponent(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0Form"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0Form value)
    {
        Type = "page:component:auth0:form";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0TypographyHeading"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0TypographyHeading value)
    {
        Type = "page:component:auth0:typography:heading";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MediaImage"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MediaImage value)
    {
        Type = "page:component:auth0:media:image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0TypographyRichText"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0TypographyRichText value)
    {
        Type = "page:component:auth0:typography:rich_text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0StructureSection"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0StructureSection value)
    {
        Type = "page:component:auth0:structure:section";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0StructureSeparator"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0StructureSeparator value)
    {
        Type = "page:component:auth0:structure:separator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MyOrganizationDomainTable"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MyOrganizationDomainTable value)
    {
        Type = "page:component:auth0:my_organization:domain_table";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MyOrganizationMemberManagement"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MyOrganizationMemberManagement value)
    {
        Type = "page:component:auth0:my_organization:member_management";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MyOrganizationDetailsEdit"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MyOrganizationDetailsEdit value)
    {
        Type = "page:component:auth0:my_organization:details_edit";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MyAccountPasskeyManagement"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MyAccountPasskeyManagement value)
    {
        Type = "page:component:auth0:my_account:passkey_management";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PageComponent with <see cref="PageComponent.PageComponentAuth0MyAccountMfaManagement"/>.
    /// </summary>
    public PageComponent(PageComponent.PageComponentAuth0MyAccountMfaManagement value)
    {
        Type = "page:component:auth0:my_account:mfa_management";
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
    /// Returns true if <see cref="Type"/> is "page:component:auth0:form"
    /// </summary>
    public bool IsPageComponentAuth0Form => Type == "page:component:auth0:form";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:typography:heading"
    /// </summary>
    public bool IsPageComponentAuth0TypographyHeading =>
        Type == "page:component:auth0:typography:heading";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:media:image"
    /// </summary>
    public bool IsPageComponentAuth0MediaImage => Type == "page:component:auth0:media:image";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:typography:rich_text"
    /// </summary>
    public bool IsPageComponentAuth0TypographyRichText =>
        Type == "page:component:auth0:typography:rich_text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:structure:section"
    /// </summary>
    public bool IsPageComponentAuth0StructureSection =>
        Type == "page:component:auth0:structure:section";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:structure:separator"
    /// </summary>
    public bool IsPageComponentAuth0StructureSeparator =>
        Type == "page:component:auth0:structure:separator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:my_organization:domain_table"
    /// </summary>
    public bool IsPageComponentAuth0MyOrganizationDomainTable =>
        Type == "page:component:auth0:my_organization:domain_table";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:my_organization:member_management"
    /// </summary>
    public bool IsPageComponentAuth0MyOrganizationMemberManagement =>
        Type == "page:component:auth0:my_organization:member_management";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:my_organization:details_edit"
    /// </summary>
    public bool IsPageComponentAuth0MyOrganizationDetailsEdit =>
        Type == "page:component:auth0:my_organization:details_edit";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:my_account:passkey_management"
    /// </summary>
    public bool IsPageComponentAuth0MyAccountPasskeyManagement =>
        Type == "page:component:auth0:my_account:passkey_management";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "page:component:auth0:my_account:mfa_management"
    /// </summary>
    public bool IsPageComponentAuth0MyAccountMfaManagement =>
        Type == "page:component:auth0:my_account:mfa_management";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0Form"/> if <see cref="Type"/> is 'page:component:auth0:form', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:form'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0Form AsPageComponentAuth0Form() =>
        IsPageComponentAuth0Form
            ? (Auth0.ManagementApi.PageComponentAuth0Form)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:form'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0TypographyHeading"/> if <see cref="Type"/> is 'page:component:auth0:typography:heading', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:typography:heading'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0TypographyHeading AsPageComponentAuth0TypographyHeading() =>
        IsPageComponentAuth0TypographyHeading
            ? (Auth0.ManagementApi.PageComponentAuth0TypographyHeading)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:typography:heading'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MediaImage"/> if <see cref="Type"/> is 'page:component:auth0:media:image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:media:image'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MediaImage AsPageComponentAuth0MediaImage() =>
        IsPageComponentAuth0MediaImage
            ? (Auth0.ManagementApi.PageComponentAuth0MediaImage)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:media:image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0TypographyRichText"/> if <see cref="Type"/> is 'page:component:auth0:typography:rich_text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:typography:rich_text'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0TypographyRichText AsPageComponentAuth0TypographyRichText() =>
        IsPageComponentAuth0TypographyRichText
            ? (Auth0.ManagementApi.PageComponentAuth0TypographyRichText)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:typography:rich_text'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0StructureSection"/> if <see cref="Type"/> is 'page:component:auth0:structure:section', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:structure:section'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0StructureSection AsPageComponentAuth0StructureSection() =>
        IsPageComponentAuth0StructureSection
            ? (Auth0.ManagementApi.PageComponentAuth0StructureSection)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:structure:section'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0StructureSeparator"/> if <see cref="Type"/> is 'page:component:auth0:structure:separator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:structure:separator'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0StructureSeparator AsPageComponentAuth0StructureSeparator() =>
        IsPageComponentAuth0StructureSeparator
            ? (Auth0.ManagementApi.PageComponentAuth0StructureSeparator)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:structure:separator'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable"/> if <see cref="Type"/> is 'page:component:auth0:my_organization:domain_table', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:my_organization:domain_table'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable AsPageComponentAuth0MyOrganizationDomainTable() =>
        IsPageComponentAuth0MyOrganizationDomainTable
            ? (Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:my_organization:domain_table'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement"/> if <see cref="Type"/> is 'page:component:auth0:my_organization:member_management', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:my_organization:member_management'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement AsPageComponentAuth0MyOrganizationMemberManagement() =>
        IsPageComponentAuth0MyOrganizationMemberManagement
            ? (Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:my_organization:member_management'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit"/> if <see cref="Type"/> is 'page:component:auth0:my_organization:details_edit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:my_organization:details_edit'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit AsPageComponentAuth0MyOrganizationDetailsEdit() =>
        IsPageComponentAuth0MyOrganizationDetailsEdit
            ? (Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:my_organization:details_edit'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement"/> if <see cref="Type"/> is 'page:component:auth0:my_account:passkey_management', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:my_account:passkey_management'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement AsPageComponentAuth0MyAccountPasskeyManagement() =>
        IsPageComponentAuth0MyAccountPasskeyManagement
            ? (Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:my_account:passkey_management'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement"/> if <see cref="Type"/> is 'page:component:auth0:my_account:mfa_management', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'page:component:auth0:my_account:mfa_management'.</exception>
    public Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement AsPageComponentAuth0MyAccountMfaManagement() =>
        IsPageComponentAuth0MyAccountMfaManagement
            ? (Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement)Value!
            : throw new global::System.Exception(
                "PageComponent.Type is not 'page:component:auth0:my_account:mfa_management'"
            );

    public T Match<T>(
        Func<Auth0.ManagementApi.PageComponentAuth0Form, T> onPageComponentAuth0Form,
        Func<
            Auth0.ManagementApi.PageComponentAuth0TypographyHeading,
            T
        > onPageComponentAuth0TypographyHeading,
        Func<Auth0.ManagementApi.PageComponentAuth0MediaImage, T> onPageComponentAuth0MediaImage,
        Func<
            Auth0.ManagementApi.PageComponentAuth0TypographyRichText,
            T
        > onPageComponentAuth0TypographyRichText,
        Func<
            Auth0.ManagementApi.PageComponentAuth0StructureSection,
            T
        > onPageComponentAuth0StructureSection,
        Func<
            Auth0.ManagementApi.PageComponentAuth0StructureSeparator,
            T
        > onPageComponentAuth0StructureSeparator,
        Func<
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable,
            T
        > onPageComponentAuth0MyOrganizationDomainTable,
        Func<
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement,
            T
        > onPageComponentAuth0MyOrganizationMemberManagement,
        Func<
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit,
            T
        > onPageComponentAuth0MyOrganizationDetailsEdit,
        Func<
            Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement,
            T
        > onPageComponentAuth0MyAccountPasskeyManagement,
        Func<
            Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement,
            T
        > onPageComponentAuth0MyAccountMfaManagement,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "page:component:auth0:form" => onPageComponentAuth0Form(AsPageComponentAuth0Form()),
            "page:component:auth0:typography:heading" => onPageComponentAuth0TypographyHeading(
                AsPageComponentAuth0TypographyHeading()
            ),
            "page:component:auth0:media:image" => onPageComponentAuth0MediaImage(
                AsPageComponentAuth0MediaImage()
            ),
            "page:component:auth0:typography:rich_text" => onPageComponentAuth0TypographyRichText(
                AsPageComponentAuth0TypographyRichText()
            ),
            "page:component:auth0:structure:section" => onPageComponentAuth0StructureSection(
                AsPageComponentAuth0StructureSection()
            ),
            "page:component:auth0:structure:separator" => onPageComponentAuth0StructureSeparator(
                AsPageComponentAuth0StructureSeparator()
            ),
            "page:component:auth0:my_organization:domain_table" =>
                onPageComponentAuth0MyOrganizationDomainTable(
                    AsPageComponentAuth0MyOrganizationDomainTable()
                ),
            "page:component:auth0:my_organization:member_management" =>
                onPageComponentAuth0MyOrganizationMemberManagement(
                    AsPageComponentAuth0MyOrganizationMemberManagement()
                ),
            "page:component:auth0:my_organization:details_edit" =>
                onPageComponentAuth0MyOrganizationDetailsEdit(
                    AsPageComponentAuth0MyOrganizationDetailsEdit()
                ),
            "page:component:auth0:my_account:passkey_management" =>
                onPageComponentAuth0MyAccountPasskeyManagement(
                    AsPageComponentAuth0MyAccountPasskeyManagement()
                ),
            "page:component:auth0:my_account:mfa_management" =>
                onPageComponentAuth0MyAccountMfaManagement(
                    AsPageComponentAuth0MyAccountMfaManagement()
                ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0Form> onPageComponentAuth0Form,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0TypographyHeading> onPageComponentAuth0TypographyHeading,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MediaImage> onPageComponentAuth0MediaImage,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0TypographyRichText> onPageComponentAuth0TypographyRichText,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0StructureSection> onPageComponentAuth0StructureSection,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0StructureSeparator> onPageComponentAuth0StructureSeparator,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable> onPageComponentAuth0MyOrganizationDomainTable,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement> onPageComponentAuth0MyOrganizationMemberManagement,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit> onPageComponentAuth0MyOrganizationDetailsEdit,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement> onPageComponentAuth0MyAccountPasskeyManagement,
        global::System.Action<Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement> onPageComponentAuth0MyAccountMfaManagement,
        global::System.Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "page:component:auth0:form":
                onPageComponentAuth0Form(AsPageComponentAuth0Form());
                break;
            case "page:component:auth0:typography:heading":
                onPageComponentAuth0TypographyHeading(AsPageComponentAuth0TypographyHeading());
                break;
            case "page:component:auth0:media:image":
                onPageComponentAuth0MediaImage(AsPageComponentAuth0MediaImage());
                break;
            case "page:component:auth0:typography:rich_text":
                onPageComponentAuth0TypographyRichText(AsPageComponentAuth0TypographyRichText());
                break;
            case "page:component:auth0:structure:section":
                onPageComponentAuth0StructureSection(AsPageComponentAuth0StructureSection());
                break;
            case "page:component:auth0:structure:separator":
                onPageComponentAuth0StructureSeparator(AsPageComponentAuth0StructureSeparator());
                break;
            case "page:component:auth0:my_organization:domain_table":
                onPageComponentAuth0MyOrganizationDomainTable(
                    AsPageComponentAuth0MyOrganizationDomainTable()
                );
                break;
            case "page:component:auth0:my_organization:member_management":
                onPageComponentAuth0MyOrganizationMemberManagement(
                    AsPageComponentAuth0MyOrganizationMemberManagement()
                );
                break;
            case "page:component:auth0:my_organization:details_edit":
                onPageComponentAuth0MyOrganizationDetailsEdit(
                    AsPageComponentAuth0MyOrganizationDetailsEdit()
                );
                break;
            case "page:component:auth0:my_account:passkey_management":
                onPageComponentAuth0MyAccountPasskeyManagement(
                    AsPageComponentAuth0MyAccountPasskeyManagement()
                );
                break;
            case "page:component:auth0:my_account:mfa_management":
                onPageComponentAuth0MyAccountMfaManagement(
                    AsPageComponentAuth0MyAccountMfaManagement()
                );
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0Form"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0Form(out Auth0.ManagementApi.PageComponentAuth0Form? value)
    {
        if (Type == "page:component:auth0:form")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0Form)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0TypographyHeading"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0TypographyHeading(
        out Auth0.ManagementApi.PageComponentAuth0TypographyHeading? value
    )
    {
        if (Type == "page:component:auth0:typography:heading")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0TypographyHeading)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MediaImage"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MediaImage(
        out Auth0.ManagementApi.PageComponentAuth0MediaImage? value
    )
    {
        if (Type == "page:component:auth0:media:image")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MediaImage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0TypographyRichText"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0TypographyRichText(
        out Auth0.ManagementApi.PageComponentAuth0TypographyRichText? value
    )
    {
        if (Type == "page:component:auth0:typography:rich_text")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0TypographyRichText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0StructureSection"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0StructureSection(
        out Auth0.ManagementApi.PageComponentAuth0StructureSection? value
    )
    {
        if (Type == "page:component:auth0:structure:section")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0StructureSection)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0StructureSeparator"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0StructureSeparator(
        out Auth0.ManagementApi.PageComponentAuth0StructureSeparator? value
    )
    {
        if (Type == "page:component:auth0:structure:separator")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0StructureSeparator)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MyOrganizationDomainTable(
        out Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable? value
    )
    {
        if (Type == "page:component:auth0:my_organization:domain_table")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MyOrganizationMemberManagement(
        out Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement? value
    )
    {
        if (Type == "page:component:auth0:my_organization:member_management")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MyOrganizationDetailsEdit(
        out Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit? value
    )
    {
        if (Type == "page:component:auth0:my_organization:details_edit")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MyAccountPasskeyManagement(
        out Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement? value
    )
    {
        if (Type == "page:component:auth0:my_account:passkey_management")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement"/> and returns true if successful.
    /// </summary>
    public bool TryAsPageComponentAuth0MyAccountMfaManagement(
        out Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement? value
    )
    {
        if (Type == "page:component:auth0:my_account:mfa_management")
        {
            value = (Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PageComponent(PageComponent.PageComponentAuth0Form value) =>
        new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0TypographyHeading value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MediaImage value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0TypographyRichText value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0StructureSection value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0StructureSeparator value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MyOrganizationDomainTable value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MyOrganizationMemberManagement value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MyOrganizationDetailsEdit value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MyAccountPasskeyManagement value
    ) => new(value);

    public static implicit operator PageComponent(
        PageComponent.PageComponentAuth0MyAccountMfaManagement value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PageComponent>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PageComponent).IsAssignableFrom(typeToConvert);

        public override PageComponent Read(
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
                "page:component:auth0:form" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0Form?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0Form"
                        ),
                "page:component:auth0:typography:heading" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0TypographyHeading?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0TypographyHeading"
                        ),
                "page:component:auth0:media:image" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MediaImage?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MediaImage"
                        ),
                "page:component:auth0:typography:rich_text" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0TypographyRichText?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0TypographyRichText"
                        ),
                "page:component:auth0:structure:section" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0StructureSection?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0StructureSection"
                        ),
                "page:component:auth0:structure:separator" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0StructureSeparator?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0StructureSeparator"
                        ),
                "page:component:auth0:my_organization:domain_table" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable"
                        ),
                "page:component:auth0:my_organization:member_management" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement"
                        ),
                "page:component:auth0:my_organization:details_edit" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit"
                        ),
                "page:component:auth0:my_account:passkey_management" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement"
                        ),
                "page:component:auth0:my_account:mfa_management" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new PageComponent(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PageComponent value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "page:component:auth0:form" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:typography:heading" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:media:image" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:typography:rich_text" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:structure:section" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:structure:separator" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "page:component:auth0:my_organization:domain_table" =>
                        JsonSerializer.SerializeToNode(value.Value, options),
                    "page:component:auth0:my_organization:member_management" =>
                        JsonSerializer.SerializeToNode(value.Value, options),
                    "page:component:auth0:my_organization:details_edit" =>
                        JsonSerializer.SerializeToNode(value.Value, options),
                    "page:component:auth0:my_account:passkey_management" =>
                        JsonSerializer.SerializeToNode(value.Value, options),
                    "page:component:auth0:my_account:mfa_management" =>
                        JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override PageComponent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PageComponent(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PageComponent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:form
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0Form
    {
        public PageComponentAuth0Form(Auth0.ManagementApi.PageComponentAuth0Form value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0Form Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0Form(
            Auth0.ManagementApi.PageComponentAuth0Form value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:typography:heading
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0TypographyHeading
    {
        public PageComponentAuth0TypographyHeading(
            Auth0.ManagementApi.PageComponentAuth0TypographyHeading value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0TypographyHeading Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0TypographyHeading(
            Auth0.ManagementApi.PageComponentAuth0TypographyHeading value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:media:image
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MediaImage
    {
        public PageComponentAuth0MediaImage(Auth0.ManagementApi.PageComponentAuth0MediaImage value)
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MediaImage Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MediaImage(
            Auth0.ManagementApi.PageComponentAuth0MediaImage value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:typography:rich_text
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0TypographyRichText
    {
        public PageComponentAuth0TypographyRichText(
            Auth0.ManagementApi.PageComponentAuth0TypographyRichText value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0TypographyRichText Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0TypographyRichText(
            Auth0.ManagementApi.PageComponentAuth0TypographyRichText value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:structure:section
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0StructureSection
    {
        public PageComponentAuth0StructureSection(
            Auth0.ManagementApi.PageComponentAuth0StructureSection value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0StructureSection Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0StructureSection(
            Auth0.ManagementApi.PageComponentAuth0StructureSection value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:structure:separator
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0StructureSeparator
    {
        public PageComponentAuth0StructureSeparator(
            Auth0.ManagementApi.PageComponentAuth0StructureSeparator value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0StructureSeparator Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0StructureSeparator(
            Auth0.ManagementApi.PageComponentAuth0StructureSeparator value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:my_organization:domain_table
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MyOrganizationDomainTable
    {
        public PageComponentAuth0MyOrganizationDomainTable(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MyOrganizationDomainTable(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDomainTable value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:my_organization:member_management
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MyOrganizationMemberManagement
    {
        public PageComponentAuth0MyOrganizationMemberManagement(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MyOrganizationMemberManagement(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationMemberManagement value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:my_organization:details_edit
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MyOrganizationDetailsEdit
    {
        public PageComponentAuth0MyOrganizationDetailsEdit(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MyOrganizationDetailsEdit(
            Auth0.ManagementApi.PageComponentAuth0MyOrganizationDetailsEdit value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:my_account:passkey_management
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MyAccountPasskeyManagement
    {
        public PageComponentAuth0MyAccountPasskeyManagement(
            Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MyAccountPasskeyManagement(
            Auth0.ManagementApi.PageComponentAuth0MyAccountPasskeyManagement value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for page:component:auth0:my_account:mfa_management
    /// </summary>
    [Serializable]
    public struct PageComponentAuth0MyAccountMfaManagement
    {
        public PageComponentAuth0MyAccountMfaManagement(
            Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PageComponent.PageComponentAuth0MyAccountMfaManagement(
            Auth0.ManagementApi.PageComponentAuth0MyAccountMfaManagement value
        ) => new(value);
    }
}
