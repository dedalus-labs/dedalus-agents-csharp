using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Responses;

namespace DedalusSdk.Services;

/// <inheritdoc/>
public sealed class ResponseService : IResponseService
{
    readonly Lazy<IResponseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IResponseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IResponseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResponseService(this._client.WithOptions(modifier));
    }

    public ResponseService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ResponseServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Response> Create(
        ResponseCreateParams? parameters = null,
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
public sealed class ResponseServiceWithRawResponse : IResponseServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IResponseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResponseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ResponseServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Response>> Create(
        ResponseCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ResponseCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<Response>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
