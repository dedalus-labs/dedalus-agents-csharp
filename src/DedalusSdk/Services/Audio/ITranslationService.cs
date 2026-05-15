using System;
using System.Threading;
using System.Threading.Tasks;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Translations;

namespace DedalusSdk.Services.Audio;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranslationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITranslationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranslationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Translate audio into English.
    ///
    /// <para>Translates audio files in any supported language to English text using
    /// OpenAI's Whisper model. Supports the same audio formats as transcription.
    /// Maximum file size is 25 MB.</para>
    ///
    /// <para>Args:     file: Audio file to translate (required)     model: Model ID to
    /// use (e.g., "openai/whisper-1")     prompt: Optional text to guide the model's
    /// style     response_format: Format of the output (json, text, srt, verbose_json,
    /// vtt)     temperature: Sampling temperature between 0 and 1</para>
    ///
    /// <para>Returns:     Translation object with the English translation</para>
    /// </summary>
    Task<TranslationCreateResponse> Create(
        TranslationCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITranslationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITranslationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranslationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/audio/translations</c>, but is otherwise the
    /// same as <see cref="ITranslationService.Create(TranslationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TranslationCreateResponse>> Create(
        TranslationCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
