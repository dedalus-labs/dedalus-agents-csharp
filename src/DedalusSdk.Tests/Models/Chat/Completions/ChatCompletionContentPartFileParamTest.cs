using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionContentPartFileParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartFileParam
        {
            File = new()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            },
        };

        File expectedFile = new()
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");

        Assert.Equal(expectedFile, model.File);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartFileParam
        {
            File = new()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartFileParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionContentPartFileParam
        {
            File = new()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartFileParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        File expectedFile = new()
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");

        Assert.Equal(expectedFile, deserialized.File);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionContentPartFileParam
        {
            File = new()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionContentPartFileParam
        {
            File = new()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            },
        };

        ChatCompletionContentPartFileParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };

        string expectedFileData = "file_data";
        string expectedFileID = "file_id";
        string expectedFilename = "filename";

        Assert.Equal(expectedFileData, model.FileData);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilename, model.Filename);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFileData = "file_data";
        string expectedFileID = "file_id";
        string expectedFilename = "filename";

        Assert.Equal(expectedFileData, deserialized.FileData);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilename, deserialized.Filename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File { };

        Assert.Null(model.FileData);
        Assert.False(model.RawData.ContainsKey("file_data"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new File { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new File
        {
            // Null should be interpreted as omitted for these properties
            FileData = null,
            FileID = null,
            Filename = null,
        };

        Assert.Null(model.FileData);
        Assert.False(model.RawData.ContainsKey("file_data"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            // Null should be interpreted as omitted for these properties
            FileData = null,
            FileID = null,
            Filename = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            FileData = "file_data",
            FileID = "file_id",
            Filename = "filename",
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}
