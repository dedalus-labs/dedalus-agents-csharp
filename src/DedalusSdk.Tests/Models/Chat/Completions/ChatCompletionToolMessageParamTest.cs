using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionToolMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionToolMessageParam
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };

        ChatCompletionToolMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("tool");
        string expectedToolCallID = "tool_call_id";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedToolCallID, model.ToolCallID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionToolMessageParam
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionToolMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionToolMessageParam
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionToolMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChatCompletionToolMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("tool");
        string expectedToolCallID = "tool_call_id";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedToolCallID, deserialized.ToolCallID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionToolMessageParam
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionToolMessageParam
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };

        ChatCompletionToolMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionToolMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionToolMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void ChatCompletionRequestToolMessageContentArrayValidationWorks()
    {
        ChatCompletionToolMessageParamContent value = new(
            [new ChatCompletionContentPartTextParam("text")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionToolMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionToolMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionRequestToolMessageContentArraySerializationRoundtripWorks()
    {
        ChatCompletionToolMessageParamContent value = new(
            [new ChatCompletionContentPartTextParam("text")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionToolMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
