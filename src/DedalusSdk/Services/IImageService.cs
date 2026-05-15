using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create variations of an image.
    ///
    /// <para>DALL·E 2 only. Upload an image to generate variations.</para>
    /// </summary>
    Task<ImagesResponse> CreateVariation(
        ImageCreateVariationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Edit images using inpainting.
    ///
    /// <para>Supports dall-e-2 and gpt-image-1. Upload an image and optionally a mask
    /// to indicate which areas to regenerate based on the prompt.</para>
    /// </summary>
    Task<ImagesResponse> Edit(
        ImageEditParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate images from text prompts.
    ///
    /// <para>Pure image generation models only (DALL-E, GPT Image). For multimodal
    /// models like gemini-2.5-flash-image, use /v1/chat/completions.</para>
    /// </summary>
    Task<ImagesResponse> Generate(
        ImageGenerateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IImageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IImageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/images/variations</c>, but is otherwise the
    /// same as <see cref="IImageService.CreateVariation(ImageCreateVariationParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ImagesResponse>> CreateVariation(
        ImageCreateVariationParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/images/edits</c>, but is otherwise the
    /// same as <see cref="IImageService.Edit(ImageEditParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ImagesResponse>> Edit(
        ImageEditParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/images/generations</c>, but is otherwise the
    /// same as <see cref="IImageService.Generate(ImageGenerateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ImagesResponse>> Generate(
        ImageGenerateParams parameters,
        CancellationToken cancellationToken = default
    );
}
