using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionMessageCustomToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionMessageCustomToolCall
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };

        string expectedID = "id";
        Custom expectedCustom = new() { Input = "input", Name = "name" };
        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustom, model.Custom);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionMessageCustomToolCall
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageCustomToolCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionMessageCustomToolCall
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageCustomToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Custom expectedCustom = new() { Input = "input", Name = "name" };
        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustom, deserialized.Custom);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionMessageCustomToolCall
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionMessageCustomToolCall
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };

        ChatCompletionMessageCustomToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Custom { Input = "input", Name = "name" };

        string expectedInput = "input";
        string expectedName = "name";

        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Custom { Input = "input", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Custom>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Custom { Input = "input", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Custom>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedInput = "input";
        string expectedName = "name";

        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Custom { Input = "input", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Custom { Input = "input", Name = "name" };

        Custom copied = new(model);

        Assert.Equal(model, copied);
    }
}
