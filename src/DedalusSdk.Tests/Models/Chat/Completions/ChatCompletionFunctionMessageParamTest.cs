using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionFunctionMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionFunctionMessageParam { Content = "content", Name = "name" };

        string expectedContent = "content";
        string expectedName = "name";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("function");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionFunctionMessageParam { Content = "content", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionFunctionMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionFunctionMessageParam { Content = "content", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionFunctionMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedName = "name";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("function");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionFunctionMessageParam { Content = "content", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionFunctionMessageParam { Content = "content", Name = "name" };

        ChatCompletionFunctionMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
