using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models;

/// <summary>
/// Structured model selection entry used in request payloads.
///
/// <para>Supports OpenAI-style semantics (string model id) while enabling optional
/// per-model default settings for Dedalus multi-model routing.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DedalusModel, DedalusModelFromRaw>))]
public sealed record class DedalusModel : JsonModel
{
    /// <summary>
    /// Model identifier with provider prefix (e.g., 'openai/gpt-5', 'anthropic/claude-3-5-sonnet').
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Optional default generation settings (e.g., temperature, max_tokens) applied
    /// when this model is selected.
    /// </summary>
    public ModelSettings? Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelSettings>("settings");
        }
        init { this._rawData.Set("settings", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Model;
        this.Settings?.Validate();
    }

    public DedalusModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DedalusModel(DedalusModel dedalusModel)
        : base(dedalusModel) { }
#pragma warning restore CS8618

    public DedalusModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DedalusModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DedalusModelFromRaw.FromRawUnchecked"/>
    public static DedalusModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DedalusModel(string model)
        : this()
    {
        this.Model = model;
    }
}

class DedalusModelFromRaw : IFromRawJson<DedalusModel>
{
    /// <inheritdoc/>
    public DedalusModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DedalusModel.FromRawUnchecked(rawData);
}
