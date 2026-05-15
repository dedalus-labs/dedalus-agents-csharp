using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionContentPartRefusalParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartRefusalParam { Refusal = "refusal" };

        string expectedRefusal = "refusal";
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedRefusal, model.Refusal);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartRefusalParam { Refusal = "refusal" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartRefusalParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionContentPartRefusalParam { Refusal = "refusal" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartRefusalParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRefusal = "refusal";
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedRefusal, deserialized.Refusal);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionContentPartRefusalParam { Refusal = "refusal" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionContentPartRefusalParam { Refusal = "refusal" };

        ChatCompletionContentPartRefusalParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
