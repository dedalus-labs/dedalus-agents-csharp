using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class CompletionChatCompletionMessageToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };

        string expectedID = "id";
        Function expectedFunction = new() { Arguments = "arguments", Name = "name" };
        JsonElement expectedType = JsonSerializer.SerializeToElement("function");
        string expectedThoughtSignature = "thought_signature";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFunction, model.Function);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedThoughtSignature, model.ThoughtSignature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionChatCompletionMessageToolCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionChatCompletionMessageToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Function expectedFunction = new() { Arguments = "arguments", Name = "name" };
        JsonElement expectedType = JsonSerializer.SerializeToElement("function");
        string expectedThoughtSignature = "thought_signature";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedThoughtSignature, deserialized.ThoughtSignature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
        };

        Assert.Null(model.ThoughtSignature);
        Assert.False(model.RawData.ContainsKey("thought_signature"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },

            ThoughtSignature = null,
        };

        Assert.Null(model.ThoughtSignature);
        Assert.True(model.RawData.ContainsKey("thought_signature"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },

            ThoughtSignature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CompletionChatCompletionMessageToolCall
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };

        CompletionChatCompletionMessageToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Function { Arguments = "arguments", Name = "name" };

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Function { Arguments = "arguments", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Function>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Function { Arguments = "arguments", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Function>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Function { Arguments = "arguments", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Function { Arguments = "arguments", Name = "name" };

        Function copied = new(model);

        Assert.Equal(model, copied);
    }
}
