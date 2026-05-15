using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class StreamChoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
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

        ChoiceDelta expectedDelta = new()
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };
        ApiEnum<string, StreamChoiceFinishReason> expectedFinishReason =
            StreamChoiceFinishReason.Stop;
        long expectedIndex = 0;
        StreamChoiceLogprobs expectedLogprobs = new()
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

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedFinishReason, model.FinishReason);
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedLogprobs, model.Logprobs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
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
        var deserialized = JsonSerializer.Deserialize<StreamChoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
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
        var deserialized = JsonSerializer.Deserialize<StreamChoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChoiceDelta expectedDelta = new()
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };
        ApiEnum<string, StreamChoiceFinishReason> expectedFinishReason =
            StreamChoiceFinishReason.Stop;
        long expectedIndex = 0;
        StreamChoiceLogprobs expectedLogprobs = new()
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

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.Equal(expectedFinishReason, deserialized.FinishReason);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedLogprobs, deserialized.Logprobs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
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
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
        };

        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,

            Logprobs = null,
        };

        Assert.Null(model.Logprobs);
        Assert.True(model.RawData.ContainsKey("logprobs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,

            Logprobs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StreamChoice
        {
            Delta = new()
            {
                Content = "content",
                FunctionCall = new() { Arguments = "arguments", Name = "name" },
                Refusal = "refusal",
                Role = Role.Developer,
                ToolCalls =
                [
                    new()
                    {
                        Index = 0,
                        ID = "id",
                        Function = new() { Arguments = "arguments", Name = "name" },
                        Type = ChoiceDeltaToolCallType.Function,
                    },
                ],
            },
            FinishReason = StreamChoiceFinishReason.Stop,
            Index = 0,
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

        StreamChoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StreamChoiceFinishReasonTest : TestBase
{
    [Theory]
    [InlineData(StreamChoiceFinishReason.Stop)]
    [InlineData(StreamChoiceFinishReason.Length)]
    [InlineData(StreamChoiceFinishReason.ToolCalls)]
    [InlineData(StreamChoiceFinishReason.ContentFilter)]
    [InlineData(StreamChoiceFinishReason.FunctionCall)]
    public void Validation_Works(StreamChoiceFinishReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamChoiceFinishReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamChoiceFinishReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamChoiceFinishReason.Stop)]
    [InlineData(StreamChoiceFinishReason.Length)]
    [InlineData(StreamChoiceFinishReason.ToolCalls)]
    [InlineData(StreamChoiceFinishReason.ContentFilter)]
    [InlineData(StreamChoiceFinishReason.FunctionCall)]
    public void SerializationRoundtrip_Works(StreamChoiceFinishReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamChoiceFinishReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamChoiceFinishReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamChoiceFinishReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamChoiceFinishReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
