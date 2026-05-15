using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Services;

/// <inheritdoc/>
public sealed class EmbeddingService : IEmbeddingService
{
    readonly Lazy<IEmbeddingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmbeddingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IEmbeddingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmbeddingService(this._client.WithOptions(modifier));
    }

    public EmbeddingService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EmbeddingServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CreateEmbeddingResponse> Create(
        EmbeddingCreateParams parameters,
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
public sealed class EmbeddingServiceWithRawResponse : IEmbeddingServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmbeddingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmbeddingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmbeddingServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreateEmbeddingResponse>> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmbeddingCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var createEmbeddingResponse = await response
                    .Deserialize<CreateEmbeddingResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    createEmbeddingResponse.Validate();
                }
                return createEmbeddingResponse;
            }
        );
    }
}
