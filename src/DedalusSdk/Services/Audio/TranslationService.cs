using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Translations;

namespace DedalusSdk.Services.Audio;

/// <inheritdoc/>
public sealed class TranslationService : ITranslationService
{
    readonly Lazy<ITranslationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslationService(this._client.WithOptions(modifier));
    }

    public TranslationService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TranslationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TranslationCreateResponse> Create(
        TranslationCreateParams parameters,
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
public sealed class TranslationServiceWithRawResponse : ITranslationServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranslationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TranslationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranslationServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TranslationCreateResponse>> Create(
        TranslationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TranslationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var translation = await response
                    .Deserialize<TranslationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    translation.Validate();
                }
                return translation;
            }
        );
    }
}
