using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Transcriptions;

namespace DedalusSdk.Services.Audio;

/// <inheritdoc/>
public sealed class TranscriptionService : ITranscriptionService
{
    readonly Lazy<ITranscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ITranscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranscriptionService(this._client.WithOptions(modifier));
    }

    public TranscriptionService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new TranscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<TranscriptionCreateResponse> Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TranscriptionServiceWithRawResponse : ITranscriptionServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TranscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranscriptionServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TranscriptionCreateResponse>> Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TranscriptionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transcription = await response
                    .Deserialize<TranscriptionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transcription.Validate();
                }
                return transcription;
            }
        );
    }
}
