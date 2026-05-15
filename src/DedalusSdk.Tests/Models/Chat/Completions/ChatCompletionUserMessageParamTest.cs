using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionUserMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string", Name = "name" };

        ChatCompletionUserMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("user");
        string expectedName = "name";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionUserMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionUserMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChatCompletionUserMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("user");
        string expectedName = "name";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string" };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionUserMessageParam
        {
            Content = "string",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionUserMessageParam
        {
            Content = "string",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionUserMessageParam { Content = "string", Name = "name" };

        ChatCompletionUserMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionUserMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionUserMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void ChatCompletionRequestUserMessageContentArrayValidationWorks()
    {
        ChatCompletionUserMessageParamContent value = new(
            [new UnnamedSchemaWithArrayParent2(new ChatCompletionContentPartTextParam("text"))]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionUserMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionUserMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionRequestUserMessageContentArraySerializationRoundtripWorks()
    {
        ChatCompletionUserMessageParamContent value = new(
            [new UnnamedSchemaWithArrayParent2(new ChatCompletionContentPartTextParam("text"))]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionUserMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent2Test : TestBase
{
    [Fact]
    public void ChatCompletionContentPartTextParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartTextParam("text");
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartImageParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartImageParam(
            new ImageUrl() { Url = "https://example.com", Detail = Detail.Auto }
        );
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartInputAudioParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartInputAudioParam(
            new InputAudio() { Data = "data", Format = InputAudioFormat.Wav }
        );
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartFileParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartFileParam(
            new File()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartTextParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartTextParam("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent2>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionContentPartImageParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartImageParam(
            new ImageUrl() { Url = "https://example.com", Detail = Detail.Auto }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent2>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionContentPartInputAudioParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartInputAudioParam(
            new InputAudio() { Data = "data", Format = InputAudioFormat.Wav }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent2>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionContentPartFileParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent2 value = new ChatCompletionContentPartFileParam(
            new File()
            {
                FileData = "file_data",
                FileID = "file_id",
                Filename = "filename",
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent2>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
