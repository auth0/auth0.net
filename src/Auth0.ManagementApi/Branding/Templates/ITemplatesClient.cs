using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Branding;

public partial interface ITemplatesClient
{
    WithRawResponseTask<GetUniversalLoginTemplateResponseContent> GetUniversalLoginAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the Universal Login branding template.
    ///
    /// <para>When <c>content-type</c> header is set to <c>application/json</c>:</para>
    /// <code>
    /// {
    ///   "template": "&lt;!DOCTYPE html&gt;{% assign resolved_dir = dir | default: "auto" %}&lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;&lt;head&gt;{%- auth0:head -%}&lt;/head&gt;&lt;body class="_widget-auto-layout"&gt;{%- auth0:widget -%}&lt;/body&gt;&lt;/html&gt;"
    /// }
    /// </code>
    ///
    /// <para>
    ///   When <c>content-type</c> header is set to <c>text/html</c>:
    /// </para>
    /// <code>
    /// &lt!DOCTYPE html&gt;
    /// {% assign resolved_dir = dir | default: "auto" %}
    /// &lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;
    ///   &lt;head&gt;
    ///     {%- auth0:head -%}
    ///   &lt;/head&gt;
    ///   &lt;body class="_widget-auto-layout"&gt;
    ///     {%- auth0:widget -%}
    ///   &lt;/body&gt;
    /// &lt;/html&gt;
    /// </code>
    /// </summary>
    Task UpdateUniversalLoginAsync(
        UpdateUniversalLoginTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteUniversalLoginAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
