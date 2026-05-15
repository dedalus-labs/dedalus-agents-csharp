using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionChunkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        string expectedID = "id";
        List<StreamChoice> expectedChoices =
        [
            new()
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
            },
        ];
        long expectedCreated = 0;
        string expectedModel = "model";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("chat.completion.chunk");
        ApiEnum<string, ChatCompletionChunkServiceTier> expectedServiceTier =
            ChatCompletionChunkServiceTier.Auto;
        string expectedSystemFingerprint = "system_fingerprint";
        CompletionUsage expectedUsage = new()
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,
            CompletionTokensDetails = new()
            {
                AcceptedPredictionTokens = 0,
                AudioTokens = 0,
                ReasoningTokens = 0,
                RejectedPredictionTokens = 0,
            },
            PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChoices.Count, model.Choices.Count);
        for (int i = 0; i < expectedChoices.Count; i++)
        {
            Assert.Equal(expectedChoices[i], model.Choices[i]);
        }
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSystemFingerprint, model.SystemFingerprint);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionChunk>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionChunk>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<StreamChoice> expectedChoices =
        [
            new()
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
            },
        ];
        long expectedCreated = 0;
        string expectedModel = "model";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("chat.completion.chunk");
        ApiEnum<string, ChatCompletionChunkServiceTier> expectedServiceTier =
            ChatCompletionChunkServiceTier.Auto;
        string expectedSystemFingerprint = "system_fingerprint";
        CompletionUsage expectedUsage = new()
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,
            CompletionTokensDetails = new()
            {
                AcceptedPredictionTokens = 0,
                AudioTokens = 0,
                ReasoningTokens = 0,
                RejectedPredictionTokens = 0,
            },
            PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChoices.Count, deserialized.Choices.Count);
        for (int i = 0; i < expectedChoices.Count; i++)
        {
            Assert.Equal(expectedChoices[i], deserialized.Choices[i]);
        }
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSystemFingerprint, deserialized.SystemFingerprint);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        Assert.Null(model.SystemFingerprint);
        Assert.False(model.RawData.ContainsKey("system_fingerprint"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },

            // Null should be interpreted as omitted for these properties
            SystemFingerprint = null,
        };

        Assert.Null(model.SystemFingerprint);
        Assert.False(model.RawData.ContainsKey("system_fingerprint"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },

            // Null should be interpreted as omitted for these properties
            SystemFingerprint = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            SystemFingerprint = "system_fingerprint",
        };

        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            SystemFingerprint = "system_fingerprint",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            SystemFingerprint = "system_fingerprint",

            ServiceTier = null,
            Usage = null,
        };

        Assert.Null(model.ServiceTier);
        Assert.True(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            SystemFingerprint = "system_fingerprint",

            ServiceTier = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionChunk
        {
            ID = "id",
            Choices =
            [
                new()
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
                },
            ],
            Created = 0,
            Model = "model",
            ServiceTier = ChatCompletionChunkServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 0,
                PromptTokens = 0,
                TotalTokens = 0,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },
        };

        ChatCompletionChunk copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionChunkServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ChatCompletionChunkServiceTier.Auto)]
    [InlineData(ChatCompletionChunkServiceTier.Default)]
    [InlineData(ChatCompletionChunkServiceTier.Flex)]
    [InlineData(ChatCompletionChunkServiceTier.Scale)]
    [InlineData(ChatCompletionChunkServiceTier.Priority)]
    public void Validation_Works(ChatCompletionChunkServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionChunkServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCompletionChunkServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCompletionChunkServiceTier.Auto)]
    [InlineData(ChatCompletionChunkServiceTier.Default)]
    [InlineData(ChatCompletionChunkServiceTier.Flex)]
    [InlineData(ChatCompletionChunkServiceTier.Scale)]
    [InlineData(ChatCompletionChunkServiceTier.Priority)]
    public void SerializationRoundtrip_Works(ChatCompletionChunkServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionChunkServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionChunkServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCompletionChunkServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionChunkServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
