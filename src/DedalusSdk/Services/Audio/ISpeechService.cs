using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Speech;

namespace DedalusSdk.Services.Audio;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpeechService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeechServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Generate speech audio from text.
    ///
    /// <para>Generates audio from the input text using text-to-speech models. Supports
    /// multiple voices and output formats including mp3, opus, aac, flac, wav, and pcm.</para>
    ///
    /// <para>Returns streaming audio data that can be saved to a file or streamed
    /// directly to users.</para>
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Create(
        SpeechCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpeechService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeechServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/audio/speech</c>, but is otherwise the
    /// same as <see cref="ISpeechService.Create(SpeechCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        SpeechCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
