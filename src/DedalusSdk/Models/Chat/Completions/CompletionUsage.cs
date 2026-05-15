using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Usage statistics for the completion request.
///
/// <para>Fields: - completion_tokens (required): int - prompt_tokens (required):
/// int - total_tokens (required): int - completion_tokens_details (optional): CompletionTokensDetails
/// - prompt_tokens_details (optional): PromptTokensDetails</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CompletionUsage, CompletionUsageFromRaw>))]
public sealed record class CompletionUsage : JsonModel
{
    /// <summary>
    /// Number of tokens in the generated completion.
    /// </summary>
    public required long CompletionTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("completion_tokens");
        }
        init { this._rawData.Set("completion_tokens", value); }
    }

    /// <summary>
    /// Number of tokens in the prompt.
    /// </summary>
    public required long PromptTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("prompt_tokens");
        }
        init { this._rawData.Set("prompt_tokens", value); }
    }

    /// <summary>
    /// Total number of tokens used in the request (prompt + completion).
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tokens");
        }
        init { this._rawData.Set("total_tokens", value); }
    }

    /// <summary>
    /// Breakdown of tokens used in a completion.
    /// </summary>
    public CompletionTokensDetails? CompletionTokensDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompletionTokensDetails>(
                "completion_tokens_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completion_tokens_details", value);
        }
    }

    /// <summary>
    /// Breakdown of tokens used in the prompt.
    /// </summary>
    public PromptTokensDetails? PromptTokensDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PromptTokensDetails>("prompt_tokens_details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt_tokens_details", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompletionTokens;
        _ = this.PromptTokens;
        _ = this.TotalTokens;
        this.CompletionTokensDetails?.Validate();
        this.PromptTokensDetails?.Validate();
    }

    public CompletionUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompletionUsage(CompletionUsage completionUsage)
        : base(completionUsage) { }
#pragma warning restore CS8618

    public CompletionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompletionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompletionUsageFromRaw.FromRawUnchecked"/>
    public static CompletionUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompletionUsageFromRaw : IFromRawJson<CompletionUsage>
{
    /// <inheritdoc/>
    public CompletionUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompletionUsage.FromRawUnchecked(rawData);
}
