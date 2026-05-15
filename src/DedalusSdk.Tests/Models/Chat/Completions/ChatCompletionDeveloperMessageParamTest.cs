using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionDeveloperMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string", Name = "name" };

        ChatCompletionDeveloperMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("developer");
        string expectedName = "name";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionDeveloperMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionDeveloperMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChatCompletionDeveloperMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("developer");
        string expectedName = "name";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string" };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionDeveloperMessageParam
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
        var model = new ChatCompletionDeveloperMessageParam
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
        var model = new ChatCompletionDeveloperMessageParam { Content = "string", Name = "name" };

        ChatCompletionDeveloperMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionDeveloperMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionDeveloperMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void ChatCompletionRequestDeveloperMessageContentArrayValidationWorks()
    {
        ChatCompletionDeveloperMessageParamContent value = new(
            [new ChatCompletionContentPartTextParam("text")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionDeveloperMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionDeveloperMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionRequestDeveloperMessageContentArraySerializationRoundtripWorks()
    {
        ChatCompletionDeveloperMessageParamContent value = new(
            [new ChatCompletionContentPartTextParam("text")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionDeveloperMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
