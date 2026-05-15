using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models;

/// <summary>
/// Schema for Function.
///
/// <para>Fields: - name (required): str</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FunctionDefinition, FunctionDefinitionFromRaw>))]
public sealed record class FunctionDefinition : JsonModel
{
    /// <summary>
    /// The name of the function to call.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public FunctionDefinition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionDefinition(FunctionDefinition functionDefinition)
        : base(functionDefinition) { }
#pragma warning restore CS8618

    public FunctionDefinition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionDefinition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionDefinitionFromRaw.FromRawUnchecked"/>
    public static FunctionDefinition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionDefinition(string name)
        : this()
    {
        this.Name = name;
    }
}

class FunctionDefinitionFromRaw : IFromRawJson<FunctionDefinition>
{
    /// <inheritdoc/>
    public FunctionDefinition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionDefinition.FromRawUnchecked(rawData);
}
