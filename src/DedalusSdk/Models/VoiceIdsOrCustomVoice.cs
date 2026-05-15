using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models;

/// <summary>
/// Custom voice reference.
///
/// <para>Fields: - id (required): str</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceIdsOrCustomVoice, VoiceIdsOrCustomVoiceFromRaw>))]
public sealed record class VoiceIdsOrCustomVoice : JsonModel
{
    /// <summary>
    /// The custom voice ID, e.g. `voice_1234`.
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

    public VoiceIdsOrCustomVoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceIdsOrCustomVoice(VoiceIdsOrCustomVoice voiceIdsOrCustomVoice)
        : base(voiceIdsOrCustomVoice) { }
#pragma warning restore CS8618

    public VoiceIdsOrCustomVoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceIdsOrCustomVoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoiceIdsOrCustomVoiceFromRaw.FromRawUnchecked"/>
    public static VoiceIdsOrCustomVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VoiceIdsOrCustomVoice(string id)
        : this()
    {
        this.ID = id;
    }
}

class VoiceIdsOrCustomVoiceFromRaw : IFromRawJson<VoiceIdsOrCustomVoice>
{
    /// <inheritdoc/>
    public VoiceIdsOrCustomVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoiceIdsOrCustomVoice.FromRawUnchecked(rawData);
}
