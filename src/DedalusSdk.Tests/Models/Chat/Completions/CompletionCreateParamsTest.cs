using System;
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using Completions = DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class CompletionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new()
            {
                Format = Completions::Format.Mp3,
                Voice = Completions::UnionMember1.Alloy,
            },
            AutomaticToolExecution = true,
            CachedContent = "cached_content",
            CorrelationID = "correlation_id",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            Deferred = true,
            DeferredCalls =
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
            FrequencyPenalty = -2,
            FunctionCall = "function_call",
            Functions =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Guardrails =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            HandoffConfig = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            HandoffMode = true,
            InferenceGeo = "inference_geo",
            LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
            Logprobs = true,
            MaxCompletionTokens = 0,
            MaxTokens = 1,
            MaxTurns = 5,
            McpServers = "dedalus-labs/example-server",
            Messages =
            [
                new Completions::ChatCompletionDeveloperMessageParam()
                {
                    Content = "string",
                    Name = "name",
                },
            ],
            Metadata = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Modalities = ["string"],
            ModelAttributes = new Dictionary<string, IReadOnlyDictionary<string, double>>()
            {
                {
                    "gpt-5",
                    new Dictionary<string, double>() { { "accuracy", 0.95 }, { "speed", 0.6 } }
                },
            },
            N = 1,
            OutputConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ParallelToolCalls = true,
            Prediction = new(new Completions::PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = Completions::PromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category = Completions::Category.HarmCategoryUnspecified,
                    Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = Completions::Speed.Standard,
            Stop = new(["string"]),
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new Completions::ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Completions::Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Completions::Model expectedModel = "openai/gpt-5";
        Dictionary<string, double> expectedAgentAttributes = new()
        {
            { "accuracy", 0.9 },
            { "complexity", 0.8 },
        };
        Completions::ChatCompletionAudioParam expectedAudio = new()
        {
            Format = Completions::Format.Mp3,
            Voice = Completions::UnionMember1.Alloy,
        };
        bool expectedAutomaticToolExecution = true;
        string expectedCachedContent = "cached_content";
        string expectedCorrelationID = "correlation_id";
        Completions::Credentials expectedCredentials = new Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
        };
        bool expectedDeferred = true;
        List<Completions::DeferredCallResponse> expectedDeferredCalls =
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
        double expectedFrequencyPenalty = -2;
        string expectedFunctionCall = "function_call";
        List<Completions::ChatCompletionFunctions> expectedFunctions =
        [
            new()
            {
                Name = "name",
                Description = "description",
                Parameters = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        ];
        Dictionary<string, JsonValueInput?> expectedGenerationConfig = new()
        {
            { "foo", "string" },
        };
        List<Dictionary<string, JsonElement>> expectedGuardrails =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        Dictionary<string, JsonElement> expectedHandoffConfig = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedHandoffMode = true;
        string expectedInferenceGeo = "inference_geo";
        Dictionary<string, long> expectedLogitBias = new() { { "foo", 0 } };
        bool expectedLogprobs = true;
        long expectedMaxCompletionTokens = 0;
        long expectedMaxTokens = 1;
        long expectedMaxTurns = 5;
        Completions::McpServers expectedMcpServers = "dedalus-labs/example-server";
        List<Completions::Message> expectedMessages =
        [
            new Completions::ChatCompletionDeveloperMessageParam()
            {
                Content = "string",
                Name = "name",
            },
        ];
        Dictionary<string, JsonValueInput?> expectedMetadata = new() { { "foo", "string" } };
        List<string> expectedModalities = ["string"];
        Dictionary<string, Dictionary<string, double>> expectedModelAttributes = new()
        {
            {
                "gpt-5",
                new Dictionary<string, double>() { { "accuracy", 0.95 }, { "speed", 0.6 } }
            },
        };
        long expectedN = 1;
        Dictionary<string, JsonValueInput?> expectedOutputConfig = new() { { "foo", "string" } };
        bool expectedParallelToolCalls = true;
        Completions::PredictionContent expectedPrediction = new(
            new Completions::PredictionContentContent("string")
        );
        double expectedPresencePenalty = -2;
        string expectedPromptCacheKey = "prompt_cache_key";
        string expectedPromptCacheRetention = "prompt_cache_retention";
        ApiEnum<string, Completions::PromptMode> expectedPromptMode =
            Completions::PromptMode.Reasoning;
        string expectedReasoningEffort = "reasoning_effort";
        Completions::ResponseFormat expectedResponseFormat = new ResponseFormatText();
        bool expectedSafePrompt = true;
        string expectedSafetyIdentifier = "safety_identifier";
        List<Completions::SafetySetting> expectedSafetySettings =
        [
            new()
            {
                Category = Completions::Category.HarmCategoryUnspecified,
                Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
            },
        ];
        Dictionary<string, JsonValueInput?> expectedSearchParameters = new()
        {
            { "foo", "string" },
        };
        long expectedSeed = 0;
        string expectedServiceTier = "service_tier";
        ApiEnum<string, Completions::Speed> expectedSpeed = Completions::Speed.Standard;
        Completions::Stop expectedStop = new(["string"]);
        bool expectedStore = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        Completions::SystemInstruction expectedSystemInstruction = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        double expectedTemperature = 0;
        Completions::Thinking expectedThinking = new Completions::ThinkingConfigEnabled(1024);
        Completions::ToolChoice expectedToolChoice = "string";
        Dictionary<string, JsonValueInput?> expectedToolConfig = new() { { "foo", "string" } };
        List<Completions::ChatCompletionToolParam> expectedTools =
        [
            new() { Function = new("name"), Type = Completions::Type.Function },
        ];
        long expectedTopK = 0;
        long expectedTopLogprobs = 0;
        double expectedTopP = 0;
        string expectedUser = "user";
        string expectedVerbosity = "verbosity";
        Dictionary<string, JsonValueInput?> expectedWebSearchOptions = new()
        {
            { "foo", "string" },
        };

        Assert.Equal(expectedModel, parameters.Model);
        Assert.NotNull(parameters.AgentAttributes);
        Assert.Equal(expectedAgentAttributes.Count, parameters.AgentAttributes.Count);
        foreach (var item in expectedAgentAttributes)
        {
            Assert.True(parameters.AgentAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.AgentAttributes[item.Key]);
        }
        Assert.Equal(expectedAudio, parameters.Audio);
        Assert.Equal(expectedAutomaticToolExecution, parameters.AutomaticToolExecution);
        Assert.Equal(expectedCachedContent, parameters.CachedContent);
        Assert.Equal(expectedCorrelationID, parameters.CorrelationID);
        Assert.Equal(expectedCredentials, parameters.Credentials);
        Assert.Equal(expectedDeferred, parameters.Deferred);
        Assert.NotNull(parameters.DeferredCalls);
        Assert.Equal(expectedDeferredCalls.Count, parameters.DeferredCalls.Count);
        for (int i = 0; i < expectedDeferredCalls.Count; i++)
        {
            Assert.Equal(expectedDeferredCalls[i], parameters.DeferredCalls[i]);
        }
        Assert.Equal(expectedFrequencyPenalty, parameters.FrequencyPenalty);
        Assert.Equal(expectedFunctionCall, parameters.FunctionCall);
        Assert.NotNull(parameters.Functions);
        Assert.Equal(expectedFunctions.Count, parameters.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], parameters.Functions[i]);
        }
        Assert.NotNull(parameters.GenerationConfig);
        Assert.Equal(expectedGenerationConfig.Count, parameters.GenerationConfig.Count);
        foreach (var item in expectedGenerationConfig)
        {
            Assert.True(parameters.GenerationConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.GenerationConfig[item.Key]);
        }
        Assert.NotNull(parameters.Guardrails);
        Assert.Equal(expectedGuardrails.Count, parameters.Guardrails.Count);
        for (int i = 0; i < expectedGuardrails.Count; i++)
        {
            Assert.Equal(expectedGuardrails[i].Count, parameters.Guardrails[i].Count);
            foreach (var item in expectedGuardrails[i])
            {
                Assert.True(parameters.Guardrails[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, parameters.Guardrails[i][item.Key]));
            }
        }
        Assert.NotNull(parameters.HandoffConfig);
        Assert.Equal(expectedHandoffConfig.Count, parameters.HandoffConfig.Count);
        foreach (var item in expectedHandoffConfig)
        {
            Assert.True(parameters.HandoffConfig.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.HandoffConfig[item.Key]));
        }
        Assert.Equal(expectedHandoffMode, parameters.HandoffMode);
        Assert.Equal(expectedInferenceGeo, parameters.InferenceGeo);
        Assert.NotNull(parameters.LogitBias);
        Assert.Equal(expectedLogitBias.Count, parameters.LogitBias.Count);
        foreach (var item in expectedLogitBias)
        {
            Assert.True(parameters.LogitBias.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.LogitBias[item.Key]);
        }
        Assert.Equal(expectedLogprobs, parameters.Logprobs);
        Assert.Equal(expectedMaxCompletionTokens, parameters.MaxCompletionTokens);
        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedMaxTurns, parameters.MaxTurns);
        Assert.Equal(expectedMcpServers, parameters.McpServers);
        Assert.NotNull(parameters.Messages);
        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.NotNull(parameters.Modalities);
        Assert.Equal(expectedModalities.Count, parameters.Modalities.Count);
        for (int i = 0; i < expectedModalities.Count; i++)
        {
            Assert.Equal(expectedModalities[i], parameters.Modalities[i]);
        }
        Assert.NotNull(parameters.ModelAttributes);
        Assert.Equal(expectedModelAttributes.Count, parameters.ModelAttributes.Count);
        foreach (var item in expectedModelAttributes)
        {
            Assert.True(parameters.ModelAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, parameters.ModelAttributes[item.Key].Count);
            foreach (var item1 in value)
            {
                Assert.True(
                    parameters.ModelAttributes[item.Key].TryGetValue(item1.Key, out var value1)
                );

                Assert.Equal(value1, parameters.ModelAttributes[item.Key][item1.Key]);
            }
        }
        Assert.Equal(expectedN, parameters.N);
        Assert.NotNull(parameters.OutputConfig);
        Assert.Equal(expectedOutputConfig.Count, parameters.OutputConfig.Count);
        foreach (var item in expectedOutputConfig)
        {
            Assert.True(parameters.OutputConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.OutputConfig[item.Key]);
        }
        Assert.Equal(expectedParallelToolCalls, parameters.ParallelToolCalls);
        Assert.Equal(expectedPrediction, parameters.Prediction);
        Assert.Equal(expectedPresencePenalty, parameters.PresencePenalty);
        Assert.Equal(expectedPromptCacheKey, parameters.PromptCacheKey);
        Assert.Equal(expectedPromptCacheRetention, parameters.PromptCacheRetention);
        Assert.Equal(expectedPromptMode, parameters.PromptMode);
        Assert.Equal(expectedReasoningEffort, parameters.ReasoningEffort);
        Assert.Equal(expectedResponseFormat, parameters.ResponseFormat);
        Assert.Equal(expectedSafePrompt, parameters.SafePrompt);
        Assert.Equal(expectedSafetyIdentifier, parameters.SafetyIdentifier);
        Assert.NotNull(parameters.SafetySettings);
        Assert.Equal(expectedSafetySettings.Count, parameters.SafetySettings.Count);
        for (int i = 0; i < expectedSafetySettings.Count; i++)
        {
            Assert.Equal(expectedSafetySettings[i], parameters.SafetySettings[i]);
        }
        Assert.NotNull(parameters.SearchParameters);
        Assert.Equal(expectedSearchParameters.Count, parameters.SearchParameters.Count);
        foreach (var item in expectedSearchParameters)
        {
            Assert.True(parameters.SearchParameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.SearchParameters[item.Key]);
        }
        Assert.Equal(expectedSeed, parameters.Seed);
        Assert.Equal(expectedServiceTier, parameters.ServiceTier);
        Assert.Equal(expectedSpeed, parameters.Speed);
        Assert.Equal(expectedStop, parameters.Stop);
        Assert.Equal(expectedStore, parameters.Store);
        Assert.NotNull(parameters.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, parameters.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(parameters.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.StreamOptions[item.Key]);
        }
        Assert.Equal(expectedSystemInstruction, parameters.SystemInstruction);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.Equal(expectedThinking, parameters.Thinking);
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.ToolConfig);
        Assert.Equal(expectedToolConfig.Count, parameters.ToolConfig.Count);
        foreach (var item in expectedToolConfig)
        {
            Assert.True(parameters.ToolConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.ToolConfig[item.Key]);
        }
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.Equal(expectedTopK, parameters.TopK);
        Assert.Equal(expectedTopLogprobs, parameters.TopLogprobs);
        Assert.Equal(expectedTopP, parameters.TopP);
        Assert.Equal(expectedUser, parameters.User);
        Assert.Equal(expectedVerbosity, parameters.Verbosity);
        Assert.NotNull(parameters.WebSearchOptions);
        Assert.Equal(expectedWebSearchOptions.Count, parameters.WebSearchOptions.Count);
        foreach (var item in expectedWebSearchOptions)
        {
            Assert.True(parameters.WebSearchOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.WebSearchOptions[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new()
            {
                Format = Completions::Format.Mp3,
                Voice = Completions::UnionMember1.Alloy,
            },
            CachedContent = "cached_content",
            CorrelationID = "correlation_id",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            Deferred = true,
            DeferredCalls =
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
            FrequencyPenalty = -2,
            FunctionCall = "function_call",
            Functions =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Guardrails =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            HandoffConfig = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            HandoffMode = true,
            InferenceGeo = "inference_geo",
            LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
            Logprobs = true,
            MaxCompletionTokens = 0,
            MaxTokens = 1,
            MaxTurns = 5,
            McpServers = "dedalus-labs/example-server",
            Messages =
            [
                new Completions::ChatCompletionDeveloperMessageParam()
                {
                    Content = "string",
                    Name = "name",
                },
            ],
            Metadata = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Modalities = ["string"],
            ModelAttributes = new Dictionary<string, IReadOnlyDictionary<string, double>>()
            {
                {
                    "gpt-5",
                    new Dictionary<string, double>() { { "accuracy", 0.95 }, { "speed", 0.6 } }
                },
            },
            N = 1,
            OutputConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ParallelToolCalls = true,
            Prediction = new(new Completions::PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = Completions::PromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category = Completions::Category.HarmCategoryUnspecified,
                    Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = Completions::Speed.Standard,
            Stop = new(["string"]),
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new Completions::ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Completions::Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Assert.Null(parameters.AutomaticToolExecution);
        Assert.False(parameters.RawBodyData.ContainsKey("automatic_tool_execution"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new()
            {
                Format = Completions::Format.Mp3,
                Voice = Completions::UnionMember1.Alloy,
            },
            CachedContent = "cached_content",
            CorrelationID = "correlation_id",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            Deferred = true,
            DeferredCalls =
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
            FrequencyPenalty = -2,
            FunctionCall = "function_call",
            Functions =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Guardrails =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            HandoffConfig = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            HandoffMode = true,
            InferenceGeo = "inference_geo",
            LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
            Logprobs = true,
            MaxCompletionTokens = 0,
            MaxTokens = 1,
            MaxTurns = 5,
            McpServers = "dedalus-labs/example-server",
            Messages =
            [
                new Completions::ChatCompletionDeveloperMessageParam()
                {
                    Content = "string",
                    Name = "name",
                },
            ],
            Metadata = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Modalities = ["string"],
            ModelAttributes = new Dictionary<string, IReadOnlyDictionary<string, double>>()
            {
                {
                    "gpt-5",
                    new Dictionary<string, double>() { { "accuracy", 0.95 }, { "speed", 0.6 } }
                },
            },
            N = 1,
            OutputConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ParallelToolCalls = true,
            Prediction = new(new Completions::PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = Completions::PromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category = Completions::Category.HarmCategoryUnspecified,
                    Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = Completions::Speed.Standard,
            Stop = new(["string"]),
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new Completions::ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Completions::Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            AutomaticToolExecution = null,
        };

        Assert.Null(parameters.AutomaticToolExecution);
        Assert.False(parameters.RawBodyData.ContainsKey("automatic_tool_execution"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AutomaticToolExecution = true,
        };

        Assert.Null(parameters.AgentAttributes);
        Assert.False(parameters.RawBodyData.ContainsKey("agent_attributes"));
        Assert.Null(parameters.Audio);
        Assert.False(parameters.RawBodyData.ContainsKey("audio"));
        Assert.Null(parameters.CachedContent);
        Assert.False(parameters.RawBodyData.ContainsKey("cached_content"));
        Assert.Null(parameters.CorrelationID);
        Assert.False(parameters.RawBodyData.ContainsKey("correlation_id"));
        Assert.Null(parameters.Credentials);
        Assert.False(parameters.RawBodyData.ContainsKey("credentials"));
        Assert.Null(parameters.Deferred);
        Assert.False(parameters.RawBodyData.ContainsKey("deferred"));
        Assert.Null(parameters.DeferredCalls);
        Assert.False(parameters.RawBodyData.ContainsKey("deferred_calls"));
        Assert.Null(parameters.FrequencyPenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.FunctionCall);
        Assert.False(parameters.RawBodyData.ContainsKey("function_call"));
        Assert.Null(parameters.Functions);
        Assert.False(parameters.RawBodyData.ContainsKey("functions"));
        Assert.Null(parameters.GenerationConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("generation_config"));
        Assert.Null(parameters.Guardrails);
        Assert.False(parameters.RawBodyData.ContainsKey("guardrails"));
        Assert.Null(parameters.HandoffConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("handoff_config"));
        Assert.Null(parameters.HandoffMode);
        Assert.False(parameters.RawBodyData.ContainsKey("handoff_mode"));
        Assert.Null(parameters.InferenceGeo);
        Assert.False(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.LogitBias);
        Assert.False(parameters.RawBodyData.ContainsKey("logit_bias"));
        Assert.Null(parameters.Logprobs);
        Assert.False(parameters.RawBodyData.ContainsKey("logprobs"));
        Assert.Null(parameters.MaxCompletionTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_completion_tokens"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.MaxTurns);
        Assert.False(parameters.RawBodyData.ContainsKey("max_turns"));
        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Messages);
        Assert.False(parameters.RawBodyData.ContainsKey("messages"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Modalities);
        Assert.False(parameters.RawBodyData.ContainsKey("modalities"));
        Assert.Null(parameters.ModelAttributes);
        Assert.False(parameters.RawBodyData.ContainsKey("model_attributes"));
        Assert.Null(parameters.N);
        Assert.False(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ParallelToolCalls);
        Assert.False(parameters.RawBodyData.ContainsKey("parallel_tool_calls"));
        Assert.Null(parameters.Prediction);
        Assert.False(parameters.RawBodyData.ContainsKey("prediction"));
        Assert.Null(parameters.PresencePenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.PromptCacheKey);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt_cache_key"));
        Assert.Null(parameters.PromptCacheRetention);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt_cache_retention"));
        Assert.Null(parameters.PromptMode);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt_mode"));
        Assert.Null(parameters.ReasoningEffort);
        Assert.False(parameters.RawBodyData.ContainsKey("reasoning_effort"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.SafePrompt);
        Assert.False(parameters.RawBodyData.ContainsKey("safe_prompt"));
        Assert.Null(parameters.SafetyIdentifier);
        Assert.False(parameters.RawBodyData.ContainsKey("safety_identifier"));
        Assert.Null(parameters.SafetySettings);
        Assert.False(parameters.RawBodyData.ContainsKey("safety_settings"));
        Assert.Null(parameters.SearchParameters);
        Assert.False(parameters.RawBodyData.ContainsKey("search_parameters"));
        Assert.Null(parameters.Seed);
        Assert.False(parameters.RawBodyData.ContainsKey("seed"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawBodyData.ContainsKey("speed"));
        Assert.Null(parameters.Stop);
        Assert.False(parameters.RawBodyData.ContainsKey("stop"));
        Assert.Null(parameters.Store);
        Assert.False(parameters.RawBodyData.ContainsKey("store"));
        Assert.Null(parameters.StreamOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("stream_options"));
        Assert.Null(parameters.SystemInstruction);
        Assert.False(parameters.RawBodyData.ContainsKey("system_instruction"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.ToolConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_config"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopLogprobs);
        Assert.False(parameters.RawBodyData.ContainsKey("top_logprobs"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
        Assert.Null(parameters.Verbosity);
        Assert.False(parameters.RawBodyData.ContainsKey("verbosity"));
        Assert.Null(parameters.WebSearchOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AutomaticToolExecution = true,

            AgentAttributes = null,
            Audio = null,
            CachedContent = null,
            CorrelationID = null,
            Credentials = null,
            Deferred = null,
            DeferredCalls = null,
            FrequencyPenalty = null,
            FunctionCall = null,
            Functions = null,
            GenerationConfig = null,
            Guardrails = null,
            HandoffConfig = null,
            HandoffMode = null,
            InferenceGeo = null,
            LogitBias = null,
            Logprobs = null,
            MaxCompletionTokens = null,
            MaxTokens = null,
            MaxTurns = null,
            McpServers = null,
            Messages = null,
            Metadata = null,
            Modalities = null,
            ModelAttributes = null,
            N = null,
            OutputConfig = null,
            ParallelToolCalls = null,
            Prediction = null,
            PresencePenalty = null,
            PromptCacheKey = null,
            PromptCacheRetention = null,
            PromptMode = null,
            ReasoningEffort = null,
            ResponseFormat = null,
            SafePrompt = null,
            SafetyIdentifier = null,
            SafetySettings = null,
            SearchParameters = null,
            Seed = null,
            ServiceTier = null,
            Speed = null,
            Stop = null,
            Store = null,
            StreamOptions = null,
            SystemInstruction = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            ToolConfig = null,
            Tools = null,
            TopK = null,
            TopLogprobs = null,
            TopP = null,
            User = null,
            Verbosity = null,
            WebSearchOptions = null,
        };

        Assert.Null(parameters.AgentAttributes);
        Assert.True(parameters.RawBodyData.ContainsKey("agent_attributes"));
        Assert.Null(parameters.Audio);
        Assert.True(parameters.RawBodyData.ContainsKey("audio"));
        Assert.Null(parameters.CachedContent);
        Assert.True(parameters.RawBodyData.ContainsKey("cached_content"));
        Assert.Null(parameters.CorrelationID);
        Assert.True(parameters.RawBodyData.ContainsKey("correlation_id"));
        Assert.Null(parameters.Credentials);
        Assert.True(parameters.RawBodyData.ContainsKey("credentials"));
        Assert.Null(parameters.Deferred);
        Assert.True(parameters.RawBodyData.ContainsKey("deferred"));
        Assert.Null(parameters.DeferredCalls);
        Assert.True(parameters.RawBodyData.ContainsKey("deferred_calls"));
        Assert.Null(parameters.FrequencyPenalty);
        Assert.True(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.FunctionCall);
        Assert.True(parameters.RawBodyData.ContainsKey("function_call"));
        Assert.Null(parameters.Functions);
        Assert.True(parameters.RawBodyData.ContainsKey("functions"));
        Assert.Null(parameters.GenerationConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("generation_config"));
        Assert.Null(parameters.Guardrails);
        Assert.True(parameters.RawBodyData.ContainsKey("guardrails"));
        Assert.Null(parameters.HandoffConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("handoff_config"));
        Assert.Null(parameters.HandoffMode);
        Assert.True(parameters.RawBodyData.ContainsKey("handoff_mode"));
        Assert.Null(parameters.InferenceGeo);
        Assert.True(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.LogitBias);
        Assert.True(parameters.RawBodyData.ContainsKey("logit_bias"));
        Assert.Null(parameters.Logprobs);
        Assert.True(parameters.RawBodyData.ContainsKey("logprobs"));
        Assert.Null(parameters.MaxCompletionTokens);
        Assert.True(parameters.RawBodyData.ContainsKey("max_completion_tokens"));
        Assert.Null(parameters.MaxTokens);
        Assert.True(parameters.RawBodyData.ContainsKey("max_tokens"));
        Assert.Null(parameters.MaxTurns);
        Assert.True(parameters.RawBodyData.ContainsKey("max_turns"));
        Assert.Null(parameters.McpServers);
        Assert.True(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Messages);
        Assert.True(parameters.RawBodyData.ContainsKey("messages"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Modalities);
        Assert.True(parameters.RawBodyData.ContainsKey("modalities"));
        Assert.Null(parameters.ModelAttributes);
        Assert.True(parameters.RawBodyData.ContainsKey("model_attributes"));
        Assert.Null(parameters.N);
        Assert.True(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.OutputConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ParallelToolCalls);
        Assert.True(parameters.RawBodyData.ContainsKey("parallel_tool_calls"));
        Assert.Null(parameters.Prediction);
        Assert.True(parameters.RawBodyData.ContainsKey("prediction"));
        Assert.Null(parameters.PresencePenalty);
        Assert.True(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.PromptCacheKey);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt_cache_key"));
        Assert.Null(parameters.PromptCacheRetention);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt_cache_retention"));
        Assert.Null(parameters.PromptMode);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt_mode"));
        Assert.Null(parameters.ReasoningEffort);
        Assert.True(parameters.RawBodyData.ContainsKey("reasoning_effort"));
        Assert.Null(parameters.ResponseFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.SafePrompt);
        Assert.True(parameters.RawBodyData.ContainsKey("safe_prompt"));
        Assert.Null(parameters.SafetyIdentifier);
        Assert.True(parameters.RawBodyData.ContainsKey("safety_identifier"));
        Assert.Null(parameters.SafetySettings);
        Assert.True(parameters.RawBodyData.ContainsKey("safety_settings"));
        Assert.Null(parameters.SearchParameters);
        Assert.True(parameters.RawBodyData.ContainsKey("search_parameters"));
        Assert.Null(parameters.Seed);
        Assert.True(parameters.RawBodyData.ContainsKey("seed"));
        Assert.Null(parameters.ServiceTier);
        Assert.True(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Speed);
        Assert.True(parameters.RawBodyData.ContainsKey("speed"));
        Assert.Null(parameters.Stop);
        Assert.True(parameters.RawBodyData.ContainsKey("stop"));
        Assert.Null(parameters.Store);
        Assert.True(parameters.RawBodyData.ContainsKey("store"));
        Assert.Null(parameters.StreamOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("stream_options"));
        Assert.Null(parameters.SystemInstruction);
        Assert.True(parameters.RawBodyData.ContainsKey("system_instruction"));
        Assert.Null(parameters.Temperature);
        Assert.True(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.True(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.True(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.ToolConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("tool_config"));
        Assert.Null(parameters.Tools);
        Assert.True(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.True(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopLogprobs);
        Assert.True(parameters.RawBodyData.ContainsKey("top_logprobs"));
        Assert.Null(parameters.TopP);
        Assert.True(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.User);
        Assert.True(parameters.RawBodyData.ContainsKey("user"));
        Assert.Null(parameters.Verbosity);
        Assert.True(parameters.RawBodyData.ContainsKey("verbosity"));
        Assert.Null(parameters.WebSearchOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void Url_Works()
    {
        Completions::CompletionCreateParams parameters = new() { Model = "openai/gpt-5" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/chat/completions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Completions::CompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new()
            {
                Format = Completions::Format.Mp3,
                Voice = Completions::UnionMember1.Alloy,
            },
            AutomaticToolExecution = true,
            CachedContent = "cached_content",
            CorrelationID = "correlation_id",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            Deferred = true,
            DeferredCalls =
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
            FrequencyPenalty = -2,
            FunctionCall = "function_call",
            Functions =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Parameters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Guardrails =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            HandoffConfig = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            HandoffMode = true,
            InferenceGeo = "inference_geo",
            LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
            Logprobs = true,
            MaxCompletionTokens = 0,
            MaxTokens = 1,
            MaxTurns = 5,
            McpServers = "dedalus-labs/example-server",
            Messages =
            [
                new Completions::ChatCompletionDeveloperMessageParam()
                {
                    Content = "string",
                    Name = "name",
                },
            ],
            Metadata = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Modalities = ["string"],
            ModelAttributes = new Dictionary<string, IReadOnlyDictionary<string, double>>()
            {
                {
                    "gpt-5",
                    new Dictionary<string, double>() { { "accuracy", 0.95 }, { "speed", 0.6 } }
                },
            },
            N = 1,
            OutputConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ParallelToolCalls = true,
            Prediction = new(new Completions::PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = Completions::PromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category = Completions::Category.HarmCategoryUnspecified,
                    Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = Completions::Speed.Standard,
            Stop = new(["string"]),
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new Completions::ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Completions::Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Completions::CompletionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void IDValidationWorks()
    {
        Completions::Model value = "string";
        value.Validate();
    }

    [Fact]
    public void DedalusValidationWorks()
    {
        Completions::Model value = new DedalusModel()
        {
            Model = "model",
            Settings = new()
            {
                Attributes = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Audio = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Deferred = true,
                ExtraArgs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ExtraHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                ExtraQuery = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FrequencyPenalty = 0,
                GenerationConfig = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                IncludeUsage = true,
                InputAudioFormat = "input_audio_format",
                InputAudioTranscription = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
                Logprobs = true,
                MaxCompletionTokens = 0,
                MaxTokens = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Modalities = ["string"],
                N = 0,
                OutputAudioFormat = "output_audio_format",
                ParallelToolCalls = true,
                Prediction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                PresencePenalty = 0,
                PromptCacheKey = "prompt_cache_key",
                Reasoning = new()
                {
                    Effort = Effort.None,
                    GenerateSummary = GenerateSummary.Auto,
                    Summary = Summary.Auto,
                },
                ReasoningEffort = "reasoning_effort",
                ResponseFormat = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                SafetyIdentifier = "safety_identifier",
                SafetySettings =
                [
                    new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                ],
                SearchParameters = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Seed = 0,
                ServiceTier = "service_tier",
                Stop = "string",
                Store = true,
                Stream = true,
                StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                SystemInstruction = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Temperature = 0,
                Thinking = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Timeout = 0,
                ToolChoice = UnionMember0.Auto,
                ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                TopK = 0,
                TopLogprobs = 0,
                TopP = 0,
                Truncation = Truncation.Auto,
                TurnDetection = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                User = "user",
                Verbosity = "verbosity",
                Voice = "voice",
                WebSearchOptions = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
            },
        };
        value.Validate();
    }

    [Fact]
    public void DedalusModelChoicesValidationWorks()
    {
        Completions::Model value = new([new DedalusModelChoice("string")]);
        value.Validate();
    }

    [Fact]
    public void IDSerializationRoundtripWorks()
    {
        Completions::Model value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Model>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusSerializationRoundtripWorks()
    {
        Completions::Model value = new DedalusModel()
        {
            Model = "model",
            Settings = new()
            {
                Attributes = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Audio = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Deferred = true,
                ExtraArgs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ExtraHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                ExtraQuery = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                FrequencyPenalty = 0,
                GenerationConfig = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                IncludeUsage = true,
                InputAudioFormat = "input_audio_format",
                InputAudioTranscription = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                LogitBias = new Dictionary<string, long>() { { "foo", 0 } },
                Logprobs = true,
                MaxCompletionTokens = 0,
                MaxTokens = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Modalities = ["string"],
                N = 0,
                OutputAudioFormat = "output_audio_format",
                ParallelToolCalls = true,
                Prediction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                PresencePenalty = 0,
                PromptCacheKey = "prompt_cache_key",
                Reasoning = new()
                {
                    Effort = Effort.None,
                    GenerateSummary = GenerateSummary.Auto,
                    Summary = Summary.Auto,
                },
                ReasoningEffort = "reasoning_effort",
                ResponseFormat = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                SafetyIdentifier = "safety_identifier",
                SafetySettings =
                [
                    new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                ],
                SearchParameters = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Seed = 0,
                ServiceTier = "service_tier",
                Stop = "string",
                Store = true,
                Stream = true,
                StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                SystemInstruction = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Temperature = 0,
                Thinking = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Timeout = 0,
                ToolChoice = UnionMember0.Auto,
                ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                TopK = 0,
                TopLogprobs = 0,
                TopP = 0,
                Truncation = Truncation.Auto,
                TurnDetection = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                User = "user",
                Verbosity = "verbosity",
                Voice = "voice",
                WebSearchOptions = new Dictionary<string, JsonValueInput?>()
                {
                    { "foo", "string" },
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Model>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusModelChoicesSerializationRoundtripWorks()
    {
        Completions::Model value = new([new DedalusModelChoice("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Model>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CredentialsTest : TestBase
{
    [Fact]
    public void CredentialValidationWorks()
    {
        Completions::Credentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void McpValidationWorks()
    {
        Completions::Credentials value = new(
            [
                new Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void CredentialSerializationRoundtripWorks()
    {
        Completions::Credentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Credentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpSerializationRoundtripWorks()
    {
        Completions::Credentials value = new(
            [
                new Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Credentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class McpServersTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Completions::McpServers value = "string";
        value.Validate();
    }

    [Fact]
    public void ServerSpecValidationWorks()
    {
        Completions::McpServers value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        value.Validate();
    }

    [Fact]
    public void McpServersValidationWorks()
    {
        Completions::McpServers value = new([new UnnamedSchemaWithArrayParent0("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Completions::McpServers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerSpecSerializationRoundtripWorks()
    {
        Completions::McpServers value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServersSerializationRoundtripWorks()
    {
        Completions::McpServers value = new([new UnnamedSchemaWithArrayParent0("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void ChatCompletionDeveloperMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionDeveloperMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionSystemMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionSystemMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionUserMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionUserMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionAssistantMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionAssistantMessageParam()
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new Completions::CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionToolMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionToolMessageParam()
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionFunctionMessageParamValidationWorks()
    {
        Completions::Message value = new Completions::ChatCompletionFunctionMessageParam()
        {
            Content = "content",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionDeveloperMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionDeveloperMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionSystemMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionSystemMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionUserMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionUserMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionAssistantMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionAssistantMessageParam()
        {
            Audio = new("id"),
            Content = "string",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Name = "name",
            Refusal = "refusal",
            ToolCalls =
            [
                new Completions::CompletionChatCompletionMessageToolCall()
                {
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    ThoughtSignature = "thought_signature",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionToolMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionToolMessageParam()
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionFunctionMessageParamSerializationRoundtripWorks()
    {
        Completions::Message value = new Completions::ChatCompletionFunctionMessageParam()
        {
            Content = "content",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Message>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PromptModeTest : TestBase
{
    [Theory]
    [InlineData(Completions::PromptMode.Reasoning)]
    public void Validation_Works(Completions::PromptMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::PromptMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::PromptMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Completions::PromptMode.Reasoning)]
    public void SerializationRoundtrip_Works(Completions::PromptMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::PromptMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::PromptMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::PromptMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::PromptMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseFormatTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatText();
        value.Validate();
    }

    [Fact]
    public void JsonSchemaValidationWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatJsonSchema(
            new JsonSchema()
            {
                Name = "name",
                Description = "description",
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Strict = true,
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonObjectValidationWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatJsonObject();
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatText();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonSchemaSerializationRoundtripWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatJsonSchema(
            new JsonSchema()
            {
                Name = "name",
                Description = "description",
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Strict = true,
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonObjectSerializationRoundtripWorks()
    {
        Completions::ResponseFormat value = new ResponseFormatJsonObject();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SafetySettingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Completions::SafetySetting
        {
            Category = Completions::Category.HarmCategoryUnspecified,
            Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
        };

        ApiEnum<string, Completions::Category> expectedCategory =
            Completions::Category.HarmCategoryUnspecified;
        ApiEnum<string, Completions::Threshold> expectedThreshold =
            Completions::Threshold.HarmBlockThresholdUnspecified;

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedThreshold, model.Threshold);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Completions::SafetySetting
        {
            Category = Completions::Category.HarmCategoryUnspecified,
            Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::SafetySetting>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Completions::SafetySetting
        {
            Category = Completions::Category.HarmCategoryUnspecified,
            Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::SafetySetting>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Completions::Category> expectedCategory =
            Completions::Category.HarmCategoryUnspecified;
        ApiEnum<string, Completions::Threshold> expectedThreshold =
            Completions::Threshold.HarmBlockThresholdUnspecified;

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Completions::SafetySetting
        {
            Category = Completions::Category.HarmCategoryUnspecified,
            Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Completions::SafetySetting
        {
            Category = Completions::Category.HarmCategoryUnspecified,
            Threshold = Completions::Threshold.HarmBlockThresholdUnspecified,
        };

        Completions::SafetySetting copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Completions::Category.HarmCategoryUnspecified)]
    [InlineData(Completions::Category.HarmCategoryDerogatory)]
    [InlineData(Completions::Category.HarmCategoryToxicity)]
    [InlineData(Completions::Category.HarmCategoryViolence)]
    [InlineData(Completions::Category.HarmCategorySexual)]
    [InlineData(Completions::Category.HarmCategoryMedical)]
    [InlineData(Completions::Category.HarmCategoryDangerous)]
    [InlineData(Completions::Category.HarmCategoryHarassment)]
    [InlineData(Completions::Category.HarmCategoryHateSpeech)]
    [InlineData(Completions::Category.HarmCategorySexuallyExplicit)]
    [InlineData(Completions::Category.HarmCategoryDangerousContent)]
    [InlineData(Completions::Category.HarmCategoryCivicIntegrity)]
    public void Validation_Works(Completions::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Completions::Category.HarmCategoryUnspecified)]
    [InlineData(Completions::Category.HarmCategoryDerogatory)]
    [InlineData(Completions::Category.HarmCategoryToxicity)]
    [InlineData(Completions::Category.HarmCategoryViolence)]
    [InlineData(Completions::Category.HarmCategorySexual)]
    [InlineData(Completions::Category.HarmCategoryMedical)]
    [InlineData(Completions::Category.HarmCategoryDangerous)]
    [InlineData(Completions::Category.HarmCategoryHarassment)]
    [InlineData(Completions::Category.HarmCategoryHateSpeech)]
    [InlineData(Completions::Category.HarmCategorySexuallyExplicit)]
    [InlineData(Completions::Category.HarmCategoryDangerousContent)]
    [InlineData(Completions::Category.HarmCategoryCivicIntegrity)]
    public void SerializationRoundtrip_Works(Completions::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThresholdTest : TestBase
{
    [Theory]
    [InlineData(Completions::Threshold.HarmBlockThresholdUnspecified)]
    [InlineData(Completions::Threshold.BlockLowAndAbove)]
    [InlineData(Completions::Threshold.BlockMediumAndAbove)]
    [InlineData(Completions::Threshold.BlockOnlyHigh)]
    [InlineData(Completions::Threshold.BlockNone)]
    [InlineData(Completions::Threshold.Off)]
    public void Validation_Works(Completions::Threshold rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Threshold> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Threshold>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Completions::Threshold.HarmBlockThresholdUnspecified)]
    [InlineData(Completions::Threshold.BlockLowAndAbove)]
    [InlineData(Completions::Threshold.BlockMediumAndAbove)]
    [InlineData(Completions::Threshold.BlockOnlyHigh)]
    [InlineData(Completions::Threshold.BlockNone)]
    [InlineData(Completions::Threshold.Off)]
    public void SerializationRoundtrip_Works(Completions::Threshold rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Threshold> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Threshold>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Threshold>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Threshold>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Completions::Speed.Standard)]
    [InlineData(Completions::Speed.Fast)]
    public void Validation_Works(Completions::Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Completions::Speed.Standard)]
    [InlineData(Completions::Speed.Fast)]
    public void SerializationRoundtrip_Works(Completions::Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Completions::Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Completions::Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Completions::Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StopTest : TestBase
{
    [Fact]
    public void StringsValidationWorks()
    {
        Completions::Stop value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Completions::Stop value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Completions::Stop value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Stop>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Completions::Stop value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Stop>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SystemInstructionTest : TestBase
{
    [Fact]
    public void JsonObjectInputValidationWorks()
    {
        Completions::SystemInstruction value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Completions::SystemInstruction value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonObjectInputSerializationRoundtripWorks()
    {
        Completions::SystemInstruction value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::SystemInstruction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Completions::SystemInstruction value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::SystemInstruction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThinkingTest : TestBase
{
    [Fact]
    public void ConfigEnabledValidationWorks()
    {
        Completions::Thinking value = new Completions::ThinkingConfigEnabled(1024);
        value.Validate();
    }

    [Fact]
    public void ConfigDisabledValidationWorks()
    {
        Completions::Thinking value = new Completions::ThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        Completions::Thinking value = new Completions::Adaptive();
        value.Validate();
    }

    [Fact]
    public void ConfigEnabledSerializationRoundtripWorks()
    {
        Completions::Thinking value = new Completions::ThinkingConfigEnabled(1024);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConfigDisabledSerializationRoundtripWorks()
    {
        Completions::Thinking value = new Completions::ThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        Completions::Thinking value = new Completions::Adaptive();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AdaptiveTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Completions::Adaptive();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Completions::Adaptive>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "adaptive"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Completions::Adaptive>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DedalusInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Completions::Adaptive();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Adaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Completions::Adaptive>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "adaptive"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Adaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Completions::Adaptive>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::Adaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Completions::ToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void AutoValidationWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceAny()
        {
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Completions::ToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceAny()
        {
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        Completions::ToolChoice value = new Completions::ToolChoiceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Completions::ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
