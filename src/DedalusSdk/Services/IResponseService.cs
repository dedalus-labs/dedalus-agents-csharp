using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Responses;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IResponseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IResponseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResponseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a response using the OpenAI Responses API.
    ///
    /// <para>This endpoint routes directly to OpenAI's Responses API. Only OpenAI
    /// models are supported.</para>
    /// </summary>
    Task<Response> Create(
        ResponseCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IResponseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IResponseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResponseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/responses</c>, but is otherwise the
    /// same as <see cref="IResponseService.Create(ResponseCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Response>> Create(
        ResponseCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
