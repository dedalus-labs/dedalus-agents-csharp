using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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

        string expectedID = "chatcmpl-123";
        List<Choice> expectedChoices =
        [
            new()
            {
                Index = 0,
                Message = new()
                {
                    Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
            },
        ];
        long expectedCreated = 1677652288;
        string expectedModel = "gpt-4o-mini";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("chat.completion");
        string expectedCorrelationID = "correlation_id";
        List<DeferredCallResponse> expectedDeferred =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                BlockedBy = ["string"],
                Dependencies = ["string"],
                Venue = "venue",
            },
        ];
        Dictionary<string, McpServerErrorsItem> expectedMcpServerErrors = new()
        {
            {
                "foo",
                new()
                {
                    Message = "message",
                    Code = "code",
                    Recommendation = "recommendation",
                }
            },
        };
        List<McpToolResult> expectedMcpToolResults =
        [
            new()
            {
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                IsError = true,
                ServerName = "server_name",
                ToolName = "tool_name",
                DurationMs = 0,
                Result = "string",
            },
        ];
        List<PendingTool> expectedPendingTools =
        [
            new()
            {
                ID = "id",
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Name = "name",
                Dependencies = ["string"],
            },
        ];
        Dictionary<string, JsonValueInput?> expectedServerResults = new() { { "foo", "string" } };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        string expectedSystemFingerprint = "system_fingerprint";
        List<string> expectedToolsExecuted = ["search_events", "get_event_details"];
        long expectedTurnsConsumed = 0;
        CompletionUsage expectedUsage = new()
        {
            CompletionTokens = 12,
            PromptTokens = 9,
            TotalTokens = 21,
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
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.NotNull(model.Deferred);
        Assert.Equal(expectedDeferred.Count, model.Deferred.Count);
        for (int i = 0; i < expectedDeferred.Count; i++)
        {
            Assert.Equal(expectedDeferred[i], model.Deferred[i]);
        }
        Assert.NotNull(model.McpServerErrors);
        Assert.Equal(expectedMcpServerErrors.Count, model.McpServerErrors.Count);
        foreach (var item in expectedMcpServerErrors)
        {
            Assert.True(model.McpServerErrors.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.McpServerErrors[item.Key]);
        }
        Assert.NotNull(model.McpToolResults);
        Assert.Equal(expectedMcpToolResults.Count, model.McpToolResults.Count);
        for (int i = 0; i < expectedMcpToolResults.Count; i++)
        {
            Assert.Equal(expectedMcpToolResults[i], model.McpToolResults[i]);
        }
        Assert.NotNull(model.PendingTools);
        Assert.Equal(expectedPendingTools.Count, model.PendingTools.Count);
        for (int i = 0; i < expectedPendingTools.Count; i++)
        {
            Assert.Equal(expectedPendingTools[i], model.PendingTools[i]);
        }
        Assert.NotNull(model.ServerResults);
        Assert.Equal(expectedServerResults.Count, model.ServerResults.Count);
        foreach (var item in expectedServerResults)
        {
            Assert.True(model.ServerResults.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ServerResults[item.Key]);
        }
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSystemFingerprint, model.SystemFingerprint);
        Assert.NotNull(model.ToolsExecuted);
        Assert.Equal(expectedToolsExecuted.Count, model.ToolsExecuted.Count);
        for (int i = 0; i < expectedToolsExecuted.Count; i++)
        {
            Assert.Equal(expectedToolsExecuted[i], model.ToolsExecuted[i]);
        }
        Assert.Equal(expectedTurnsConsumed, model.TurnsConsumed);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "chatcmpl-123";
        List<Choice> expectedChoices =
        [
            new()
            {
                Index = 0,
                Message = new()
                {
                    Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
            },
        ];
        long expectedCreated = 1677652288;
        string expectedModel = "gpt-4o-mini";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("chat.completion");
        string expectedCorrelationID = "correlation_id";
        List<DeferredCallResponse> expectedDeferred =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                BlockedBy = ["string"],
                Dependencies = ["string"],
                Venue = "venue",
            },
        ];
        Dictionary<string, McpServerErrorsItem> expectedMcpServerErrors = new()
        {
            {
                "foo",
                new()
                {
                    Message = "message",
                    Code = "code",
                    Recommendation = "recommendation",
                }
            },
        };
        List<McpToolResult> expectedMcpToolResults =
        [
            new()
            {
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                IsError = true,
                ServerName = "server_name",
                ToolName = "tool_name",
                DurationMs = 0,
                Result = "string",
            },
        ];
        List<PendingTool> expectedPendingTools =
        [
            new()
            {
                ID = "id",
                Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Name = "name",
                Dependencies = ["string"],
            },
        ];
        Dictionary<string, JsonValueInput?> expectedServerResults = new() { { "foo", "string" } };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        string expectedSystemFingerprint = "system_fingerprint";
        List<string> expectedToolsExecuted = ["search_events", "get_event_details"];
        long expectedTurnsConsumed = 0;
        CompletionUsage expectedUsage = new()
        {
            CompletionTokens = 12,
            PromptTokens = 9,
            TotalTokens = 21,
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
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.NotNull(deserialized.Deferred);
        Assert.Equal(expectedDeferred.Count, deserialized.Deferred.Count);
        for (int i = 0; i < expectedDeferred.Count; i++)
        {
            Assert.Equal(expectedDeferred[i], deserialized.Deferred[i]);
        }
        Assert.NotNull(deserialized.McpServerErrors);
        Assert.Equal(expectedMcpServerErrors.Count, deserialized.McpServerErrors.Count);
        foreach (var item in expectedMcpServerErrors)
        {
            Assert.True(deserialized.McpServerErrors.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.McpServerErrors[item.Key]);
        }
        Assert.NotNull(deserialized.McpToolResults);
        Assert.Equal(expectedMcpToolResults.Count, deserialized.McpToolResults.Count);
        for (int i = 0; i < expectedMcpToolResults.Count; i++)
        {
            Assert.Equal(expectedMcpToolResults[i], deserialized.McpToolResults[i]);
        }
        Assert.NotNull(deserialized.PendingTools);
        Assert.Equal(expectedPendingTools.Count, deserialized.PendingTools.Count);
        for (int i = 0; i < expectedPendingTools.Count; i++)
        {
            Assert.Equal(expectedPendingTools[i], deserialized.PendingTools[i]);
        }
        Assert.NotNull(deserialized.ServerResults);
        Assert.Equal(expectedServerResults.Count, deserialized.ServerResults.Count);
        foreach (var item in expectedServerResults)
        {
            Assert.True(deserialized.ServerResults.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ServerResults[item.Key]);
        }
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSystemFingerprint, deserialized.SystemFingerprint);
        Assert.NotNull(deserialized.ToolsExecuted);
        Assert.Equal(expectedToolsExecuted.Count, deserialized.ToolsExecuted.Count);
        for (int i = 0; i < expectedToolsExecuted.Count; i++)
        {
            Assert.Equal(expectedToolsExecuted[i], deserialized.ToolsExecuted[i]);
        }
        Assert.Equal(expectedTurnsConsumed, deserialized.TurnsConsumed);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
        };

        Assert.Null(model.SystemFingerprint);
        Assert.False(model.RawData.ContainsKey("system_fingerprint"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,

            // Null should be interpreted as omitted for these properties
            SystemFingerprint = null,
            Usage = null,
        };

        Assert.Null(model.SystemFingerprint);
        Assert.False(model.RawData.ContainsKey("system_fingerprint"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,

            // Null should be interpreted as omitted for these properties
            SystemFingerprint = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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

        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Deferred);
        Assert.False(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.McpServerErrors);
        Assert.False(model.RawData.ContainsKey("mcp_server_errors"));
        Assert.Null(model.McpToolResults);
        Assert.False(model.RawData.ContainsKey("mcp_tool_results"));
        Assert.Null(model.PendingTools);
        Assert.False(model.RawData.ContainsKey("pending_tools"));
        Assert.Null(model.ServerResults);
        Assert.False(model.RawData.ContainsKey("server_results"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.ToolsExecuted);
        Assert.False(model.RawData.ContainsKey("tools_executed"));
        Assert.Null(model.TurnsConsumed);
        Assert.False(model.RawData.ContainsKey("turns_consumed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },

            CorrelationID = null,
            Deferred = null,
            McpServerErrors = null,
            McpToolResults = null,
            PendingTools = null,
            ServerResults = null,
            ServiceTier = null,
            ToolsExecuted = null,
            TurnsConsumed = null,
        };

        Assert.Null(model.CorrelationID);
        Assert.True(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Deferred);
        Assert.True(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.McpServerErrors);
        Assert.True(model.RawData.ContainsKey("mcp_server_errors"));
        Assert.Null(model.McpToolResults);
        Assert.True(model.RawData.ContainsKey("mcp_tool_results"));
        Assert.Null(model.PendingTools);
        Assert.True(model.RawData.ContainsKey("pending_tools"));
        Assert.Null(model.ServerResults);
        Assert.True(model.RawData.ContainsKey("server_results"));
        Assert.Null(model.ServiceTier);
        Assert.True(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.ToolsExecuted);
        Assert.True(model.RawData.ContainsKey("tools_executed"));
        Assert.Null(model.TurnsConsumed);
        Assert.True(model.RawData.ContainsKey("turns_consumed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            SystemFingerprint = "system_fingerprint",
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
                CompletionTokensDetails = new()
                {
                    AcceptedPredictionTokens = 0,
                    AudioTokens = 0,
                    ReasoningTokens = 0,
                    RejectedPredictionTokens = 0,
                },
                PromptTokensDetails = new() { AudioTokens = 0, CachedTokens = 0 },
            },

            CorrelationID = null,
            Deferred = null,
            McpServerErrors = null,
            McpToolResults = null,
            PendingTools = null,
            ServerResults = null,
            ServiceTier = null,
            ToolsExecuted = null,
            TurnsConsumed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletion
        {
            ID = "chatcmpl-123",
            Choices =
            [
                new()
                {
                    Index = 0,
                    Message = new()
                    {
                        Content = "The next Warriors game is tomorrow at 7:30 PM.",
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
                },
            ],
            Created = 1677652288,
            Model = "gpt-4o-mini",
            CorrelationID = "correlation_id",
            Deferred =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    BlockedBy = ["string"],
                    Dependencies = ["string"],
                    Venue = "venue",
                },
            ],
            McpServerErrors = new Dictionary<string, McpServerErrorsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Message = "message",
                        Code = "code",
                        Recommendation = "recommendation",
                    }
                },
            },
            McpToolResults =
            [
                new()
                {
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    IsError = true,
                    ServerName = "server_name",
                    ToolName = "tool_name",
                    DurationMs = 0,
                    Result = "string",
                },
            ],
            PendingTools =
            [
                new()
                {
                    ID = "id",
                    Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                    Name = "name",
                    Dependencies = ["string"],
                },
            ],
            ServerResults = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ServiceTier = ServiceTier.Auto,
            SystemFingerprint = "system_fingerprint",
            ToolsExecuted = ["search_events", "get_event_details"],
            TurnsConsumed = 0,
            Usage = new()
            {
                CompletionTokens = 12,
                PromptTokens = 9,
                TotalTokens = 21,
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

        ChatCompletion copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class McpServerErrorsItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",
            Code = "code",
            Recommendation = "recommendation",
        };

        string expectedMessage = "message";
        string expectedCode = "code";
        string expectedRecommendation = "recommendation";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedRecommendation, model.Recommendation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",
            Code = "code",
            Recommendation = "recommendation",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerErrorsItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",
            Code = "code",
            Recommendation = "recommendation",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerErrorsItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        string expectedCode = "code";
        string expectedRecommendation = "recommendation";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedRecommendation, deserialized.Recommendation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",
            Code = "code",
            Recommendation = "recommendation",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpServerErrorsItem { Message = "message" };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Recommendation);
        Assert.False(model.RawData.ContainsKey("recommendation"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpServerErrorsItem { Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",

            Code = null,
            Recommendation = null,
        };

        Assert.Null(model.Code);
        Assert.True(model.RawData.ContainsKey("code"));
        Assert.Null(model.Recommendation);
        Assert.True(model.RawData.ContainsKey("recommendation"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",

            Code = null,
            Recommendation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpServerErrorsItem
        {
            Message = "message",
            Code = "code",
            Recommendation = "recommendation",
        };

        McpServerErrorsItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PendingToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
            Dependencies = ["string"],
        };

        string expectedID = "id";
        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        string expectedName = "name";
        List<string> expectedDependencies = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Arguments[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Dependencies);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], model.Dependencies[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
            Dependencies = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
            Dependencies = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PendingTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        string expectedName = "name";
        List<string> expectedDependencies = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Arguments[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Dependencies);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], deserialized.Dependencies[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
            Dependencies = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
        };

        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Dependencies = null,
        };

        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Dependencies = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PendingTool
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Name = "name",
            Dependencies = ["string"],
        };

        PendingTool copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.Default)]
    [InlineData(ServiceTier.Flex)]
    [InlineData(ServiceTier.Scale)]
    [InlineData(ServiceTier.Priority)]
    public void Validation_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.Default)]
    [InlineData(ServiceTier.Flex)]
    [InlineData(ServiceTier.Scale)]
    [InlineData(ServiceTier.Priority)]
    public void SerializationRoundtrip_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
