using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Transcriptions;

namespace DedalusSdk.Services.Audio;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITranscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Transcribe audio into text.
    ///
    /// <para>Transcribes audio files using OpenAI's Whisper model. Supports multiple
    /// audio formats including mp3, mp4, mpeg, mpga, m4a, wav, and webm. Maximum file
    /// size is 25 MB.</para>
    ///
    /// <para>Args:     file: Audio file to transcribe (required)     model: Model ID to
    /// use (e.g., "openai/whisper-1")     language: ISO-639-1 language code (e.g.,
    /// "en", "es") - improves accuracy     prompt: Optional text to guide the model's
    /// style     response_format: Format of the output (json, text, srt, verbose_json,
    /// vtt)     temperature: Sampling temperature between 0 and 1</para>
    ///
    /// <para>Returns:     Transcription object with the transcribed text</para>
    /// </summary>
    Task<TranscriptionCreateResponse> Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITranscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITranscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/audio/transcriptions</c>, but is otherwise the
    /// same as <see cref="ITranscriptionService.Create(TranscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TranscriptionCreateResponse>> Create(
        TranscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
