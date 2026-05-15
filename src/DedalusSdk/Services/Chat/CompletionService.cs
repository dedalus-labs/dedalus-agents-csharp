using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Services.Chat;

/// <inheritdoc/>
public sealed class CompletionService : ICompletionService
{
    readonly Lazy<ICompletionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICompletionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ICompletionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CompletionService(this._client.WithOptions(modifier));
    }

    public CompletionService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CompletionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChatCompletion> Create(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<ChatCompletionChunk> CreateStreaming(
        CompletionCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var chatCompletion in response.Enumerate(cancellationToken))
        {
            yield return chatCompletion;
        }
    }
}

/// <inheritdoc/>
public sealed class CompletionServiceWithRawResponse : ICompletionServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICompletionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CompletionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CompletionServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatCompletion>> Create(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CompletionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chatCompletion = await response
                    .Deserialize<ChatCompletion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chatCompletion.Validate();
                }
                return chatCompletion;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<ChatCompletionChunk>> CreateStreaming(
        CompletionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["stream"] = JsonSerializer.SerializeToElement(true);
        parameters = CompletionCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<CompletionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<ChatCompletionChunk> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var chatCompletion in Sse.Enumerate<ChatCompletionChunk>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    chatCompletion.Validate();
                }
                yield return chatCompletion;
            }
        }
        return new(response, Enumerate);
    }
}
