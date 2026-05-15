using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Images;

/// <summary>
/// Single image object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Image, ImageFromRaw>))]
public sealed record class Image : JsonModel
{
    /// <summary>
    /// Base64-encoded image data (if response_format=b64_json)
    /// </summary>
    public string? B64Json
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("b64_json");
        }
        init { this._rawData.Set("b64_json", value); }
    }

    /// <summary>
    /// Revised prompt used for generation (dall-e-3)
    /// </summary>
    public string? RevisedPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("revised_prompt");
        }
        init { this._rawData.Set("revised_prompt", value); }
    }

    /// <summary>
    /// URL of the generated image (if response_format=url)
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.B64Json;
        _ = this.RevisedPrompt;
        _ = this.Url;
    }

    public Image() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Image(Image image)
        : base(image) { }
#pragma warning restore CS8618

    public Image(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Image(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFromRaw.FromRawUnchecked"/>
    public static Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFromRaw : IFromRawJson<Image>
{
    /// <inheritdoc/>
    public Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Image.FromRawUnchecked(rawData);
}
