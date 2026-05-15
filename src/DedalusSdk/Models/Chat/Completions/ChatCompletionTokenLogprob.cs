using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Token log probability information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChatCompletionTokenLogprob, ChatCompletionTokenLogprobFromRaw>)
)]
public sealed record class ChatCompletionTokenLogprob : JsonModel
{
    /// <summary>
    /// The token.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// A list of integers representing the UTF-8 bytes representation of the token.
    /// Useful in instances where characters are represented by multiple tokens and
    /// their byte representations must be combined to generate the correct text
    /// representation. Can be `null` if there is no bytes representation for the token.
    /// </summary>
    public required IReadOnlyList<long>? Bytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("bytes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "bytes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The log probability of this token, if it is within the top 20 most likely
    /// tokens. Otherwise, the value `-9999.0` is used to signify that the token is
    /// very unlikely.
    /// </summary>
    public required double Logprob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("logprob");
        }
        init { this._rawData.Set("logprob", value); }
    }

    /// <summary>
    /// List of the most likely tokens and their log probability, at this token position.
    /// In rare cases, there may be fewer than the number of requested `top_logprobs` returned.
    /// </summary>
    public required IReadOnlyList<TopLogprob> TopLogprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopLogprob>>("top_logprobs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopLogprob>>(
                "top_logprobs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.Bytes;
        _ = this.Logprob;
        foreach (var item in this.TopLogprobs)
        {
            item.Validate();
        }
    }

    public ChatCompletionTokenLogprob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionTokenLogprob(ChatCompletionTokenLogprob chatCompletionTokenLogprob)
        : base(chatCompletionTokenLogprob) { }
#pragma warning restore CS8618

    public ChatCompletionTokenLogprob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionTokenLogprob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionTokenLogprobFromRaw.FromRawUnchecked"/>
    public static ChatCompletionTokenLogprob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionTokenLogprobFromRaw : IFromRawJson<ChatCompletionTokenLogprob>
{
    /// <inheritdoc/>
    public ChatCompletionTokenLogprob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionTokenLogprob.FromRawUnchecked(rawData);
}

/// <summary>
/// Token and its log probability.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopLogprob, TopLogprobFromRaw>))]
public sealed record class TopLogprob : JsonModel
{
    /// <summary>
    /// The token.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// A list of integers representing the UTF-8 bytes representation of the token.
    /// Useful in instances where characters are represented by multiple tokens and
    /// their byte representations must be combined to generate the correct text
    /// representation. Can be `null` if there is no bytes representation for the token.
    /// </summary>
    public required IReadOnlyList<long>? Bytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("bytes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "bytes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The log probability of this token, if it is within the top 20 most likely
    /// tokens. Otherwise, the value `-9999.0` is used to signify that the token is
    /// very unlikely.
    /// </summary>
    public required double Logprob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("logprob");
        }
        init { this._rawData.Set("logprob", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.Bytes;
        _ = this.Logprob;
    }

    public TopLogprob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopLogprob(TopLogprob topLogprob)
        : base(topLogprob) { }
#pragma warning restore CS8618

    public TopLogprob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopLogprob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopLogprobFromRaw.FromRawUnchecked"/>
    public static TopLogprob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopLogprobFromRaw : IFromRawJson<TopLogprob>
{
    /// <inheritdoc/>
    public TopLogprob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopLogprob.FromRawUnchecked(rawData);
}
