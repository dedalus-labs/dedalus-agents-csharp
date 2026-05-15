using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

/// <summary>
/// **gpt-5 and o-series models only**
///
/// <para>Configuration options for [reasoning models](https://platform.openai.com/docs/guides/reasoning).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reasoning, ReasoningFromRaw>))]
public sealed record class Reasoning : JsonModel
{
    public ApiEnum<string, Effort>? Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Effort>>("effort");
        }
        init { this._rawData.Set("effort", value); }
    }

    public ApiEnum<string, GenerateSummary>? GenerateSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GenerateSummary>>(
                "generate_summary"
            );
        }
        init { this._rawData.Set("generate_summary", value); }
    }

    public ApiEnum<string, Summary>? Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Summary>>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Effort?.Validate();
        this.GenerateSummary?.Validate();
        this.Summary?.Validate();
    }

    public Reasoning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reasoning(Reasoning reasoning)
        : base(reasoning) { }
#pragma warning restore CS8618

    public Reasoning(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Reasoning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReasoningFromRaw.FromRawUnchecked"/>
    public static Reasoning FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReasoningFromRaw : IFromRawJson<Reasoning>
{
    /// <inheritdoc/>
    public Reasoning FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Reasoning.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EffortConverter))]
public enum Effort
{
    None,
    Minimal,
    Low,
    Medium,
    High,
    Xhigh,
}

sealed class EffortConverter : JsonConverter<Effort>
{
    public override Effort Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Effort.None,
            "minimal" => Effort.Minimal,
            "low" => Effort.Low,
            "medium" => Effort.Medium,
            "high" => Effort.High,
            "xhigh" => Effort.Xhigh,
            _ => (Effort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Effort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Effort.None => "none",
                Effort.Minimal => "minimal",
                Effort.Low => "low",
                Effort.Medium => "medium",
                Effort.High => "high",
                Effort.Xhigh => "xhigh",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GenerateSummaryConverter))]
public enum GenerateSummary
{
    Auto,
    Concise,
    Detailed,
}

sealed class GenerateSummaryConverter : JsonConverter<GenerateSummary>
{
    public override GenerateSummary Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => GenerateSummary.Auto,
            "concise" => GenerateSummary.Concise,
            "detailed" => GenerateSummary.Detailed,
            _ => (GenerateSummary)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GenerateSummary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GenerateSummary.Auto => "auto",
                GenerateSummary.Concise => "concise",
                GenerateSummary.Detailed => "detailed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SummaryConverter))]
public enum Summary
{
    Auto,
    Concise,
    Detailed,
}

sealed class SummaryConverter : JsonConverter<Summary>
{
    public override Summary Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Summary.Auto,
            "concise" => Summary.Concise,
            "detailed" => Summary.Detailed,
            _ => (Summary)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Summary value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Summary.Auto => "auto",
                Summary.Concise => "concise",
                Summary.Detailed => "detailed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
