using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Services;

/// <inheritdoc/>
public sealed class OcrService : IOcrService
{
    readonly Lazy<IOcrServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOcrServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IOcrService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OcrService(this._client.WithOptions(modifier));
    }

    public OcrService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OcrServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OcrResponse> Process(
        OcrProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Process(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OcrServiceWithRawResponse : IOcrServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOcrServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OcrServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OcrServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OcrResponse>> Process(
        OcrProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OcrProcessParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ocrResponse = await response
                    .Deserialize<OcrResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ocrResponse.Validate();
                }
                return ocrResponse;
            }
        );
    }
}
