using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Log probability information for the choice.
///
/// <para>Fields: - content (required): list[ChatCompletionTokenLogprob] - refusal
/// (required): list[ChatCompletionTokenLogprob]</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StreamChoiceLogprobs, StreamChoiceLogprobsFromRaw>))]
public sealed record class StreamChoiceLogprobs : JsonModel
{
    /// <summary>
    /// A list of message content tokens with log probability information.
    /// </summary>
    public required IReadOnlyList<ChatCompletionTokenLogprob>? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChatCompletionTokenLogprob>>(
                "content"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionTokenLogprob>?>(
                "content",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A list of message refusal tokens with log probability information.
    /// </summary>
    public required IReadOnlyList<ChatCompletionTokenLogprob>? Refusal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChatCompletionTokenLogprob>>(
                "refusal"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionTokenLogprob>?>(
                "refusal",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Refusal ?? [])
        {
            item.Validate();
        }
    }

    public StreamChoiceLogprobs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamChoiceLogprobs(StreamChoiceLogprobs streamChoiceLogprobs)
        : base(streamChoiceLogprobs) { }
#pragma warning restore CS8618

    public StreamChoiceLogprobs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamChoiceLogprobs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StreamChoiceLogprobsFromRaw.FromRawUnchecked"/>
    public static StreamChoiceLogprobs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StreamChoiceLogprobsFromRaw : IFromRawJson<StreamChoiceLogprobs>
{
    /// <inheritdoc/>
    public StreamChoiceLogprobs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StreamChoiceLogprobs.FromRawUnchecked(rawData);
}
