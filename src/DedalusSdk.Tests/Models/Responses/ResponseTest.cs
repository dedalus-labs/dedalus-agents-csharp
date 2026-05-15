using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Responses;

namespace DedalusSdk.Tests.Models.Responses;

public class ResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Object = Object.Response,
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string expectedID = "id";
        double expectedCreatedAt = 0;
        string expectedModel = "model";
        List<Dictionary<string, JsonValueInput?>> expectedOutput =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        bool expectedBackground = true;
        double expectedCompletedAt = 0;
        Dictionary<string, JsonValueInput?> expectedConversation = new() { { "foo", "string" } };
        Dictionary<string, JsonValueInput?> expectedError = new() { { "foo", "string" } };
        double expectedFrequencyPenalty = 0;
        Dictionary<string, string> expectedIncompleteDetails = new() { { "foo", "string" } };
        ResponseInstructions expectedInstructions = "string";
        long expectedMaxOutputTokens = 0;
        long expectedMaxToolCalls = 0;
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Object> expectedObject = Object.Response;
        string expectedOutputText = "output_text";
        bool expectedParallelToolCalls = true;
        double expectedPresencePenalty = 0;
        string expectedPreviousResponseID = "previous_response_id";
        string expectedPromptCacheKey = "prompt_cache_key";
        Dictionary<string, JsonValueInput?> expectedReasoning = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        string expectedServiceTier = "service_tier";
        bool expectedStore = true;
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedText = new() { { "foo", "string" } };
        ResponseToolChoice expectedToolChoice = "string";
        List<Dictionary<string, JsonValueInput?>> expectedTools =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        List<string> expectedToolsExecuted = ["string"];
        long expectedTopLogprobs = 0;
        double expectedTopP = 0;
        string expectedTruncation = "truncation";
        Dictionary<string, JsonValueInput?> expectedUsage = new() { { "foo", "string" } };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutput.Count, model.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i].Count, model.Output[i].Count);
            foreach (var item in expectedOutput[i])
            {
                Assert.True(model.Output[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, model.Output[i][item.Key]);
            }
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.NotNull(model.Conversation);
        Assert.Equal(expectedConversation.Count, model.Conversation.Count);
        foreach (var item in expectedConversation)
        {
            Assert.True(model.Conversation.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Conversation[item.Key]);
        }
        Assert.NotNull(model.Error);
        Assert.Equal(expectedError.Count, model.Error.Count);
        foreach (var item in expectedError)
        {
            Assert.True(model.Error.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Error[item.Key]);
        }
        Assert.Equal(expectedFrequencyPenalty, model.FrequencyPenalty);
        Assert.NotNull(model.IncompleteDetails);
        Assert.Equal(expectedIncompleteDetails.Count, model.IncompleteDetails.Count);
        foreach (var item in expectedIncompleteDetails)
        {
            Assert.True(model.IncompleteDetails.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.IncompleteDetails[item.Key]);
        }
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedMaxOutputTokens, model.MaxOutputTokens);
        Assert.Equal(expectedMaxToolCalls, model.MaxToolCalls);
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
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedOutputText, model.OutputText);
        Assert.Equal(expectedParallelToolCalls, model.ParallelToolCalls);
        Assert.Equal(expectedPresencePenalty, model.PresencePenalty);
        Assert.Equal(expectedPreviousResponseID, model.PreviousResponseID);
        Assert.Equal(expectedPromptCacheKey, model.PromptCacheKey);
        Assert.NotNull(model.Reasoning);
        Assert.Equal(expectedReasoning.Count, model.Reasoning.Count);
        foreach (var item in expectedReasoning)
        {
            Assert.True(model.Reasoning.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Reasoning[item.Key]);
        }
        Assert.Equal(expectedSafetyIdentifier, model.SafetyIdentifier);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedStore, model.Store);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.NotNull(model.Text);
        Assert.Equal(expectedText.Count, model.Text.Count);
        foreach (var item in expectedText)
        {
            Assert.True(model.Text.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Text[item.Key]);
        }
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i].Count, model.Tools[i].Count);
            foreach (var item in expectedTools[i])
            {
                Assert.True(model.Tools[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, model.Tools[i][item.Key]);
            }
        }
        Assert.NotNull(model.ToolsExecuted);
        Assert.Equal(expectedToolsExecuted.Count, model.ToolsExecuted.Count);
        for (int i = 0; i < expectedToolsExecuted.Count; i++)
        {
            Assert.Equal(expectedToolsExecuted[i], model.ToolsExecuted[i]);
        }
        Assert.Equal(expectedTopLogprobs, model.TopLogprobs);
        Assert.Equal(expectedTopP, model.TopP);
        Assert.Equal(expectedTruncation, model.Truncation);
        Assert.NotNull(model.Usage);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Usage[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Object = Object.Response,
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Response>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Object = Object.Response,
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Response>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedCreatedAt = 0;
        string expectedModel = "model";
        List<Dictionary<string, JsonValueInput?>> expectedOutput =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        bool expectedBackground = true;
        double expectedCompletedAt = 0;
        Dictionary<string, JsonValueInput?> expectedConversation = new() { { "foo", "string" } };
        Dictionary<string, JsonValueInput?> expectedError = new() { { "foo", "string" } };
        double expectedFrequencyPenalty = 0;
        Dictionary<string, string> expectedIncompleteDetails = new() { { "foo", "string" } };
        ResponseInstructions expectedInstructions = "string";
        long expectedMaxOutputTokens = 0;
        long expectedMaxToolCalls = 0;
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Object> expectedObject = Object.Response;
        string expectedOutputText = "output_text";
        bool expectedParallelToolCalls = true;
        double expectedPresencePenalty = 0;
        string expectedPreviousResponseID = "previous_response_id";
        string expectedPromptCacheKey = "prompt_cache_key";
        Dictionary<string, JsonValueInput?> expectedReasoning = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        string expectedServiceTier = "service_tier";
        bool expectedStore = true;
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedText = new() { { "foo", "string" } };
        ResponseToolChoice expectedToolChoice = "string";
        List<Dictionary<string, JsonValueInput?>> expectedTools =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        List<string> expectedToolsExecuted = ["string"];
        long expectedTopLogprobs = 0;
        double expectedTopP = 0;
        string expectedTruncation = "truncation";
        Dictionary<string, JsonValueInput?> expectedUsage = new() { { "foo", "string" } };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutput.Count, deserialized.Output.Count);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.Equal(expectedOutput[i].Count, deserialized.Output[i].Count);
            foreach (var item in expectedOutput[i])
            {
                Assert.True(deserialized.Output[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, deserialized.Output[i][item.Key]);
            }
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.NotNull(deserialized.Conversation);
        Assert.Equal(expectedConversation.Count, deserialized.Conversation.Count);
        foreach (var item in expectedConversation)
        {
            Assert.True(deserialized.Conversation.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Conversation[item.Key]);
        }
        Assert.NotNull(deserialized.Error);
        Assert.Equal(expectedError.Count, deserialized.Error.Count);
        foreach (var item in expectedError)
        {
            Assert.True(deserialized.Error.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Error[item.Key]);
        }
        Assert.Equal(expectedFrequencyPenalty, deserialized.FrequencyPenalty);
        Assert.NotNull(deserialized.IncompleteDetails);
        Assert.Equal(expectedIncompleteDetails.Count, deserialized.IncompleteDetails.Count);
        foreach (var item in expectedIncompleteDetails)
        {
            Assert.True(deserialized.IncompleteDetails.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.IncompleteDetails[item.Key]);
        }
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedMaxOutputTokens, deserialized.MaxOutputTokens);
        Assert.Equal(expectedMaxToolCalls, deserialized.MaxToolCalls);
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
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedOutputText, deserialized.OutputText);
        Assert.Equal(expectedParallelToolCalls, deserialized.ParallelToolCalls);
        Assert.Equal(expectedPresencePenalty, deserialized.PresencePenalty);
        Assert.Equal(expectedPreviousResponseID, deserialized.PreviousResponseID);
        Assert.Equal(expectedPromptCacheKey, deserialized.PromptCacheKey);
        Assert.NotNull(deserialized.Reasoning);
        Assert.Equal(expectedReasoning.Count, deserialized.Reasoning.Count);
        foreach (var item in expectedReasoning)
        {
            Assert.True(deserialized.Reasoning.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Reasoning[item.Key]);
        }
        Assert.Equal(expectedSafetyIdentifier, deserialized.SafetyIdentifier);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedStore, deserialized.Store);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.NotNull(deserialized.Text);
        Assert.Equal(expectedText.Count, deserialized.Text.Count);
        foreach (var item in expectedText)
        {
            Assert.True(deserialized.Text.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Text[item.Key]);
        }
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i].Count, deserialized.Tools[i].Count);
            foreach (var item in expectedTools[i])
            {
                Assert.True(deserialized.Tools[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, deserialized.Tools[i][item.Key]);
            }
        }
        Assert.NotNull(deserialized.ToolsExecuted);
        Assert.Equal(expectedToolsExecuted.Count, deserialized.ToolsExecuted.Count);
        for (int i = 0; i < expectedToolsExecuted.Count; i++)
        {
            Assert.Equal(expectedToolsExecuted[i], deserialized.ToolsExecuted[i]);
        }
        Assert.Equal(expectedTopLogprobs, deserialized.TopLogprobs);
        Assert.Equal(expectedTopP, deserialized.TopP);
        Assert.Equal(expectedTruncation, deserialized.Truncation);
        Assert.NotNull(deserialized.Usage);
        Assert.Equal(expectedUsage.Count, deserialized.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(deserialized.Usage.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Usage[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Object = Object.Response,
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Object = null,
        };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Object = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Object = Object.Response,
        };

        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.Conversation);
        Assert.False(model.RawData.ContainsKey("conversation"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.FrequencyPenalty);
        Assert.False(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.IncompleteDetails);
        Assert.False(model.RawData.ContainsKey("incomplete_details"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MaxOutputTokens);
        Assert.False(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.MaxToolCalls);
        Assert.False(model.RawData.ContainsKey("max_tool_calls"));
        Assert.Null(model.McpServerErrors);
        Assert.False(model.RawData.ContainsKey("mcp_server_errors"));
        Assert.Null(model.McpToolResults);
        Assert.False(model.RawData.ContainsKey("mcp_tool_results"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OutputText);
        Assert.False(model.RawData.ContainsKey("output_text"));
        Assert.Null(model.ParallelToolCalls);
        Assert.False(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.PresencePenalty);
        Assert.False(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PreviousResponseID);
        Assert.False(model.RawData.ContainsKey("previous_response_id"));
        Assert.Null(model.PromptCacheKey);
        Assert.False(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.SafetyIdentifier);
        Assert.False(model.RawData.ContainsKey("safety_identifier"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.ToolsExecuted);
        Assert.False(model.RawData.ContainsKey("tools_executed"));
        Assert.Null(model.TopLogprobs);
        Assert.False(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.False(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Object = Object.Response,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Object = Object.Response,

            Background = null,
            CompletedAt = null,
            Conversation = null,
            Error = null,
            FrequencyPenalty = null,
            IncompleteDetails = null,
            Instructions = null,
            MaxOutputTokens = null,
            MaxToolCalls = null,
            McpServerErrors = null,
            McpToolResults = null,
            Metadata = null,
            OutputText = null,
            ParallelToolCalls = null,
            PresencePenalty = null,
            PreviousResponseID = null,
            PromptCacheKey = null,
            Reasoning = null,
            SafetyIdentifier = null,
            ServiceTier = null,
            Store = null,
            Temperature = null,
            Text = null,
            ToolChoice = null,
            Tools = null,
            ToolsExecuted = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            Usage = null,
        };

        Assert.Null(model.Background);
        Assert.True(model.RawData.ContainsKey("background"));
        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.Conversation);
        Assert.True(model.RawData.ContainsKey("conversation"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.FrequencyPenalty);
        Assert.True(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.IncompleteDetails);
        Assert.True(model.RawData.ContainsKey("incomplete_details"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MaxOutputTokens);
        Assert.True(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.MaxToolCalls);
        Assert.True(model.RawData.ContainsKey("max_tool_calls"));
        Assert.Null(model.McpServerErrors);
        Assert.True(model.RawData.ContainsKey("mcp_server_errors"));
        Assert.Null(model.McpToolResults);
        Assert.True(model.RawData.ContainsKey("mcp_tool_results"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OutputText);
        Assert.True(model.RawData.ContainsKey("output_text"));
        Assert.Null(model.ParallelToolCalls);
        Assert.True(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.PresencePenalty);
        Assert.True(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PreviousResponseID);
        Assert.True(model.RawData.ContainsKey("previous_response_id"));
        Assert.Null(model.PromptCacheKey);
        Assert.True(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.Reasoning);
        Assert.True(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.SafetyIdentifier);
        Assert.True(model.RawData.ContainsKey("safety_identifier"));
        Assert.Null(model.ServiceTier);
        Assert.True(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Store);
        Assert.True(model.RawData.ContainsKey("store"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.ToolChoice);
        Assert.True(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.True(model.RawData.ContainsKey("tools"));
        Assert.Null(model.ToolsExecuted);
        Assert.True(model.RawData.ContainsKey("tools_executed"));
        Assert.Null(model.TopLogprobs);
        Assert.True(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.True(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.True(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Object = Object.Response,

            Background = null,
            CompletedAt = null,
            Conversation = null,
            Error = null,
            FrequencyPenalty = null,
            IncompleteDetails = null,
            Instructions = null,
            MaxOutputTokens = null,
            MaxToolCalls = null,
            McpServerErrors = null,
            McpToolResults = null,
            Metadata = null,
            OutputText = null,
            ParallelToolCalls = null,
            PresencePenalty = null,
            PreviousResponseID = null,
            PromptCacheKey = null,
            Reasoning = null,
            SafetyIdentifier = null,
            ServiceTier = null,
            Store = null,
            Temperature = null,
            Text = null,
            ToolChoice = null,
            Tools = null,
            ToolsExecuted = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Response
        {
            ID = "id",
            CreatedAt = 0,
            Model = "model",
            Output = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            Status = Status.Completed,
            Background = true,
            CompletedAt = 0,
            Conversation = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Error = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            FrequencyPenalty = 0,
            IncompleteDetails = new Dictionary<string, string>() { { "foo", "string" } },
            Instructions = "string",
            MaxOutputTokens = 0,
            MaxToolCalls = 0,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Object = Object.Response,
            OutputText = "output_text",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = "service_tier",
            Store = true,
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "string",
            Tools = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            ToolsExecuted = ["string"],
            TopLogprobs = 0,
            TopP = 0,
            Truncation = "truncation",
            Usage = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Response copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Queued)]
    [InlineData(Status.Incomplete)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Queued)]
    [InlineData(Status.Incomplete)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseInstructionsTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ResponseInstructions value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        ResponseInstructions value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ResponseInstructions value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseInstructions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        ResponseInstructions value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseInstructions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Object.Response)]
    public void Validation_Works(Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Object> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Object.Response)]
    public void SerializationRoundtrip_Works(Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Object> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseToolChoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ResponseToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonObjectInputValidationWorks()
    {
        ResponseToolChoice value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ResponseToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonObjectInputSerializationRoundtripWorks()
    {
        ResponseToolChoice value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
