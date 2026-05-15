using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using System = System;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Learn about [image inputs](/docs/guides/vision).
///
/// <para>Fields: - type (required): Literal["image_url"] - image_url (required): ImageUrl</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionContentPartImageParam,
        ChatCompletionContentPartImageParamFromRaw
    >)
)]
public sealed record class ChatCompletionContentPartImageParam : JsonModel
{
    /// <summary>
    /// Schema for ImageUrl.
    ///
    /// <para>Fields: - url (required): AnyUrl - detail (optional): Literal["auto",
    /// "low", "high"]</para>
    /// </summary>
    public required ImageUrl ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageUrl>("image_url");
        }
        init { this._rawData.Set("image_url", value); }
    }

    /// <summary>
    /// The type of the content part.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ImageUrl.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("image_url")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ChatCompletionContentPartImageParam()
    {
        this.Type = JsonSerializer.SerializeToElement("image_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionContentPartImageParam(
        ChatCompletionContentPartImageParam chatCompletionContentPartImageParam
    )
        : base(chatCompletionContentPartImageParam) { }
#pragma warning restore CS8618

    public ChatCompletionContentPartImageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionContentPartImageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionContentPartImageParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionContentPartImageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionContentPartImageParam(ImageUrl imageUrl)
        : this()
    {
        this.ImageUrl = imageUrl;
    }
}

class ChatCompletionContentPartImageParamFromRaw : IFromRawJson<ChatCompletionContentPartImageParam>
{
    /// <inheritdoc/>
    public ChatCompletionContentPartImageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionContentPartImageParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for ImageUrl.
///
/// <para>Fields: - url (required): AnyUrl - detail (optional): Literal["auto", "low", "high"]</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageUrl, ImageUrlFromRaw>))]
public sealed record class ImageUrl : JsonModel
{
    /// <summary>
    /// Either a URL of the image or the base64 encoded image data.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Specifies the detail level of the image. Learn more in the [Vision guide](/docs/guides/vision#low-or-high-fidelity-image-understanding).
    /// </summary>
    public ApiEnum<string, Detail>? Detail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Detail>>("detail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        this.Detail?.Validate();
    }

    public ImageUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageUrl(ImageUrl imageUrl)
        : base(imageUrl) { }
#pragma warning restore CS8618

    public ImageUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageUrlFromRaw.FromRawUnchecked"/>
    public static ImageUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageUrl(string url)
        : this()
    {
        this.Url = url;
    }
}

class ImageUrlFromRaw : IFromRawJson<ImageUrl>
{
    /// <inheritdoc/>
    public ImageUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageUrl.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the detail level of the image. Learn more in the [Vision guide](/docs/guides/vision#low-or-high-fidelity-image-understanding).
/// </summary>
[JsonConverter(typeof(DetailConverter))]
public enum Detail
{
    Auto,
    Low,
    High,
}

sealed class DetailConverter : JsonConverter<Detail>
{
    public override Detail Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Detail.Auto,
            "low" => Detail.Low,
            "high" => Detail.High,
            _ => (Detail)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Detail value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Detail.Auto => "auto",
                Detail.Low => "low",
                Detail.High => "high",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
