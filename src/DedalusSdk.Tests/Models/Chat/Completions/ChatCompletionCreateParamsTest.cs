using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        ChatCompletionCreateParamsModel expectedModel = "openai/gpt-5";
        Dictionary<string, double> expectedAgentAttributes = new()
        {
            { "accuracy", 0.9 },
            { "complexity", 0.8 },
        };
        ChatCompletionAudioParam expectedAudio = new()
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };
        bool expectedAutomaticToolExecution = true;
        string expectedCachedContent = "cached_content";
        string expectedCorrelationID = "correlation_id";
        ChatCompletionCreateParamsCredentials expectedCredentials = new Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
        };
        bool expectedDeferred = true;
        List<DeferredCallResponse> expectedDeferredCalls =
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
        List<ChatCompletionFunctions> expectedFunctions =
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
        ChatCompletionCreateParamsMcpServers expectedMcpServers = "dedalus-labs/example-server";
        List<ChatCompletionCreateParamsMessage> expectedMessages =
        [
            new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
        PredictionContent expectedPrediction = new(new PredictionContentContent("string"));
        double expectedPresencePenalty = -2;
        string expectedPromptCacheKey = "prompt_cache_key";
        string expectedPromptCacheRetention = "prompt_cache_retention";
        ApiEnum<string, ChatCompletionCreateParamsPromptMode> expectedPromptMode =
            ChatCompletionCreateParamsPromptMode.Reasoning;
        string expectedReasoningEffort = "reasoning_effort";
        ChatCompletionCreateParamsResponseFormat expectedResponseFormat = new ResponseFormatText();
        bool expectedSafePrompt = true;
        string expectedSafetyIdentifier = "safety_identifier";
        List<ChatCompletionCreateParamsSafetySetting> expectedSafetySettings =
        [
            new()
            {
                Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                Threshold =
                    ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
            },
        ];
        Dictionary<string, JsonValueInput?> expectedSearchParameters = new()
        {
            { "foo", "string" },
        };
        long expectedSeed = 0;
        string expectedServiceTier = "service_tier";
        ApiEnum<string, ChatCompletionCreateParamsSpeed> expectedSpeed =
            ChatCompletionCreateParamsSpeed.Standard;
        ChatCompletionCreateParamsStop expectedStop = new(["string"]);
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        ChatCompletionCreateParamsSystemInstruction expectedSystemInstruction = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        double expectedTemperature = 0;
        ChatCompletionCreateParamsThinking expectedThinking = new ThinkingConfigEnabled(1024);
        ChatCompletionCreateParamsToolChoice expectedToolChoice = "string";
        Dictionary<string, JsonValueInput?> expectedToolConfig = new() { { "foo", "string" } };
        List<ChatCompletionToolParam> expectedTools =
        [
            new() { Function = new("name"), Type = Type.Function },
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

        Assert.Equal(expectedModel, model.Model);
        Assert.NotNull(model.AgentAttributes);
        Assert.Equal(expectedAgentAttributes.Count, model.AgentAttributes.Count);
        foreach (var item in expectedAgentAttributes)
        {
            Assert.True(model.AgentAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.AgentAttributes[item.Key]);
        }
        Assert.Equal(expectedAudio, model.Audio);
        Assert.Equal(expectedAutomaticToolExecution, model.AutomaticToolExecution);
        Assert.Equal(expectedCachedContent, model.CachedContent);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.Equal(expectedCredentials, model.Credentials);
        Assert.Equal(expectedDeferred, model.Deferred);
        Assert.NotNull(model.DeferredCalls);
        Assert.Equal(expectedDeferredCalls.Count, model.DeferredCalls.Count);
        for (int i = 0; i < expectedDeferredCalls.Count; i++)
        {
            Assert.Equal(expectedDeferredCalls[i], model.DeferredCalls[i]);
        }
        Assert.Equal(expectedFrequencyPenalty, model.FrequencyPenalty);
        Assert.Equal(expectedFunctionCall, model.FunctionCall);
        Assert.NotNull(model.Functions);
        Assert.Equal(expectedFunctions.Count, model.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], model.Functions[i]);
        }
        Assert.NotNull(model.GenerationConfig);
        Assert.Equal(expectedGenerationConfig.Count, model.GenerationConfig.Count);
        foreach (var item in expectedGenerationConfig)
        {
            Assert.True(model.GenerationConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.GenerationConfig[item.Key]);
        }
        Assert.NotNull(model.Guardrails);
        Assert.Equal(expectedGuardrails.Count, model.Guardrails.Count);
        for (int i = 0; i < expectedGuardrails.Count; i++)
        {
            Assert.Equal(expectedGuardrails[i].Count, model.Guardrails[i].Count);
            foreach (var item in expectedGuardrails[i])
            {
                Assert.True(model.Guardrails[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Guardrails[i][item.Key]));
            }
        }
        Assert.NotNull(model.HandoffConfig);
        Assert.Equal(expectedHandoffConfig.Count, model.HandoffConfig.Count);
        foreach (var item in expectedHandoffConfig)
        {
            Assert.True(model.HandoffConfig.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.HandoffConfig[item.Key]));
        }
        Assert.Equal(expectedHandoffMode, model.HandoffMode);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.NotNull(model.LogitBias);
        Assert.Equal(expectedLogitBias.Count, model.LogitBias.Count);
        foreach (var item in expectedLogitBias)
        {
            Assert.True(model.LogitBias.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.LogitBias[item.Key]);
        }
        Assert.Equal(expectedLogprobs, model.Logprobs);
        Assert.Equal(expectedMaxCompletionTokens, model.MaxCompletionTokens);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMaxTurns, model.MaxTurns);
        Assert.Equal(expectedMcpServers, model.McpServers);
        Assert.NotNull(model.Messages);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.NotNull(model.Modalities);
        Assert.Equal(expectedModalities.Count, model.Modalities.Count);
        for (int i = 0; i < expectedModalities.Count; i++)
        {
            Assert.Equal(expectedModalities[i], model.Modalities[i]);
        }
        Assert.NotNull(model.ModelAttributes);
        Assert.Equal(expectedModelAttributes.Count, model.ModelAttributes.Count);
        foreach (var item in expectedModelAttributes)
        {
            Assert.True(model.ModelAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.ModelAttributes[item.Key].Count);
            foreach (var item1 in value)
            {
                Assert.True(model.ModelAttributes[item.Key].TryGetValue(item1.Key, out var value1));

                Assert.Equal(value1, model.ModelAttributes[item.Key][item1.Key]);
            }
        }
        Assert.Equal(expectedN, model.N);
        Assert.NotNull(model.OutputConfig);
        Assert.Equal(expectedOutputConfig.Count, model.OutputConfig.Count);
        foreach (var item in expectedOutputConfig)
        {
            Assert.True(model.OutputConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.OutputConfig[item.Key]);
        }
        Assert.Equal(expectedParallelToolCalls, model.ParallelToolCalls);
        Assert.Equal(expectedPrediction, model.Prediction);
        Assert.Equal(expectedPresencePenalty, model.PresencePenalty);
        Assert.Equal(expectedPromptCacheKey, model.PromptCacheKey);
        Assert.Equal(expectedPromptCacheRetention, model.PromptCacheRetention);
        Assert.Equal(expectedPromptMode, model.PromptMode);
        Assert.Equal(expectedReasoningEffort, model.ReasoningEffort);
        Assert.Equal(expectedResponseFormat, model.ResponseFormat);
        Assert.Equal(expectedSafePrompt, model.SafePrompt);
        Assert.Equal(expectedSafetyIdentifier, model.SafetyIdentifier);
        Assert.NotNull(model.SafetySettings);
        Assert.Equal(expectedSafetySettings.Count, model.SafetySettings.Count);
        for (int i = 0; i < expectedSafetySettings.Count; i++)
        {
            Assert.Equal(expectedSafetySettings[i], model.SafetySettings[i]);
        }
        Assert.NotNull(model.SearchParameters);
        Assert.Equal(expectedSearchParameters.Count, model.SearchParameters.Count);
        foreach (var item in expectedSearchParameters)
        {
            Assert.True(model.SearchParameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.SearchParameters[item.Key]);
        }
        Assert.Equal(expectedSeed, model.Seed);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedStop, model.Stop);
        Assert.Equal(expectedStore, model.Store);
        Assert.Equal(expectedStream, model.Stream);
        Assert.NotNull(model.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, model.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(model.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.StreamOptions[item.Key]);
        }
        Assert.Equal(expectedSystemInstruction, model.SystemInstruction);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.NotNull(model.ToolConfig);
        Assert.Equal(expectedToolConfig.Count, model.ToolConfig.Count);
        foreach (var item in expectedToolConfig)
        {
            Assert.True(model.ToolConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ToolConfig[item.Key]);
        }
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopLogprobs, model.TopLogprobs);
        Assert.Equal(expectedTopP, model.TopP);
        Assert.Equal(expectedUser, model.User);
        Assert.Equal(expectedVerbosity, model.Verbosity);
        Assert.NotNull(model.WebSearchOptions);
        Assert.Equal(expectedWebSearchOptions.Count, model.WebSearchOptions.Count);
        foreach (var item in expectedWebSearchOptions)
        {
            Assert.True(model.WebSearchOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.WebSearchOptions[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChatCompletionCreateParamsModel expectedModel = "openai/gpt-5";
        Dictionary<string, double> expectedAgentAttributes = new()
        {
            { "accuracy", 0.9 },
            { "complexity", 0.8 },
        };
        ChatCompletionAudioParam expectedAudio = new()
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };
        bool expectedAutomaticToolExecution = true;
        string expectedCachedContent = "cached_content";
        string expectedCorrelationID = "correlation_id";
        ChatCompletionCreateParamsCredentials expectedCredentials = new Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
        };
        bool expectedDeferred = true;
        List<DeferredCallResponse> expectedDeferredCalls =
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
        List<ChatCompletionFunctions> expectedFunctions =
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
        ChatCompletionCreateParamsMcpServers expectedMcpServers = "dedalus-labs/example-server";
        List<ChatCompletionCreateParamsMessage> expectedMessages =
        [
            new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
        PredictionContent expectedPrediction = new(new PredictionContentContent("string"));
        double expectedPresencePenalty = -2;
        string expectedPromptCacheKey = "prompt_cache_key";
        string expectedPromptCacheRetention = "prompt_cache_retention";
        ApiEnum<string, ChatCompletionCreateParamsPromptMode> expectedPromptMode =
            ChatCompletionCreateParamsPromptMode.Reasoning;
        string expectedReasoningEffort = "reasoning_effort";
        ChatCompletionCreateParamsResponseFormat expectedResponseFormat = new ResponseFormatText();
        bool expectedSafePrompt = true;
        string expectedSafetyIdentifier = "safety_identifier";
        List<ChatCompletionCreateParamsSafetySetting> expectedSafetySettings =
        [
            new()
            {
                Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                Threshold =
                    ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
            },
        ];
        Dictionary<string, JsonValueInput?> expectedSearchParameters = new()
        {
            { "foo", "string" },
        };
        long expectedSeed = 0;
        string expectedServiceTier = "service_tier";
        ApiEnum<string, ChatCompletionCreateParamsSpeed> expectedSpeed =
            ChatCompletionCreateParamsSpeed.Standard;
        ChatCompletionCreateParamsStop expectedStop = new(["string"]);
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        ChatCompletionCreateParamsSystemInstruction expectedSystemInstruction = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        double expectedTemperature = 0;
        ChatCompletionCreateParamsThinking expectedThinking = new ThinkingConfigEnabled(1024);
        ChatCompletionCreateParamsToolChoice expectedToolChoice = "string";
        Dictionary<string, JsonValueInput?> expectedToolConfig = new() { { "foo", "string" } };
        List<ChatCompletionToolParam> expectedTools =
        [
            new() { Function = new("name"), Type = Type.Function },
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

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.NotNull(deserialized.AgentAttributes);
        Assert.Equal(expectedAgentAttributes.Count, deserialized.AgentAttributes.Count);
        foreach (var item in expectedAgentAttributes)
        {
            Assert.True(deserialized.AgentAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.AgentAttributes[item.Key]);
        }
        Assert.Equal(expectedAudio, deserialized.Audio);
        Assert.Equal(expectedAutomaticToolExecution, deserialized.AutomaticToolExecution);
        Assert.Equal(expectedCachedContent, deserialized.CachedContent);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.Equal(expectedCredentials, deserialized.Credentials);
        Assert.Equal(expectedDeferred, deserialized.Deferred);
        Assert.NotNull(deserialized.DeferredCalls);
        Assert.Equal(expectedDeferredCalls.Count, deserialized.DeferredCalls.Count);
        for (int i = 0; i < expectedDeferredCalls.Count; i++)
        {
            Assert.Equal(expectedDeferredCalls[i], deserialized.DeferredCalls[i]);
        }
        Assert.Equal(expectedFrequencyPenalty, deserialized.FrequencyPenalty);
        Assert.Equal(expectedFunctionCall, deserialized.FunctionCall);
        Assert.NotNull(deserialized.Functions);
        Assert.Equal(expectedFunctions.Count, deserialized.Functions.Count);
        for (int i = 0; i < expectedFunctions.Count; i++)
        {
            Assert.Equal(expectedFunctions[i], deserialized.Functions[i]);
        }
        Assert.NotNull(deserialized.GenerationConfig);
        Assert.Equal(expectedGenerationConfig.Count, deserialized.GenerationConfig.Count);
        foreach (var item in expectedGenerationConfig)
        {
            Assert.True(deserialized.GenerationConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.GenerationConfig[item.Key]);
        }
        Assert.NotNull(deserialized.Guardrails);
        Assert.Equal(expectedGuardrails.Count, deserialized.Guardrails.Count);
        for (int i = 0; i < expectedGuardrails.Count; i++)
        {
            Assert.Equal(expectedGuardrails[i].Count, deserialized.Guardrails[i].Count);
            foreach (var item in expectedGuardrails[i])
            {
                Assert.True(deserialized.Guardrails[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Guardrails[i][item.Key]));
            }
        }
        Assert.NotNull(deserialized.HandoffConfig);
        Assert.Equal(expectedHandoffConfig.Count, deserialized.HandoffConfig.Count);
        foreach (var item in expectedHandoffConfig)
        {
            Assert.True(deserialized.HandoffConfig.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.HandoffConfig[item.Key]));
        }
        Assert.Equal(expectedHandoffMode, deserialized.HandoffMode);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.NotNull(deserialized.LogitBias);
        Assert.Equal(expectedLogitBias.Count, deserialized.LogitBias.Count);
        foreach (var item in expectedLogitBias)
        {
            Assert.True(deserialized.LogitBias.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.LogitBias[item.Key]);
        }
        Assert.Equal(expectedLogprobs, deserialized.Logprobs);
        Assert.Equal(expectedMaxCompletionTokens, deserialized.MaxCompletionTokens);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMaxTurns, deserialized.MaxTurns);
        Assert.Equal(expectedMcpServers, deserialized.McpServers);
        Assert.NotNull(deserialized.Messages);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.NotNull(deserialized.Modalities);
        Assert.Equal(expectedModalities.Count, deserialized.Modalities.Count);
        for (int i = 0; i < expectedModalities.Count; i++)
        {
            Assert.Equal(expectedModalities[i], deserialized.Modalities[i]);
        }
        Assert.NotNull(deserialized.ModelAttributes);
        Assert.Equal(expectedModelAttributes.Count, deserialized.ModelAttributes.Count);
        foreach (var item in expectedModelAttributes)
        {
            Assert.True(deserialized.ModelAttributes.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.ModelAttributes[item.Key].Count);
            foreach (var item1 in value)
            {
                Assert.True(
                    deserialized.ModelAttributes[item.Key].TryGetValue(item1.Key, out var value1)
                );

                Assert.Equal(value1, deserialized.ModelAttributes[item.Key][item1.Key]);
            }
        }
        Assert.Equal(expectedN, deserialized.N);
        Assert.NotNull(deserialized.OutputConfig);
        Assert.Equal(expectedOutputConfig.Count, deserialized.OutputConfig.Count);
        foreach (var item in expectedOutputConfig)
        {
            Assert.True(deserialized.OutputConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.OutputConfig[item.Key]);
        }
        Assert.Equal(expectedParallelToolCalls, deserialized.ParallelToolCalls);
        Assert.Equal(expectedPrediction, deserialized.Prediction);
        Assert.Equal(expectedPresencePenalty, deserialized.PresencePenalty);
        Assert.Equal(expectedPromptCacheKey, deserialized.PromptCacheKey);
        Assert.Equal(expectedPromptCacheRetention, deserialized.PromptCacheRetention);
        Assert.Equal(expectedPromptMode, deserialized.PromptMode);
        Assert.Equal(expectedReasoningEffort, deserialized.ReasoningEffort);
        Assert.Equal(expectedResponseFormat, deserialized.ResponseFormat);
        Assert.Equal(expectedSafePrompt, deserialized.SafePrompt);
        Assert.Equal(expectedSafetyIdentifier, deserialized.SafetyIdentifier);
        Assert.NotNull(deserialized.SafetySettings);
        Assert.Equal(expectedSafetySettings.Count, deserialized.SafetySettings.Count);
        for (int i = 0; i < expectedSafetySettings.Count; i++)
        {
            Assert.Equal(expectedSafetySettings[i], deserialized.SafetySettings[i]);
        }
        Assert.NotNull(deserialized.SearchParameters);
        Assert.Equal(expectedSearchParameters.Count, deserialized.SearchParameters.Count);
        foreach (var item in expectedSearchParameters)
        {
            Assert.True(deserialized.SearchParameters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.SearchParameters[item.Key]);
        }
        Assert.Equal(expectedSeed, deserialized.Seed);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedStop, deserialized.Stop);
        Assert.Equal(expectedStore, deserialized.Store);
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.NotNull(deserialized.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, deserialized.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(deserialized.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.StreamOptions[item.Key]);
        }
        Assert.Equal(expectedSystemInstruction, deserialized.SystemInstruction);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.NotNull(deserialized.ToolConfig);
        Assert.Equal(expectedToolConfig.Count, deserialized.ToolConfig.Count);
        foreach (var item in expectedToolConfig)
        {
            Assert.True(deserialized.ToolConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ToolConfig[item.Key]);
        }
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedTopK, deserialized.TopK);
        Assert.Equal(expectedTopLogprobs, deserialized.TopLogprobs);
        Assert.Equal(expectedTopP, deserialized.TopP);
        Assert.Equal(expectedUser, deserialized.User);
        Assert.Equal(expectedVerbosity, deserialized.Verbosity);
        Assert.NotNull(deserialized.WebSearchOptions);
        Assert.Equal(expectedWebSearchOptions.Count, deserialized.WebSearchOptions.Count);
        foreach (var item in expectedWebSearchOptions)
        {
            Assert.True(deserialized.WebSearchOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.WebSearchOptions[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Assert.Null(model.AutomaticToolExecution);
        Assert.False(model.RawData.ContainsKey("automatic_tool_execution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            AutomaticToolExecution = null,
        };

        Assert.Null(model.AutomaticToolExecution);
        Assert.False(model.RawData.ContainsKey("automatic_tool_execution"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            AutomaticToolExecution = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AutomaticToolExecution = true,
        };

        Assert.Null(model.AgentAttributes);
        Assert.False(model.RawData.ContainsKey("agent_attributes"));
        Assert.Null(model.Audio);
        Assert.False(model.RawData.ContainsKey("audio"));
        Assert.Null(model.CachedContent);
        Assert.False(model.RawData.ContainsKey("cached_content"));
        Assert.Null(model.CorrelationID);
        Assert.False(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.Deferred);
        Assert.False(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.DeferredCalls);
        Assert.False(model.RawData.ContainsKey("deferred_calls"));
        Assert.Null(model.FrequencyPenalty);
        Assert.False(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Functions);
        Assert.False(model.RawData.ContainsKey("functions"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.Guardrails);
        Assert.False(model.RawData.ContainsKey("guardrails"));
        Assert.Null(model.HandoffConfig);
        Assert.False(model.RawData.ContainsKey("handoff_config"));
        Assert.Null(model.HandoffMode);
        Assert.False(model.RawData.ContainsKey("handoff_mode"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.LogitBias);
        Assert.False(model.RawData.ContainsKey("logit_bias"));
        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.MaxCompletionTokens);
        Assert.False(model.RawData.ContainsKey("max_completion_tokens"));
        Assert.Null(model.MaxTokens);
        Assert.False(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.MaxTurns);
        Assert.False(model.RawData.ContainsKey("max_turns"));
        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Modalities);
        Assert.False(model.RawData.ContainsKey("modalities"));
        Assert.Null(model.ModelAttributes);
        Assert.False(model.RawData.ContainsKey("model_attributes"));
        Assert.Null(model.N);
        Assert.False(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.ParallelToolCalls);
        Assert.False(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.Prediction);
        Assert.False(model.RawData.ContainsKey("prediction"));
        Assert.Null(model.PresencePenalty);
        Assert.False(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PromptCacheKey);
        Assert.False(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.PromptCacheRetention);
        Assert.False(model.RawData.ContainsKey("prompt_cache_retention"));
        Assert.Null(model.PromptMode);
        Assert.False(model.RawData.ContainsKey("prompt_mode"));
        Assert.Null(model.ReasoningEffort);
        Assert.False(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ResponseFormat);
        Assert.False(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.SafePrompt);
        Assert.False(model.RawData.ContainsKey("safe_prompt"));
        Assert.Null(model.SafetyIdentifier);
        Assert.False(model.RawData.ContainsKey("safety_identifier"));
        Assert.Null(model.SafetySettings);
        Assert.False(model.RawData.ContainsKey("safety_settings"));
        Assert.Null(model.SearchParameters);
        Assert.False(model.RawData.ContainsKey("search_parameters"));
        Assert.Null(model.Seed);
        Assert.False(model.RawData.ContainsKey("seed"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
        Assert.Null(model.Stop);
        Assert.False(model.RawData.ContainsKey("stop"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.StreamOptions);
        Assert.False(model.RawData.ContainsKey("stream_options"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.ToolConfig);
        Assert.False(model.RawData.ContainsKey("tool_config"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopLogprobs);
        Assert.False(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
        Assert.Null(model.Verbosity);
        Assert.False(model.RawData.ContainsKey("verbosity"));
        Assert.Null(model.WebSearchOptions);
        Assert.False(model.RawData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AutomaticToolExecution = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatCompletionCreateParams
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
            Stream = null,
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

        Assert.Null(model.AgentAttributes);
        Assert.True(model.RawData.ContainsKey("agent_attributes"));
        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
        Assert.Null(model.CachedContent);
        Assert.True(model.RawData.ContainsKey("cached_content"));
        Assert.Null(model.CorrelationID);
        Assert.True(model.RawData.ContainsKey("correlation_id"));
        Assert.Null(model.Credentials);
        Assert.True(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.Deferred);
        Assert.True(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.DeferredCalls);
        Assert.True(model.RawData.ContainsKey("deferred_calls"));
        Assert.Null(model.FrequencyPenalty);
        Assert.True(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.FunctionCall);
        Assert.True(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Functions);
        Assert.True(model.RawData.ContainsKey("functions"));
        Assert.Null(model.GenerationConfig);
        Assert.True(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.Guardrails);
        Assert.True(model.RawData.ContainsKey("guardrails"));
        Assert.Null(model.HandoffConfig);
        Assert.True(model.RawData.ContainsKey("handoff_config"));
        Assert.Null(model.HandoffMode);
        Assert.True(model.RawData.ContainsKey("handoff_mode"));
        Assert.Null(model.InferenceGeo);
        Assert.True(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.LogitBias);
        Assert.True(model.RawData.ContainsKey("logit_bias"));
        Assert.Null(model.Logprobs);
        Assert.True(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.MaxCompletionTokens);
        Assert.True(model.RawData.ContainsKey("max_completion_tokens"));
        Assert.Null(model.MaxTokens);
        Assert.True(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.MaxTurns);
        Assert.True(model.RawData.ContainsKey("max_turns"));
        Assert.Null(model.McpServers);
        Assert.True(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Messages);
        Assert.True(model.RawData.ContainsKey("messages"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Modalities);
        Assert.True(model.RawData.ContainsKey("modalities"));
        Assert.Null(model.ModelAttributes);
        Assert.True(model.RawData.ContainsKey("model_attributes"));
        Assert.Null(model.N);
        Assert.True(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputConfig);
        Assert.True(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.ParallelToolCalls);
        Assert.True(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.Prediction);
        Assert.True(model.RawData.ContainsKey("prediction"));
        Assert.Null(model.PresencePenalty);
        Assert.True(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PromptCacheKey);
        Assert.True(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.PromptCacheRetention);
        Assert.True(model.RawData.ContainsKey("prompt_cache_retention"));
        Assert.Null(model.PromptMode);
        Assert.True(model.RawData.ContainsKey("prompt_mode"));
        Assert.Null(model.ReasoningEffort);
        Assert.True(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ResponseFormat);
        Assert.True(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.SafePrompt);
        Assert.True(model.RawData.ContainsKey("safe_prompt"));
        Assert.Null(model.SafetyIdentifier);
        Assert.True(model.RawData.ContainsKey("safety_identifier"));
        Assert.Null(model.SafetySettings);
        Assert.True(model.RawData.ContainsKey("safety_settings"));
        Assert.Null(model.SearchParameters);
        Assert.True(model.RawData.ContainsKey("search_parameters"));
        Assert.Null(model.Seed);
        Assert.True(model.RawData.ContainsKey("seed"));
        Assert.Null(model.ServiceTier);
        Assert.True(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
        Assert.Null(model.Stop);
        Assert.True(model.RawData.ContainsKey("stop"));
        Assert.Null(model.Store);
        Assert.True(model.RawData.ContainsKey("store"));
        Assert.Null(model.Stream);
        Assert.True(model.RawData.ContainsKey("stream"));
        Assert.Null(model.StreamOptions);
        Assert.True(model.RawData.ContainsKey("stream_options"));
        Assert.Null(model.SystemInstruction);
        Assert.True(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.True(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.True(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.ToolConfig);
        Assert.True(model.RawData.ContainsKey("tool_config"));
        Assert.Null(model.Tools);
        Assert.True(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.True(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopLogprobs);
        Assert.True(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.True(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
        Assert.Null(model.Verbosity);
        Assert.True(model.RawData.ContainsKey("verbosity"));
        Assert.Null(model.WebSearchOptions);
        Assert.True(model.RawData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionCreateParams
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
            Stream = null,
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionCreateParams
        {
            Model = "openai/gpt-5",
            AgentAttributes = new Dictionary<string, double>()
            {
                { "accuracy", 0.9 },
                { "complexity", 0.8 },
            },
            Audio = new() { Format = Format.Wav, Voice = UnionMember1.Alloy },
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
                new ChatCompletionDeveloperMessageParam() { Content = "string", Name = "name" },
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
            Prediction = new(new PredictionContentContent("string")),
            PresencePenalty = -2,
            PromptCacheKey = "prompt_cache_key",
            PromptCacheRetention = "prompt_cache_retention",
            PromptMode = ChatCompletionCreateParamsPromptMode.Reasoning,
            ReasoningEffort = "reasoning_effort",
            ResponseFormat = new ResponseFormatText(),
            SafePrompt = true,
            SafetyIdentifier = "safety_identifier",
            SafetySettings =
            [
                new()
                {
                    Category =
                        ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
                    Threshold =
                        ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
                },
            ],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Speed = ChatCompletionCreateParamsSpeed.Standard,
            Stop = new(["string"]),
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new(
                new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
            ),
            Temperature = 0,
            Thinking = new ThinkingConfigEnabled(1024),
            ToolChoice = "string",
            ToolConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Tools = [new() { Function = new("name"), Type = Type.Function }],
            TopK = 0,
            TopLogprobs = 0,
            TopP = 0,
            User = "user",
            Verbosity = "verbosity",
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        ChatCompletionCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionCreateParamsModelTest : TestBase
{
    [Fact]
    public void IDValidationWorks()
    {
        ChatCompletionCreateParamsModel value = "string";
        value.Validate();
    }

    [Fact]
    public void DedalusValidationWorks()
    {
        ChatCompletionCreateParamsModel value = new DedalusModel()
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
        ChatCompletionCreateParamsModel value = new([new DedalusModelChoice("string")]);
        value.Validate();
    }

    [Fact]
    public void IDSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsModel value = new DedalusModel()
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusModelChoicesSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsModel value = new([new DedalusModelChoice("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsCredentialsTest : TestBase
{
    [Fact]
    public void CredentialValidationWorks()
    {
        ChatCompletionCreateParamsCredentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void McpValidationWorks()
    {
        ChatCompletionCreateParamsCredentials value = new(
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
        ChatCompletionCreateParamsCredentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsCredentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsCredentials value = new(
            [
                new Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsCredentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsMcpServersTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionCreateParamsMcpServers value = "string";
        value.Validate();
    }

    [Fact]
    public void ServerSpecValidationWorks()
    {
        ChatCompletionCreateParamsMcpServers value = new McpServerSpec()
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
        ChatCompletionCreateParamsMcpServers value = new(
            [new UnnamedSchemaWithArrayParent0("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMcpServers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMcpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerSpecSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMcpServers value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMcpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServersSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMcpServers value = new(
            [new UnnamedSchemaWithArrayParent0("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMcpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsMessageTest : TestBase
{
    [Fact]
    public void ChatCompletionDeveloperMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionDeveloperMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionSystemMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionSystemMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionUserMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionUserMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionAssistantMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionAssistantMessageParam()
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
        value.Validate();
    }

    [Fact]
    public void ChatCompletionToolMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionToolMessageParam()
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionFunctionMessageParamValidationWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionFunctionMessageParam()
        {
            Content = "content",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void ChatCompletionDeveloperMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionDeveloperMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionSystemMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionSystemMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionUserMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionUserMessageParam()
        {
            Content = "string",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionAssistantMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionAssistantMessageParam()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionToolMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionToolMessageParam()
        {
            Content = "string",
            ToolCallID = "tool_call_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChatCompletionFunctionMessageParamSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsMessage value = new ChatCompletionFunctionMessageParam()
        {
            Content = "content",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsMessage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsPromptModeTest : TestBase
{
    [Theory]
    [InlineData(ChatCompletionCreateParamsPromptMode.Reasoning)]
    public void Validation_Works(ChatCompletionCreateParamsPromptMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsPromptMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsPromptMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCompletionCreateParamsPromptMode.Reasoning)]
    public void SerializationRoundtrip_Works(ChatCompletionCreateParamsPromptMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsPromptMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsPromptMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsPromptMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsPromptMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsResponseFormatTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatText();
        value.Validate();
    }

    [Fact]
    public void JsonSchemaValidationWorks()
    {
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatJsonSchema(
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
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatJsonObject();
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatText();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonSchemaSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatJsonSchema(
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonObjectSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsResponseFormat value = new ResponseFormatJsonObject();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsResponseFormat>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsSafetySettingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionCreateParamsSafetySetting
        {
            Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            Threshold =
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
        };

        ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory> expectedCategory =
            ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified;
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold> expectedThreshold =
            ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified;

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedThreshold, model.Threshold);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionCreateParamsSafetySetting
        {
            Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            Threshold =
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsSafetySetting>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionCreateParamsSafetySetting
        {
            Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            Threshold =
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsSafetySetting>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory> expectedCategory =
            ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified;
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold> expectedThreshold =
            ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified;

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedThreshold, deserialized.Threshold);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionCreateParamsSafetySetting
        {
            Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            Threshold =
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionCreateParamsSafetySetting
        {
            Category = ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            Threshold =
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
        };

        ChatCompletionCreateParamsSafetySetting copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCompletionCreateParamsSafetySettingCategoryTest : TestBase
{
    [Theory]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDerogatory)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryToxicity)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryViolence)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexual)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryMedical)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerous)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHarassment)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHateSpeech)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexuallyExplicit)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerousContent)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryCivicIntegrity)]
    public void Validation_Works(ChatCompletionCreateParamsSafetySettingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDerogatory)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryToxicity)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryViolence)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexual)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryMedical)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerous)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHarassment)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHateSpeech)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexuallyExplicit)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerousContent)]
    [InlineData(ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryCivicIntegrity)]
    public void SerializationRoundtrip_Works(
        ChatCompletionCreateParamsSafetySettingCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsSafetySettingThresholdTest : TestBase
{
    [Theory]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockLowAndAbove)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockMediumAndAbove)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockOnlyHigh)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockNone)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.Off)]
    public void Validation_Works(ChatCompletionCreateParamsSafetySettingThreshold rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockLowAndAbove)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockMediumAndAbove)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockOnlyHigh)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.BlockNone)]
    [InlineData(ChatCompletionCreateParamsSafetySettingThreshold.Off)]
    public void SerializationRoundtrip_Works(
        ChatCompletionCreateParamsSafetySettingThreshold rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsSpeedTest : TestBase
{
    [Theory]
    [InlineData(ChatCompletionCreateParamsSpeed.Standard)]
    [InlineData(ChatCompletionCreateParamsSpeed.Fast)]
    public void Validation_Works(ChatCompletionCreateParamsSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCompletionCreateParamsSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChatCompletionCreateParamsSpeed.Standard)]
    [InlineData(ChatCompletionCreateParamsSpeed.Fast)]
    public void SerializationRoundtrip_Works(ChatCompletionCreateParamsSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChatCompletionCreateParamsSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChatCompletionCreateParamsSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChatCompletionCreateParamsSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsStopTest : TestBase
{
    [Fact]
    public void StringsValidationWorks()
    {
        ChatCompletionCreateParamsStop value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionCreateParamsStop value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsStop value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsStop>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsStop value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsStop>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsSystemInstructionTest : TestBase
{
    [Fact]
    public void JsonObjectInputValidationWorks()
    {
        ChatCompletionCreateParamsSystemInstruction value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionCreateParamsSystemInstruction value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonObjectInputSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsSystemInstruction value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsSystemInstruction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsSystemInstruction value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsSystemInstruction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsThinkingTest : TestBase
{
    [Fact]
    public void ConfigEnabledValidationWorks()
    {
        ChatCompletionCreateParamsThinking value = new ThinkingConfigEnabled(1024);
        value.Validate();
    }

    [Fact]
    public void ConfigDisabledValidationWorks()
    {
        ChatCompletionCreateParamsThinking value = new ThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        ChatCompletionCreateParamsThinking value = new ChatCompletionCreateParamsThinkingAdaptive();
        value.Validate();
    }

    [Fact]
    public void ConfigEnabledSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsThinking value = new ThinkingConfigEnabled(1024);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConfigDisabledSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsThinking value = new ThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsThinking value = new ChatCompletionCreateParamsThinkingAdaptive();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChatCompletionCreateParamsThinkingAdaptiveTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new ChatCompletionCreateParamsThinkingAdaptive();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
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
        var constant = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<DedalusInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new ChatCompletionCreateParamsThinkingAdaptive();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
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
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class ChatCompletionCreateParamsToolChoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ChatCompletionCreateParamsToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void AutoValidationWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceAny()
        {
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceAny()
        {
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        ChatCompletionCreateParamsToolChoice value = new ToolChoiceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionCreateParamsToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
