using System;
using DedalusSdk.Core;
using DedalusSdk.Services.Audio;

namespace DedalusSdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudioService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAudioServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISpeechService Speech { get; }

    ITranscriptionService Transcriptions { get; }

    ITranslationService Translations { get; }
}

/// <summary>
/// A view of <see cref="IAudioService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudioServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISpeechServiceWithRawResponse Speech { get; }

    ITranscriptionServiceWithRawResponse Transcriptions { get; }

    ITranslationServiceWithRawResponse Translations { get; }
}
