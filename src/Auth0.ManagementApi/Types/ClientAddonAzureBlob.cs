using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Azure Blob Storage addon configuration.
/// </summary>
[Serializable]
public record ClientAddonAzureBlob : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Your Azure storage account name. Usually first segment in your Azure storage URL. e.g. `https://acme-org.blob.core.windows.net` would be the account name `acme-org`.
    /// </summary>
    [Optional]
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    /// <summary>
    /// Access key associated with this storage account.
    /// </summary>
    [Optional]
    [JsonPropertyName("storageAccessKey")]
    public string? StorageAccessKey { get; set; }

    /// <summary>
    /// Container to request a token for. e.g. `my-container`.
    /// </summary>
    [Optional]
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    /// <summary>
    /// Entity to request a token for. e.g. `my-blob`. If blank the computed SAS will apply to the entire storage container.
    /// </summary>
    [Optional]
    [JsonPropertyName("blobName")]
    public string? BlobName { get; set; }

    /// <summary>
    /// Expiration in minutes for the generated token (default of 5 minutes).
    /// </summary>
    [Optional]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; set; }

    /// <summary>
    /// Shared access policy identifier defined in your storage account resource.
    /// </summary>
    [Optional]
    [JsonPropertyName("signedIdentifier")]
    public string? SignedIdentifier { get; set; }

    /// <summary>
    /// Indicates if the issued token has permission to read the content, properties, metadata and block list. Use the blob as the source of a copy operation.
    /// </summary>
    [Optional]
    [JsonPropertyName("blob_read")]
    public bool? BlobRead { get; set; }

    /// <summary>
    /// Indicates if the issued token has permission to create or write content, properties, metadata, or block list. Snapshot or lease the blob. Resize the blob (page blob only). Use the blob as the destination of a copy operation within the same account.
    /// </summary>
    [Optional]
    [JsonPropertyName("blob_write")]
    public bool? BlobWrite { get; set; }

    /// <summary>
    /// Indicates if the issued token has permission to delete the blob.
    /// </summary>
    [Optional]
    [JsonPropertyName("blob_delete")]
    public bool? BlobDelete { get; set; }

    /// <summary>
    /// Indicates if the issued token has permission to read the content, properties, metadata or block list of any blob in the container. Use any blob in the container as the source of a copy operation
    /// </summary>
    [Optional]
    [JsonPropertyName("container_read")]
    public bool? ContainerRead { get; set; }

    /// <summary>
    /// Indicates that for any blob in the container if the issued token has permission to create or write content, properties, metadata, or block list. Snapshot or lease the blob. Resize the blob (page blob only). Use the blob as the destination of a copy operation within the same account.
    /// </summary>
    [Optional]
    [JsonPropertyName("container_write")]
    public bool? ContainerWrite { get; set; }

    /// <summary>
    /// Indicates if issued token has permission to delete any blob in the container.
    /// </summary>
    [Optional]
    [JsonPropertyName("container_delete")]
    public bool? ContainerDelete { get; set; }

    /// <summary>
    /// Indicates if the issued token has permission to list blobs in the container.
    /// </summary>
    [Optional]
    [JsonPropertyName("container_list")]
    public bool? ContainerList { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
