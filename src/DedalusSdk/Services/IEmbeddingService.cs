using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEmbeddingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmbeddingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create embeddings using the configured provider.
    /// </summary>
    Task<CreateEmbeddingResponse> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEmbeddingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmbeddingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/embeddings</c>, but is otherwise the
    /// same as <see cref="IEmbeddingService.Create(EmbeddingCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreateEmbeddingResponse>> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
