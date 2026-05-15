using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
            FinishReason = FinishReason.Stop,
            Logprobs = new()
            {
                Content =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
                Refusal =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
            },
        };

        long expectedIndex = 0;
        ChatCompletionMessage expectedMessage = new()
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
        ApiEnum<string, FinishReason> expectedFinishReason = FinishReason.Stop;
        ChoiceLogprobs expectedLogprobs = new()
        {
            Content =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                    TopLogprobs =
                    [
                        new()
                        {
                            Token = "token",
                            Bytes = [0],
                            Logprob = 0,
                        },
                    ],
                },
            ],
            Refusal =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                    TopLogprobs =
                    [
                        new()
                        {
                            Token = "token",
                            Bytes = [0],
                            Logprob = 0,
                        },
                    ],
                },
            ],
        };

        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedFinishReason, model.FinishReason);
        Assert.Equal(expectedLogprobs, model.Logprobs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
            FinishReason = FinishReason.Stop,
            Logprobs = new()
            {
                Content =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
                Refusal =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Choice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
            FinishReason = FinishReason.Stop,
            Logprobs = new()
            {
                Content =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
                Refusal =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Choice>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedIndex = 0;
        ChatCompletionMessage expectedMessage = new()
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
        ApiEnum<string, FinishReason> expectedFinishReason = FinishReason.Stop;
        ChoiceLogprobs expectedLogprobs = new()
        {
            Content =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                    TopLogprobs =
                    [
                        new()
                        {
                            Token = "token",
                            Bytes = [0],
                            Logprob = 0,
                        },
                    ],
                },
            ],
            Refusal =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                    TopLogprobs =
                    [
                        new()
                        {
                            Token = "token",
                            Bytes = [0],
                            Logprob = 0,
                        },
                    ],
                },
            ],
        };

        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedFinishReason, deserialized.FinishReason);
        Assert.Equal(expectedLogprobs, deserialized.Logprobs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
            FinishReason = FinishReason.Stop,
            Logprobs = new()
            {
                Content =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
                Refusal =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
        };

        Assert.Null(model.FinishReason);
        Assert.False(model.RawData.ContainsKey("finish_reason"));
        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },

            FinishReason = null,
            Logprobs = null,
        };

        Assert.Null(model.FinishReason);
        Assert.True(model.RawData.ContainsKey("finish_reason"));
        Assert.Null(model.Logprobs);
        Assert.True(model.RawData.ContainsKey("logprobs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },

            FinishReason = null,
            Logprobs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Choice
        {
            Index = 0,
            Message = new()
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
            },
            FinishReason = FinishReason.Stop,
            Logprobs = new()
            {
                Content =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
                Refusal =
                [
                    new()
                    {
                        Token = "token",
                        Bytes = [0],
                        Logprob = 0,
                        TopLogprobs =
                        [
                            new()
                            {
                                Token = "token",
                                Bytes = [0],
                                Logprob = 0,
                            },
                        ],
                    },
                ],
            },
        };

        Choice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FinishReasonTest : TestBase
{
    [Theory]
    [InlineData(FinishReason.Stop)]
    [InlineData(FinishReason.Length)]
    [InlineData(FinishReason.ToolCalls)]
    [InlineData(FinishReason.ContentFilter)]
    [InlineData(FinishReason.FunctionCall)]
    public void Validation_Works(FinishReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FinishReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FinishReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FinishReason.Stop)]
    [InlineData(FinishReason.Length)]
    [InlineData(FinishReason.ToolCalls)]
    [InlineData(FinishReason.ContentFilter)]
    [InlineData(FinishReason.FunctionCall)]
    public void SerializationRoundtrip_Works(FinishReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FinishReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FinishReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FinishReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FinishReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
