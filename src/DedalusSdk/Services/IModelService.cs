using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Models;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IModelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IModelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a model.
    ///
    /// <para>Retrieve detailed information about a specific model, including its
    /// capabilities, provider, and supported features.</para>
    ///
    /// <para>Args:     model_id: The ID of the model to retrieve (e.g., 'openai/gpt-4',
    /// 'anthropic/claude-3-5-sonnet-20241022')     user: Authenticated user obtained
    /// from API key validation</para>
    ///
    /// <para>Returns:     Model: Information about the requested model</para>
    ///
    /// <para>Raises:     HTTPException:         - 401 if authentication fails         -
    /// 404 if model not found or not accessible with current API key         - 500 if
    /// internal error occurs</para>
    ///
    /// <para>Requires:     Valid API key with 'read' scope permission</para>
    ///
    /// <para>Example:     ```python     import dedalus_labs</para>
    ///
    /// <para>    client = dedalus_labs.Client(api_key="your-api-key")     model =
    /// client.models.retrieve("openai/gpt-4")</para>
    ///
    /// <para>    print(f"Model: {model.id}")     print(f"Owner: {model.owned_by}")
    /// ```</para>
    ///
    /// <para>    Response:     ```json     {         "id": "openai/gpt-4",
    /// "object": "model",         "created": 1687882411,         "owned_by": "openai"
    ///   }     ```</para>
    /// </summary>
    Task<Model> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<Model> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List available models.
    ///
    /// <para>Retrieve the complete list of models available to your organization,
    /// including models from OpenAI, Anthropic, Google, xAI, Mistral, Fireworks, and
    /// DeepSeek.</para>
    ///
    /// <para>Returns:     ListModelsResponse: List of available models across all
    /// supported providers</para>
    /// </summary>
    Task<ListModelsResponse> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IModelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IModelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IModelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/models/{model_id}</c>, but is otherwise the
    /// same as <see cref="IModelService.Retrieve(ModelRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Model>> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ModelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Model>> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/models</c>, but is otherwise the
    /// same as <see cref="IModelService.List(ModelListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ListModelsResponse>> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
