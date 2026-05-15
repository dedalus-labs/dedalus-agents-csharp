using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Images;

/// <summary>
/// Response from image generation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImagesResponse, ImagesResponseFromRaw>))]
public sealed record class ImagesResponse : JsonModel
{
    /// <summary>
    /// Unix timestamp when images were created
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// List of generated images
    /// </summary>
    public required IReadOnlyList<Image> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Image>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Image>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ImagesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImagesResponse(ImagesResponse imagesResponse)
        : base(imagesResponse) { }
#pragma warning restore CS8618

    public ImagesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImagesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImagesResponseFromRaw.FromRawUnchecked"/>
    public static ImagesResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImagesResponseFromRaw : IFromRawJson<ImagesResponse>
{
    /// <inheritdoc/>
    public ImagesResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImagesResponse.FromRawUnchecked(rawData);
}
