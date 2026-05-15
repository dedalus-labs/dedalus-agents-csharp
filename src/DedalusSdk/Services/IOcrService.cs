using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOcrService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOcrServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOcrService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Process a document through Mistral OCR.
    ///
    /// <para>Extracts text from PDFs and images, returning markdown-formatted content.</para>
    /// </summary>
    Task<OcrResponse> Process(
        OcrProcessParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOcrService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOcrServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOcrServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/ocr</c>, but is otherwise the
    /// same as <see cref="IOcrService.Process(OcrProcessParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OcrResponse>> Process(
        OcrProcessParams parameters,
        CancellationToken cancellationToken = default
    );
}
