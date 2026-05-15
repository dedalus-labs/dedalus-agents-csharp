using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Details about the input tokens billed for this request.
///
/// <para>Fields:   - text_tokens (optional): int   - audio_tokens (optional): int</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InputTokenDetails, InputTokenDetailsFromRaw>))]
public sealed record class InputTokenDetails : JsonModel
{
    /// <summary>
    /// Number of audio tokens billed for this request.
    /// </summary>
    public long? AudioTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("audio_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audio_tokens", value);
        }
    }

    /// <summary>
    /// Number of text tokens billed for this request.
    /// </summary>
    public long? TextTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("text_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioTokens;
        _ = this.TextTokens;
    }

    public InputTokenDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InputTokenDetails(InputTokenDetails inputTokenDetails)
        : base(inputTokenDetails) { }
#pragma warning restore CS8618

    public InputTokenDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputTokenDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputTokenDetailsFromRaw.FromRawUnchecked"/>
    public static InputTokenDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputTokenDetailsFromRaw : IFromRawJson<InputTokenDetails>
{
    /// <inheritdoc/>
    public InputTokenDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputTokenDetails.FromRawUnchecked(rawData);
}
