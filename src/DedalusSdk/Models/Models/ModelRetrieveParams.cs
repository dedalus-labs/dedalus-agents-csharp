using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Models;

/// <summary>
/// Retrieve a model.
///
/// <para>Retrieve detailed information about a specific model, including its capabilities,
/// provider, and supported features.</para>
///
/// <para>Args:     model_id: The ID of the model to retrieve (e.g., 'openai/gpt-4',
/// 'anthropic/claude-3-5-sonnet-20241022')     user: Authenticated user obtained
/// from API key validation</para>
///
/// <para>Returns:     Model: Information about the requested model</para>
///
/// <para>Raises:     HTTPException:         - 401 if authentication fails
///  - 404 if model not found or not accessible with current API key         - 500
/// if internal error occurs</para>
///
/// <para>Requires:     Valid API key with 'read' scope permission</para>
///
/// <para>Example:     ```python     import dedalus_labs</para>
///
/// <para>    client = dedalus_labs.Client(api_key="your-api-key")     model = client.models.retrieve("openai/gpt-4")</para>
///
/// <para>    print(f"Model: {model.id}")     print(f"Owner: {model.owned_by}")
///    ```</para>
///
/// <para>    Response:     ```json     {         "id": "openai/gpt-4",         "object":
/// "model",         "created": 1687882411,         "owned_by": "openai"     }
///   ```</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ModelRetrieveParams : ParamsBase
{
    public string? ModelID { get; init; }

    public ModelRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelRetrieveParams(ModelRetrieveParams modelRetrieveParams)
        : base(modelRetrieveParams)
    {
        this.ModelID = modelRetrieveParams.ModelID;
    }
#pragma warning restore CS8618

    public ModelRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string modelID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ModelID = modelID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ModelRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string modelID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            modelID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ModelID"] = JsonSerializer.SerializeToElement(this.ModelID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ModelRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ModelID?.Equals(other.ModelID) ?? other.ModelID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/models/{0}", this.ModelID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
