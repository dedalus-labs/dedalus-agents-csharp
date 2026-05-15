using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Speech;

namespace DedalusSdk.Services.Audio;

/// <inheritdoc/>
public sealed class SpeechService : ISpeechService
{
    readonly Lazy<ISpeechServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeechServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ISpeechService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeechService(this._client.WithOptions(modifier));
    }

    public SpeechService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpeechServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        SpeechCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpeechServiceWithRawResponse : ISpeechServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeechServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeechServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeechServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        SpeechCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpeechCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
