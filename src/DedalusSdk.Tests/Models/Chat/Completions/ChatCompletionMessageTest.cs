using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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

        string expectedContent = "content";
        string expectedRefusal = "refusal";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        List<Annotation> expectedAnnotations =
        [
            new(
                new UrlCitation()
                {
                    EndIndex = 0,
                    StartIndex = 0,
                    Title = "title",
                    Url = "url",
                }
            ),
        ];
        ChatCompletionMessageAudio expectedAudio = new()
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };
        ChatCompletionMessageFunctionCall expectedFunctionCall = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        List<ChatCompletionMessageToolCall> expectedToolCalls =
        [
            new CompletionChatCompletionMessageToolCall()
            {
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                ThoughtSignature = "thought_signature",
            },
        ];

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRefusal, model.Refusal);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.NotNull(model.Annotations);
        Assert.Equal(expectedAnnotations.Count, model.Annotations.Count);
        for (int i = 0; i < expectedAnnotations.Count; i++)
        {
            Assert.Equal(expectedAnnotations[i], model.Annotations[i]);
        }
        Assert.Equal(expectedAudio, model.Audio);
        Assert.Equal(expectedFunctionCall, model.FunctionCall);
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
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedRefusal = "refusal";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        List<Annotation> expectedAnnotations =
        [
            new(
                new UrlCitation()
                {
                    EndIndex = 0,
                    StartIndex = 0,
                    Title = "title",
                    Url = "url",
                }
            ),
        ];
        ChatCompletionMessageAudio expectedAudio = new()
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };
        ChatCompletionMessageFunctionCall expectedFunctionCall = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        List<ChatCompletionMessageToolCall> expectedToolCalls =
        [
            new CompletionChatCompletionMessageToolCall()
            {
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                ThoughtSignature = "thought_signature",
            },
        ];

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRefusal, deserialized.Refusal);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.NotNull(deserialized.Annotations);
        Assert.Equal(expectedAnnotations.Count, deserialized.Annotations.Count);
        for (int i = 0; i < expectedAnnotations.Count; i++)
        {
            Assert.Equal(expectedAnnotations[i], deserialized.Annotations[i]);
        }
        Assert.Equal(expectedAudio, deserialized.Audio);
        Assert.Equal(expectedFunctionCall, deserialized.FunctionCall);
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
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },

            // Null should be interpreted as omitted for these properties
            Annotations = null,
            FunctionCall = null,
            ToolCalls = null,
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },

            // Null should be interpreted as omitted for these properties
            Annotations = null,
            FunctionCall = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        };

        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionMessage
        {
            Content = "content",
            Refusal = "refusal",
            Annotations =
            [
                new(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            ],
            Audio = new()
            {
                ID = "id",
                Data = "data",
                ExpiresAt = 0,
                Transcript = "transcript",
            },
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
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

        ChatCompletionMessage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AnnotationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Annotation
        {
            UrlCitation = new()
            {
                EndIndex = 0,
                StartIndex = 0,
                Title = "title",
                Url = "url",
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("url_citation");
        UrlCitation expectedUrlCitation = new()
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrlCitation, model.UrlCitation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Annotation
        {
            UrlCitation = new()
            {
                EndIndex = 0,
                StartIndex = 0,
                Title = "title",
                Url = "url",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Annotation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Annotation
        {
            UrlCitation = new()
            {
                EndIndex = 0,
                StartIndex = 0,
                Title = "title",
                Url = "url",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Annotation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("url_citation");
        UrlCitation expectedUrlCitation = new()
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrlCitation, deserialized.UrlCitation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Annotation
        {
            UrlCitation = new()
            {
                EndIndex = 0,
                StartIndex = 0,
                Title = "title",
                Url = "url",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Annotation
        {
            UrlCitation = new()
            {
                EndIndex = 0,
                StartIndex = 0,
                Title = "title",
                Url = "url",
            },
        };

        Annotation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlCitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        long expectedEndIndex = 0;
        long expectedStartIndex = 0;
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedStartIndex, model.StartIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlCitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlCitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedEndIndex = 0;
        long expectedStartIndex = 0;
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        UrlCitation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionMessageAudioTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionMessageAudio
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };

        string expectedID = "id";
        string expectedData = "data";
        long expectedExpiresAt = 0;
        string expectedTranscript = "transcript";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedTranscript, model.Transcript);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionMessageAudio
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageAudio>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionMessageAudio
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageAudio>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedData = "data";
        long expectedExpiresAt = 0;
        string expectedTranscript = "transcript";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedTranscript, deserialized.Transcript);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionMessageAudio
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionMessageAudio
        {
            ID = "id",
            Data = "data",
            ExpiresAt = 0,
            Transcript = "transcript",
        };

        ChatCompletionMessageAudio copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionMessageFunctionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionMessageFunctionCall
        {
            Arguments = "arguments",
            Name = "name",
        };

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionMessageFunctionCall
        {
            Arguments = "arguments",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageFunctionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionMessageFunctionCall
        {
            Arguments = "arguments",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageFunctionCall>(
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
        var model = new ChatCompletionMessageFunctionCall
        {
            Arguments = "arguments",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionMessageFunctionCall
        {
            Arguments = "arguments",
            Name = "name",
        };

        ChatCompletionMessageFunctionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionMessageToolCallTest : TestBase
{
    [Fact]
    public void ChatCompletionMessageValidationWorks()
    {
        ChatCompletionMessageToolCall value = new CompletionChatCompletionMessageToolCall()
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
        ChatCompletionMessageToolCall value = new ChatCompletionMessageCustomToolCall()
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionMessageSerializationRoundtripWorks()
    {
        ChatCompletionMessageToolCall value = new CompletionChatCompletionMessageToolCall()
        {
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            ThoughtSignature = "thought_signature",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageToolCall>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionMessageCustomSerializationRoundtripWorks()
    {
        ChatCompletionMessageToolCall value = new ChatCompletionMessageCustomToolCall()
        {
            ID = "id",
            Custom = new() { Input = "input", Name = "name" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionMessageToolCall>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
