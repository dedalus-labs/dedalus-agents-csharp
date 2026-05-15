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
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChoiceLogprobs, ChoiceLogprobsFromRaw>))]
public sealed record class ChoiceLogprobs : JsonModel
{
    /// <summary>
    /// A list of message content tokens with log probability information.
    /// </summary>
    public IReadOnlyList<ChatCompletionTokenLogprob>? Content
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
    public IReadOnlyList<ChatCompletionTokenLogprob>? Refusal
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

    public ChoiceLogprobs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChoiceLogprobs(ChoiceLogprobs choiceLogprobs)
        : base(choiceLogprobs) { }
#pragma warning restore CS8618

    public ChoiceLogprobs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChoiceLogprobs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChoiceLogprobsFromRaw.FromRawUnchecked"/>
    public static ChoiceLogprobs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChoiceLogprobsFromRaw : IFromRawJson<ChoiceLogprobs>
{
    /// <inheritdoc/>
    public ChoiceLogprobs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChoiceLogprobs.FromRawUnchecked(rawData);
}
