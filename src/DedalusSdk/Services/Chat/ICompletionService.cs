using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Services.Chat;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICompletionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICompletionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICompletionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a chat completion.
    ///
    /// <para>Generates a model response for the given conversation and configuration.
    /// Supports OpenAI-compatible parameters and provider-specific extensions.</para>
    ///
    /// <para>Headers:   - Authorization: bearer key for the calling account.   -
    /// X-Provider / X-Provider-Key: optional headers for using your own provider API
    /// key.</para>
    ///
    /// <para>Behavior:   - If multiple models are supplied, the first one is used, and
    /// the agent may hand off to another model.   - Tools may be invoked on the server
    /// or signaled for the client to run.   - Streaming responses emit incremental
    /// deltas; non-streaming returns a single object.   - Usage metrics are computed
    /// when available and returned in the response.</para>
    ///
    /// <para>Responses:   - 200 OK: JSON completion object with choices, message
    /// content, and usage.   - 400 Bad Request: validation error.   - 401 Unauthorized:
    /// authentication failed.   - 402 Payment Required or 429 Too Many Requests: quota,
    /// balance, or rate limit issue.   - 500 Internal Server Error: unexpected failure.</para>
    ///
    /// <para>Billing:   - Token usage metered by the selected model(s).   - Tool calls
    /// and MCP sessions may be billed separately.   - Streaming is settled after the
    /// stream ends via an async task.</para>
    ///
    /// <para>Example (non-streaming HTTP):   POST /v1/chat/completions   Content-Type:
    /// application/json   Authorization: Bearer <key></para>
    ///
    /// <para>  {     "model": "provider/model-name",     "messages": [{"role": "user",
    /// "content": "Hello"}]   }</para>
    ///
    /// <para>  200 OK   {     "id": "cmpl_123",     "object": "chat.completion",
    /// "choices": [       {"index": 0, "message": {"role": "assistant", "content": "Hi
    /// there!"}, "finish_reason": "stop"}     ],     "usage": {"prompt_tokens": 3,
    /// "completion_tokens": 4, "total_tokens": 7}   }</para>
    ///
    /// <para>Example (streaming over SSE):   POST /v1/chat/completions   Accept:
    /// text/event-stream</para>
    ///
    /// <para>  data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":"Hi"}}]}
    ///   data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":" there!"}}]}
    ///   data: [DONE]</para>
    /// </summary>
    Task<ChatCompletion> Create(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a chat completion.
    ///
    /// <para>Generates a model response for the given conversation and configuration.
    /// Supports OpenAI-compatible parameters and provider-specific extensions.</para>
    ///
    /// <para>Headers:   - Authorization: bearer key for the calling account.   -
    /// X-Provider / X-Provider-Key: optional headers for using your own provider API
    /// key.</para>
    ///
    /// <para>Behavior:   - If multiple models are supplied, the first one is used, and
    /// the agent may hand off to another model.   - Tools may be invoked on the server
    /// or signaled for the client to run.   - Streaming responses emit incremental
    /// deltas; non-streaming returns a single object.   - Usage metrics are computed
    /// when available and returned in the response.</para>
    ///
    /// <para>Responses:   - 200 OK: JSON completion object with choices, message
    /// content, and usage.   - 400 Bad Request: validation error.   - 401 Unauthorized:
    /// authentication failed.   - 402 Payment Required or 429 Too Many Requests: quota,
    /// balance, or rate limit issue.   - 500 Internal Server Error: unexpected failure.</para>
    ///
    /// <para>Billing:   - Token usage metered by the selected model(s).   - Tool calls
    /// and MCP sessions may be billed separately.   - Streaming is settled after the
    /// stream ends via an async task.</para>
    ///
    /// <para>Example (non-streaming HTTP):   POST /v1/chat/completions   Content-Type:
    /// application/json   Authorization: Bearer <key></para>
    ///
    /// <para>  {     "model": "provider/model-name",     "messages": [{"role": "user",
    /// "content": "Hello"}]   }</para>
    ///
    /// <para>  200 OK   {     "id": "cmpl_123",     "object": "chat.completion",
    /// "choices": [       {"index": 0, "message": {"role": "assistant", "content": "Hi
    /// there!"}, "finish_reason": "stop"}     ],     "usage": {"prompt_tokens": 3,
    /// "completion_tokens": 4, "total_tokens": 7}   }</para>
    ///
    /// <para>Example (streaming over SSE):   POST /v1/chat/completions   Accept:
    /// text/event-stream</para>
    ///
    /// <para>  data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":"Hi"}}]}
    ///   data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":" there!"}}]}
    ///   data: [DONE]</para>
    /// </summary>
    IAsyncEnumerable<ChatCompletionChunk> CreateStreaming(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICompletionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICompletionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICompletionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/chat/completions</c>, but is otherwise the
    /// same as <see cref="ICompletionService.Create(CompletionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatCompletion>> Create(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/chat/completions</c>, but is otherwise the
    /// same as <see cref="ICompletionService.CreateStreaming(CompletionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<ChatCompletionChunk>> CreateStreaming(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
