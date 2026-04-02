namespace Auth0.ManagementApi;

public partial interface ILogStreamsClient
{
    /// <summary>
    /// Retrieve details on <see href="https://auth0.com/docs/logs/streams">log streams</see>.
    /// <para>Sample Response</para><code>[{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "eventbridge",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"awsAccountId": "string",
    /// 		"awsRegion": "string",
    /// 		"awsPartnerEventSource": "string"
    /// 	}
    /// }, {
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "http",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"httpContentFormat": "JSONLINES|JSONARRAY",
    /// 		"httpContentType": "string",
    /// 		"httpEndpoint": "string",
    /// 		"httpAuthorization": "string"
    /// 	}
    /// },
    /// {
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "eventgrid",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"azureSubscriptionId": "string",
    /// 		"azureResourceGroup": "string",
    /// 		"azureRegion": "string",
    /// 		"azurePartnerTopic": "string"
    /// 	}
    /// },
    /// {
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "splunk",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"splunkDomain": "string",
    /// 		"splunkToken": "string",
    /// 		"splunkPort": "string",
    /// 		"splunkSecure": "boolean"
    /// 	}
    /// },
    /// {
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "sumo",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"sumoSourceAddress": "string",
    /// 	}
    /// },
    /// {
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "datadog",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"datadogRegion": "string",
    /// 		"datadogApiKey": "string"
    /// 	}
    /// }]</code>
    /// </summary>
    WithRawResponseTask<IEnumerable<LogStreamResponseSchema>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a log stream.
    /// <para>Log Stream Types</para> The <c>type</c> of log stream being created determines the properties required in the <c>sink</c> payload.
    /// <para>HTTP Stream</para> For an <c>http</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "http",
    /// 	"sink": {
    /// 		"httpEndpoint": "string",
    /// 		"httpContentType": "string",
    /// 		"httpContentFormat": "JSONLINES|JSONARRAY",
    /// 		"httpAuthorization": "string"
    /// 	}
    /// }</code>
    /// Response: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "http",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"httpEndpoint": "string",
    /// 		"httpContentType": "string",
    /// 		"httpContentFormat": "JSONLINES|JSONARRAY",
    /// 		"httpAuthorization": "string"
    /// 	}
    /// }</code>
    /// <para>Amazon EventBridge Stream</para> For an <c>eventbridge</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "eventbridge",
    /// 	"sink": {
    /// 		"awsRegion": "string",
    /// 		"awsAccountId": "string"
    /// 	}
    /// }</code>
    /// The response will include an additional field <c>awsPartnerEventSource</c> in the <c>sink</c>: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "eventbridge",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"awsAccountId": "string",
    /// 		"awsRegion": "string",
    /// 		"awsPartnerEventSource": "string"
    /// 	}
    /// }</code>
    /// <para>Azure Event Grid Stream</para> For an <c>Azure Event Grid</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "eventgrid",
    /// 	"sink": {
    /// 		"azureSubscriptionId": "string",
    /// 		"azureResourceGroup": "string",
    /// 		"azureRegion": "string"
    /// 	}
    /// }</code>
    /// Response: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "http",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"azureSubscriptionId": "string",
    /// 		"azureResourceGroup": "string",
    /// 		"azureRegion": "string",
    /// 		"azurePartnerTopic": "string"
    /// 	}
    /// }</code>
    /// <para>Datadog Stream</para> For a <c>Datadog</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "datadog",
    /// 	"sink": {
    /// 		"datadogRegion": "string",
    /// 		"datadogApiKey": "string"
    /// 	}
    /// }</code>
    /// Response: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "datadog",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"datadogRegion": "string",
    /// 		"datadogApiKey": "string"
    /// 	}
    /// }</code>
    /// <para>Splunk Stream</para> For a <c>Splunk</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "splunk",
    /// 	"sink": {
    /// 		"splunkDomain": "string",
    /// 		"splunkToken": "string",
    /// 		"splunkPort": "string",
    /// 		"splunkSecure": "boolean"
    /// 	}
    /// }</code>
    /// Response: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "splunk",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"splunkDomain": "string",
    /// 		"splunkToken": "string",
    /// 		"splunkPort": "string",
    /// 		"splunkSecure": "boolean"
    /// 	}
    /// }</code>
    /// <para>Sumo Logic Stream</para> For a <c>Sumo Logic</c> Stream, the <c>sink</c> properties are listed in the payload below
    /// Request: <code>{
    /// 	"name": "string",
    /// 	"type": "sumo",
    /// 	"sink": {
    /// 		"sumoSourceAddress": "string",
    /// 	}
    /// }</code>
    /// Response: <code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "sumo",
    /// 	"status": "active",
    /// 	"sink": {
    /// 		"sumoSourceAddress": "string",
    /// 	}
    /// }</code>
    /// </summary>
    WithRawResponseTask<CreateLogStreamResponseContent> CreateAsync(
        CreateLogStreamRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a log stream configuration and status.
    /// <para>Sample responses</para><para>Amazon EventBridge Log Stream</para><code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "eventbridge",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"awsAccountId": "string",
    /// 		"awsRegion": "string",
    /// 		"awsPartnerEventSource": "string"
    /// 	}
    /// }</code> <para>HTTP Log Stream</para><code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "http",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"httpContentFormat": "JSONLINES|JSONARRAY",
    /// 		"httpContentType": "string",
    /// 		"httpEndpoint": "string",
    /// 		"httpAuthorization": "string"
    /// 	}
    /// }</code> <para>Datadog Log Stream</para><code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "datadog",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"datadogRegion": "string",
    /// 		"datadogApiKey": "string"
    /// 	}
    ///
    /// }</code><para>Mixpanel</para>
    ///
    /// 	Request: <code>{
    /// 	  "name": "string",
    /// 	  "type": "mixpanel",
    /// 	  "sink": {
    /// 		"mixpanelRegion": "string", // "us" | "eu",
    /// 		"mixpanelProjectId": "string",
    /// 		"mixpanelServiceAccountUsername": "string",
    /// 		"mixpanelServiceAccountPassword": "string"
    /// 	  }
    /// 	} </code>
    ///
    ///
    /// 	Response: <code>{
    /// 		"id": "string",
    /// 		"name": "string",
    /// 		"type": "mixpanel",
    /// 		"status": "active",
    /// 		"sink": {
    /// 		  "mixpanelRegion": "string", // "us" | "eu",
    /// 		  "mixpanelProjectId": "string",
    /// 		  "mixpanelServiceAccountUsername": "string",
    /// 		  "mixpanelServiceAccountPassword": "string" // the following is redacted on return
    /// 		}
    /// 	  } </code>
    ///
    /// 	<para>Segment</para>
    ///
    /// 	Request: <code> {
    /// 	  "name": "string",
    /// 	  "type": "segment",
    /// 	  "sink": {
    /// 		"segmentWriteKey": "string"
    /// 	  }
    /// 	}</code>
    ///
    /// 	Response: <code>{
    /// 	  "id": "string",
    /// 	  "name": "string",
    /// 	  "type": "segment",
    /// 	  "status": "active",
    /// 	  "sink": {
    /// 		"segmentWriteKey": "string"
    /// 	  }
    /// 	} </code>
    ///
    /// <para>Splunk Log Stream</para><code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "splunk",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"splunkDomain": "string",
    /// 		"splunkToken": "string",
    /// 		"splunkPort": "string",
    /// 		"splunkSecure": "boolean"
    /// 	}
    /// }</code> <para>Sumo Logic Log Stream</para><code>{
    /// 	"id": "string",
    /// 	"name": "string",
    /// 	"type": "sumo",
    /// 	"status": "active|paused|suspended",
    /// 	"sink": {
    /// 		"sumoSourceAddress": "string",
    /// 	}
    /// }</code> <para>Status</para> The <c>status</c> of a log stream maybe any of the following:
    /// 1. <c>active</c> - Stream is currently enabled.
    /// 2. <c>paused</c> - Stream is currently user disabled and will not attempt log delivery.
    /// 3. <c>suspended</c> - Stream is currently disabled because of errors and will not attempt log delivery.
    /// </summary>
    WithRawResponseTask<GetLogStreamResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a log stream.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a log stream.
    /// <para>Examples of how to use the PATCH endpoint.</para> The following fields may be updated in a PATCH operation: <list type="bullet"><item><description>name</description></item><item><description>status</description></item><item><description>sink</description></item></list> Note: For log streams of type <c>eventbridge</c> and <c>eventgrid</c>, updating the <c>sink</c> is not permitted.
    /// <para>Update the status of a log stream</para><code>{
    /// 	"status": "active|paused"
    /// }</code>
    /// <para>Update the name of a log stream</para><code>{
    /// 	"name": "string"
    /// }</code>
    /// <para>Update the sink properties of a stream of type <c>http</c></para><code>{
    ///   "sink": {
    ///     "httpEndpoint": "string",
    ///     "httpContentType": "string",
    ///     "httpContentFormat": "JSONARRAY|JSONLINES",
    ///     "httpAuthorization": "string"
    ///   }
    /// }</code>
    /// <para>Update the sink properties of a stream of type <c>datadog</c></para><code>{
    ///   "sink": {
    /// 		"datadogRegion": "string",
    /// 		"datadogApiKey": "string"
    ///   }
    /// }</code>
    /// <para>Update the sink properties of a stream of type <c>splunk</c></para><code>{
    ///   "sink": {
    ///     "splunkDomain": "string",
    ///     "splunkToken": "string",
    ///     "splunkPort": "string",
    ///     "splunkSecure": "boolean"
    ///   }
    /// }</code>
    /// <para>Update the sink properties of a stream of type <c>sumo</c></para><code>{
    ///   "sink": {
    ///     "sumoSourceAddress": "string"
    ///   }
    /// }</code>
    /// </summary>
    WithRawResponseTask<UpdateLogStreamResponseContent> UpdateAsync(
        string id,
        UpdateLogStreamRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
