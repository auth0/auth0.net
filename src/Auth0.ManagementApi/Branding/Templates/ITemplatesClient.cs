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
    /// When `content-type` header is set to `application/json`:
    ///
    /// ```json
    /// {
    ///   "template": "{% assign resolved_dir = dir | default: \"auto\" %}&lt;html lang=\"{{locale}}\" dir=\"{{resolved_dir}}\"&gt;&lt;head&gt;{%- auth0:head -%}&lt;/head&gt;&lt;body class=\"_widget-auto-layout\"&gt;{%- auth0:widget -%}&lt;/body&gt;&lt;/html&gt;"
    /// }
    /// ```
    ///
    /// When `content-type` header is set to `text/html`:
    ///
    /// ```html
    ///
    /// {% assign resolved_dir = dir | default: "auto" %}
    /// &lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;
    ///   &lt;head&gt;
    ///     {%- auth0:head -%}
    ///   &lt;/head&gt;
    ///   &lt;body class="_widget-auto-layout"&gt;
    ///     {%- auth0:widget -%}
    ///   &lt;/body&gt;
    /// &lt;/html&gt;
    /// ```
    /// </summary>
    WithRawResponseTask UpdateUniversalLoginAsync(
        UpdateUniversalLoginTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteUniversalLoginAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
