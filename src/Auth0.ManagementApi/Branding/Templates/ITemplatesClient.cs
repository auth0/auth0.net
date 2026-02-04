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
    /// <p>When <code>content-type</code> header is set to <code>application/json</code>:</p>
    /// <pre>
    /// {
    ///   "template": "&lt;!DOCTYPE html&gt;{% assign resolved_dir = dir | default: "auto" %}&lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;&lt;head&gt;{%- auth0:head -%}&lt;/head&gt;&lt;body class="_widget-auto-layout"&gt;{%- auth0:widget -%}&lt;/body&gt;&lt;/html&gt;"
    /// }
    /// </pre>
    ///
    /// <p>
    ///   When <code>content-type</code> header is set to <code>text/html</code>:
    /// </p>
    /// <pre>
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
    /// </pre>
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
