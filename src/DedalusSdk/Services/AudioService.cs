using System;
using DedalusSdk.Core;
using DedalusSdk.Services.Audio;

namespace DedalusSdk.Services;

/// <inheritdoc/>
public sealed class AudioService : IAudioService
{
    readonly Lazy<IAudioServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudioServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IAudioService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioService(this._client.WithOptions(modifier));
    }

    public AudioService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AudioServiceWithRawResponse(client.WithRawResponse));
        _speech = new(() => new SpeechService(client));
        _transcriptions = new(() => new TranscriptionService(client));
        _translations = new(() => new TranslationService(client));
    }

    readonly Lazy<ISpeechService> _speech;
    public ISpeechService Speech
    {
        get { return _speech.Value; }
    }

    readonly Lazy<ITranscriptionService> _transcriptions;
    public ITranscriptionService Transcriptions
    {
        get { return _transcriptions.Value; }
    }

    readonly Lazy<ITranslationService> _translations;
    public ITranslationService Translations
    {
        get { return _translations.Value; }
    }
}

/// <inheritdoc/>
public sealed class AudioServiceWithRawResponse : IAudioServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudioServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudioServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;

        _speech = new(() => new SpeechServiceWithRawResponse(client));
        _transcriptions = new(() => new TranscriptionServiceWithRawResponse(client));
        _translations = new(() => new TranslationServiceWithRawResponse(client));
    }

    readonly Lazy<ISpeechServiceWithRawResponse> _speech;
    public ISpeechServiceWithRawResponse Speech
    {
        get { return _speech.Value; }
    }

    readonly Lazy<ITranscriptionServiceWithRawResponse> _transcriptions;
    public ITranscriptionServiceWithRawResponse Transcriptions
    {
        get { return _transcriptions.Value; }
    }

    readonly Lazy<ITranslationServiceWithRawResponse> _translations;
    public ITranslationServiceWithRawResponse Translations
    {
        get { return _translations.Value; }
    }
}
