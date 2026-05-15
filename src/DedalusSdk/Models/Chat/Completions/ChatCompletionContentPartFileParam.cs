using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Learn about [file inputs](/docs/guides/text) for text generation.
///
/// <para>Fields: - type (required): Literal["file"] - file (required): File</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionContentPartFileParam,
        ChatCompletionContentPartFileParamFromRaw
    >)
)]
public sealed record class ChatCompletionContentPartFileParam : JsonModel
{
    /// <summary>
    /// Schema for File.
    ///
    /// <para>Fields: - filename (optional): str - file_data (optional): str - file_id
    /// (optional): str</para>
    /// </summary>
    public required File File
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<File>("file");
        }
        init { this._rawData.Set("file", value); }
    }

    /// <summary>
    /// The type of the content part. Always `file`.
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
        this.File.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ChatCompletionContentPartFileParam()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionContentPartFileParam(
        ChatCompletionContentPartFileParam chatCompletionContentPartFileParam
    )
        : base(chatCompletionContentPartFileParam) { }
#pragma warning restore CS8618

    public ChatCompletionContentPartFileParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionContentPartFileParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionContentPartFileParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionContentPartFileParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionContentPartFileParam(File file)
        : this()
    {
        this.File = file;
    }
}

class ChatCompletionContentPartFileParamFromRaw : IFromRawJson<ChatCompletionContentPartFileParam>
{
    /// <inheritdoc/>
    public ChatCompletionContentPartFileParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionContentPartFileParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for File.
///
/// <para>Fields: - filename (optional): str - file_data (optional): str - file_id
/// (optional): str</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    /// <summary>
    /// The base64 encoded file data, used when passing the file to the model  as
    /// a string.
    /// </summary>
    public string? FileData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("file_data", value);
        }
    }

    /// <summary>
    /// The ID of an uploaded file to use as input.
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("file_id", value);
        }
    }

    /// <summary>
    /// The name of the file, used when passing the file to the model as a  string.
    /// </summary>
    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileData;
        _ = this.FileID;
        _ = this.Filename;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}
