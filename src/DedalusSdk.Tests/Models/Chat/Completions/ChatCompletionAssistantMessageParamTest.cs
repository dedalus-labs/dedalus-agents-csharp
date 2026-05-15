using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionAssistantMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        CompletionAudio expectedAudio = new("id");
        Content expectedContent = "string";
        FunctionCall expectedFunctionCall = new() { Arguments = "arguments", Name = "name" };
        string expectedName = "name";
        string expectedRefusal = "refusal";
        List<ToolCall> expectedToolCalls =
        [
            new CompletionChatCompletionMessageToolCall()
            {
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                ThoughtSignature = "thought_signature",
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedAudio, model.Audio);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFunctionCall, model.FunctionCall);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRefusal, model.Refusal);
        Assert.NotNull(model.ToolCalls);
        Assert.Equal(expectedToolCalls.Count, model.ToolCalls.Count);
        for (int i = 0; i < expectedToolCalls.Count; i++)
        {
            Assert.Equal(expectedToolCalls[i], model.ToolCalls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionAssistantMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionAssistantMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        CompletionAudio expectedAudio = new("id");
        Content expectedContent = "string";
        FunctionCall expectedFunctionCall = new() { Arguments = "arguments", Name = "name" };
        string expectedName = "name";
        string expectedRefusal = "refusal";
        List<ToolCall> expectedToolCalls =
        [
            new CompletionChatCompletionMessageToolCall()
            {
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                ThoughtSignature = "thought_signature",
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedAudio, deserialized.Audio);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFunctionCall, deserialized.FunctionCall);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRefusal, deserialized.Refusal);
        Assert.NotNull(deserialized.ToolCalls);
        Assert.Equal(expectedToolCalls.Count, deserialized.ToolCalls.Count);
        for (int i = 0; i < expectedToolCalls.Count; i++)
        {
            Assert.Equal(expectedToolCalls[i], deserialized.ToolCalls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",

            // Null should be interpreted as omitted for these properties
            Name = null,
            ToolCalls = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",

            // Null should be interpreted as omitted for these properties
            Name = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Name = "name",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        Assert.Null(model.Audio);
        Assert.False(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Refusal);
        Assert.False(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Name = "name",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Name = "name",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],

            Audio = null,
            Content = null,
            FunctionCall = null,
            Refusal = null,
        };

        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.FunctionCall);
        Assert.True(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Refusal);
        Assert.True(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Name = "name",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],

            Audio = null,
            Content = null,
            FunctionCall = null,
            Refusal = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionAssistantMessageParam
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };

        ChatCompletionAssistantMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Content value = "string";
        value.Validate();
    }

    [Fact]
    public void ChatCompletionRequestAssistantMessageContentArrayValidationWorks()
    {
        Content value = new(
            [new UnnamedSchemaWithArrayParent1(new ChatCompletionContentPartTextParam("text"))]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Content value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionRequestAssistantMessageContentArraySerializationRoundtripWorks()
    {
        Content value = new(
            [new UnnamedSchemaWithArrayParent1(new ChatCompletionContentPartTextParam("text"))]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent1Test : TestBase
{
    [Fact]
    public void ChatCompletionContentPartTextParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent1 value = new ChatCompletionContentPartTextParam("text");
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartRefusalParamValidationWorks()
    {
        UnnamedSchemaWithArrayParent1 value = new ChatCompletionContentPartRefusalParam("refusal");
        value.Validate();
    }

    [Fact]
    public void ChatCompletionContentPartTextParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent1 value = new ChatCompletionContentPartTextParam("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionContentPartRefusalParamSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent1 value = new ChatCompletionContentPartRefusalParam("refusal");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent1>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCall { Arguments = "arguments", Name = "name" };

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionCall { Arguments = "arguments", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCall { Arguments = "arguments", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
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
        var model = new FunctionCall { Arguments = "arguments", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionCall { Arguments = "arguments", Name = "name" };

        FunctionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolCallTest : TestBase
{
    [Fact]
    public void ChatCompletionMessageValidationWorks()
    {
        ToolCall value = new CompletionChatCompletionMessageToolCall()
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionMessageCustomValidationWorks()
    {
        ToolCall value = new ChatCompletionMessageCustomToolCall()
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionMessageSerializationRoundtripWorks()
    {
        ToolCall value = new CompletionChatCompletionMessageToolCall()
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolCall>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionMessageCustomSerializationRoundtripWorks()
    {
        ToolCall value = new ChatCompletionMessageCustomToolCall()
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolCall>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
