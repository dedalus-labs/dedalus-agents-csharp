using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Data about a previous audio response from the model. [Learn more](/docs/guides/audio).
///
/// <para>Fields: - id (required): str</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CompletionAudio, CompletionAudioFromRaw>))]
public sealed record class CompletionAudio : JsonModel
{
    /// <summary>
    /// Unique identifier for a previous audio response from the model.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public CompletionAudio() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompletionAudio(CompletionAudio completionAudio)
        : base(completionAudio) { }
#pragma warning restore CS8618

    public CompletionAudio(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompletionAudio(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompletionAudioFromRaw.FromRawUnchecked"/>
    public static CompletionAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CompletionAudio(string id)
        : this()
    {
        this.ID = id;
    }
}

class CompletionAudioFromRaw : IFromRawJson<CompletionAudio>
{
    /// <inheritdoc/>
    public CompletionAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompletionAudio.FromRawUnchecked(rawData);
}
