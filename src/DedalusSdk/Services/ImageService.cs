using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Services;

/// <inheritdoc/>
public sealed class ImageService : IImageService
{
    readonly Lazy<IImageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageService(this._client.WithOptions(modifier));
    }

    public ImageService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ImageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ImagesResponse> CreateVariation(
        ImageCreateVariationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateVariation(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ImagesResponse> Edit(
        ImageEditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Edit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ImagesResponse> Generate(
        ImageGenerateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Generate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ImageServiceWithRawResponse : IImageServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ImageServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ImagesResponse>> CreateVariation(
        ImageCreateVariationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ImageCreateVariationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var imagesResponse = await response
                    .Deserialize<ImagesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    imagesResponse.Validate();
                }
                return imagesResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ImagesResponse>> Edit(
        ImageEditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ImageEditParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var imagesResponse = await response
                    .Deserialize<ImagesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    imagesResponse.Validate();
                }
                return imagesResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ImagesResponse>> Generate(
        ImageGenerateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ImageGenerateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var imagesResponse = await response
                    .Deserialize<ImagesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    imagesResponse.Validate();
                }
                return imagesResponse;
            }
        );
    }
}
