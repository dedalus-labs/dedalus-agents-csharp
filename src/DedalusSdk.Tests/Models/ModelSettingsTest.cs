using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class ModelSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelSettings
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Dictionary<string, JsonElement> expectedAttributes = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonValueInput?> expectedAudio = new() { { "foo", "string" } };
        bool expectedDeferred = true;
        Dictionary<string, JsonElement> expectedExtraArgs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, string> expectedExtraHeaders = new() { { "foo", "string" } };
        Dictionary<string, JsonElement> expectedExtraQuery = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        double expectedFrequencyPenalty = 0;
        Dictionary<string, JsonValueInput?> expectedGenerationConfig = new()
        {
            { "foo", "string" },
        };
        bool expectedIncludeUsage = true;
        string expectedInputAudioFormat = "input_audio_format";
        Dictionary<string, JsonValueInput?> expectedInputAudioTranscription = new()
        {
            { "foo", "string" },
        };
        Dictionary<string, long> expectedLogitBias = new() { { "foo", 0 } };
        bool expectedLogprobs = true;
        long expectedMaxCompletionTokens = 0;
        long expectedMaxTokens = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<string> expectedModalities = ["string"];
        long expectedN = 0;
        string expectedOutputAudioFormat = "output_audio_format";
        bool expectedParallelToolCalls = true;
        Dictionary<string, JsonValueInput?> expectedPrediction = new() { { "foo", "string" } };
        double expectedPresencePenalty = 0;
        string expectedPromptCacheKey = "prompt_cache_key";
        Reasoning expectedReasoning = new()
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };
        string expectedReasoningEffort = "reasoning_effort";
        Dictionary<string, JsonValueInput?> expectedResponseFormat = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        List<Dictionary<string, JsonValueInput?>> expectedSafetySettings =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        Dictionary<string, JsonValueInput?> expectedSearchParameters = new()
        {
            { "foo", "string" },
        };
        long expectedSeed = 0;
        string expectedServiceTier = "service_tier";
        Stop expectedStop = "string";
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        JsonElement expectedStructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        Dictionary<string, JsonValueInput?> expectedSystemInstruction = new()
        {
            { "foo", "string" },
        };
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedThinking = new() { { "foo", "string" } };
        double expectedTimeout = 0;
        ToolChoice expectedToolChoice = UnionMember0.Auto;
        Dictionary<string, JsonValueInput?> expectedToolConfig = new() { { "foo", "string" } };
        long expectedTopK = 0;
        long expectedTopLogprobs = 0;
        double expectedTopP = 0;
        ApiEnum<string, Truncation> expectedTruncation = Truncation.Auto;
        Dictionary<string, JsonValueInput?> expectedTurnDetection = new() { { "foo", "string" } };
        string expectedUser = "user";
        string expectedVerbosity = "verbosity";
        string expectedVoice = "voice";
        Dictionary<string, JsonValueInput?> expectedWebSearchOptions = new()
        {
            { "foo", "string" },
        };

        Assert.NotNull(model.Attributes);
        Assert.Equal(expectedAttributes.Count, model.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(model.Attributes.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Attributes[item.Key]));
        }
        Assert.NotNull(model.Audio);
        Assert.Equal(expectedAudio.Count, model.Audio.Count);
        foreach (var item in expectedAudio)
        {
            Assert.True(model.Audio.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Audio[item.Key]);
        }
        Assert.Equal(expectedDeferred, model.Deferred);
        Assert.NotNull(model.ExtraArgs);
        Assert.Equal(expectedExtraArgs.Count, model.ExtraArgs.Count);
        foreach (var item in expectedExtraArgs)
        {
            Assert.True(model.ExtraArgs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ExtraArgs[item.Key]));
        }
        Assert.NotNull(model.ExtraHeaders);
        Assert.Equal(expectedExtraHeaders.Count, model.ExtraHeaders.Count);
        foreach (var item in expectedExtraHeaders)
        {
            Assert.True(model.ExtraHeaders.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ExtraHeaders[item.Key]);
        }
        Assert.NotNull(model.ExtraQuery);
        Assert.Equal(expectedExtraQuery.Count, model.ExtraQuery.Count);
        foreach (var item in expectedExtraQuery)
        {
            Assert.True(model.ExtraQuery.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ExtraQuery[item.Key]));
        }
        Assert.Equal(expectedFrequencyPenalty, model.FrequencyPenalty);
        Assert.NotNull(model.GenerationConfig);
        Assert.Equal(expectedGenerationConfig.Count, model.GenerationConfig.Count);
        foreach (var item in expectedGenerationConfig)
        {
            Assert.True(model.GenerationConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.GenerationConfig[item.Key]);
        }
        Assert.Equal(expectedIncludeUsage, model.IncludeUsage);
        Assert.Equal(expectedInputAudioFormat, model.InputAudioFormat);
        Assert.NotNull(model.InputAudioTranscription);
        Assert.Equal(expectedInputAudioTranscription.Count, model.InputAudioTranscription.Count);
        foreach (var item in expectedInputAudioTranscription)
        {
            Assert.True(model.InputAudioTranscription.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.InputAudioTranscription[item.Key]);
        }
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
        Assert.Equal(expectedN, model.N);
        Assert.Equal(expectedOutputAudioFormat, model.OutputAudioFormat);
        Assert.Equal(expectedParallelToolCalls, model.ParallelToolCalls);
        Assert.NotNull(model.Prediction);
        Assert.Equal(expectedPrediction.Count, model.Prediction.Count);
        foreach (var item in expectedPrediction)
        {
            Assert.True(model.Prediction.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Prediction[item.Key]);
        }
        Assert.Equal(expectedPresencePenalty, model.PresencePenalty);
        Assert.Equal(expectedPromptCacheKey, model.PromptCacheKey);
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.Equal(expectedReasoningEffort, model.ReasoningEffort);
        Assert.NotNull(model.ResponseFormat);
        Assert.Equal(expectedResponseFormat.Count, model.ResponseFormat.Count);
        foreach (var item in expectedResponseFormat)
        {
            Assert.True(model.ResponseFormat.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ResponseFormat[item.Key]);
        }
        Assert.Equal(expectedSafetyIdentifier, model.SafetyIdentifier);
        Assert.NotNull(model.SafetySettings);
        Assert.Equal(expectedSafetySettings.Count, model.SafetySettings.Count);
        for (int i = 0; i < expectedSafetySettings.Count; i++)
        {
            Assert.Equal(expectedSafetySettings[i].Count, model.SafetySettings[i].Count);
            foreach (var item in expectedSafetySettings[i])
            {
                Assert.True(model.SafetySettings[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, model.SafetySettings[i][item.Key]);
            }
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
        Assert.NotNull(model.StructuredOutput);
        Assert.True(JsonElement.DeepEquals(expectedStructuredOutput, model.StructuredOutput.Value));
        Assert.NotNull(model.SystemInstruction);
        Assert.Equal(expectedSystemInstruction.Count, model.SystemInstruction.Count);
        foreach (var item in expectedSystemInstruction)
        {
            Assert.True(model.SystemInstruction.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.SystemInstruction[item.Key]);
        }
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.NotNull(model.Thinking);
        Assert.Equal(expectedThinking.Count, model.Thinking.Count);
        foreach (var item in expectedThinking)
        {
            Assert.True(model.Thinking.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Thinking[item.Key]);
        }
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.NotNull(model.ToolConfig);
        Assert.Equal(expectedToolConfig.Count, model.ToolConfig.Count);
        foreach (var item in expectedToolConfig)
        {
            Assert.True(model.ToolConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ToolConfig[item.Key]);
        }
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopLogprobs, model.TopLogprobs);
        Assert.Equal(expectedTopP, model.TopP);
        Assert.Equal(expectedTruncation, model.Truncation);
        Assert.NotNull(model.TurnDetection);
        Assert.Equal(expectedTurnDetection.Count, model.TurnDetection.Count);
        foreach (var item in expectedTurnDetection)
        {
            Assert.True(model.TurnDetection.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TurnDetection[item.Key]);
        }
        Assert.Equal(expectedUser, model.User);
        Assert.Equal(expectedVerbosity, model.Verbosity);
        Assert.Equal(expectedVoice, model.Voice);
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
        var model = new ModelSettings
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelSettings
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedAttributes = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonValueInput?> expectedAudio = new() { { "foo", "string" } };
        bool expectedDeferred = true;
        Dictionary<string, JsonElement> expectedExtraArgs = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, string> expectedExtraHeaders = new() { { "foo", "string" } };
        Dictionary<string, JsonElement> expectedExtraQuery = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        double expectedFrequencyPenalty = 0;
        Dictionary<string, JsonValueInput?> expectedGenerationConfig = new()
        {
            { "foo", "string" },
        };
        bool expectedIncludeUsage = true;
        string expectedInputAudioFormat = "input_audio_format";
        Dictionary<string, JsonValueInput?> expectedInputAudioTranscription = new()
        {
            { "foo", "string" },
        };
        Dictionary<string, long> expectedLogitBias = new() { { "foo", 0 } };
        bool expectedLogprobs = true;
        long expectedMaxCompletionTokens = 0;
        long expectedMaxTokens = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<string> expectedModalities = ["string"];
        long expectedN = 0;
        string expectedOutputAudioFormat = "output_audio_format";
        bool expectedParallelToolCalls = true;
        Dictionary<string, JsonValueInput?> expectedPrediction = new() { { "foo", "string" } };
        double expectedPresencePenalty = 0;
        string expectedPromptCacheKey = "prompt_cache_key";
        Reasoning expectedReasoning = new()
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };
        string expectedReasoningEffort = "reasoning_effort";
        Dictionary<string, JsonValueInput?> expectedResponseFormat = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        List<Dictionary<string, JsonValueInput?>> expectedSafetySettings =
        [
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        ];
        Dictionary<string, JsonValueInput?> expectedSearchParameters = new()
        {
            { "foo", "string" },
        };
        long expectedSeed = 0;
        string expectedServiceTier = "service_tier";
        Stop expectedStop = "string";
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        JsonElement expectedStructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}");
        Dictionary<string, JsonValueInput?> expectedSystemInstruction = new()
        {
            { "foo", "string" },
        };
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedThinking = new() { { "foo", "string" } };
        double expectedTimeout = 0;
        ToolChoice expectedToolChoice = UnionMember0.Auto;
        Dictionary<string, JsonValueInput?> expectedToolConfig = new() { { "foo", "string" } };
        long expectedTopK = 0;
        long expectedTopLogprobs = 0;
        double expectedTopP = 0;
        ApiEnum<string, Truncation> expectedTruncation = Truncation.Auto;
        Dictionary<string, JsonValueInput?> expectedTurnDetection = new() { { "foo", "string" } };
        string expectedUser = "user";
        string expectedVerbosity = "verbosity";
        string expectedVoice = "voice";
        Dictionary<string, JsonValueInput?> expectedWebSearchOptions = new()
        {
            { "foo", "string" },
        };

        Assert.NotNull(deserialized.Attributes);
        Assert.Equal(expectedAttributes.Count, deserialized.Attributes.Count);
        foreach (var item in expectedAttributes)
        {
            Assert.True(deserialized.Attributes.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Attributes[item.Key]));
        }
        Assert.NotNull(deserialized.Audio);
        Assert.Equal(expectedAudio.Count, deserialized.Audio.Count);
        foreach (var item in expectedAudio)
        {
            Assert.True(deserialized.Audio.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Audio[item.Key]);
        }
        Assert.Equal(expectedDeferred, deserialized.Deferred);
        Assert.NotNull(deserialized.ExtraArgs);
        Assert.Equal(expectedExtraArgs.Count, deserialized.ExtraArgs.Count);
        foreach (var item in expectedExtraArgs)
        {
            Assert.True(deserialized.ExtraArgs.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ExtraArgs[item.Key]));
        }
        Assert.NotNull(deserialized.ExtraHeaders);
        Assert.Equal(expectedExtraHeaders.Count, deserialized.ExtraHeaders.Count);
        foreach (var item in expectedExtraHeaders)
        {
            Assert.True(deserialized.ExtraHeaders.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ExtraHeaders[item.Key]);
        }
        Assert.NotNull(deserialized.ExtraQuery);
        Assert.Equal(expectedExtraQuery.Count, deserialized.ExtraQuery.Count);
        foreach (var item in expectedExtraQuery)
        {
            Assert.True(deserialized.ExtraQuery.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ExtraQuery[item.Key]));
        }
        Assert.Equal(expectedFrequencyPenalty, deserialized.FrequencyPenalty);
        Assert.NotNull(deserialized.GenerationConfig);
        Assert.Equal(expectedGenerationConfig.Count, deserialized.GenerationConfig.Count);
        foreach (var item in expectedGenerationConfig)
        {
            Assert.True(deserialized.GenerationConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.GenerationConfig[item.Key]);
        }
        Assert.Equal(expectedIncludeUsage, deserialized.IncludeUsage);
        Assert.Equal(expectedInputAudioFormat, deserialized.InputAudioFormat);
        Assert.NotNull(deserialized.InputAudioTranscription);
        Assert.Equal(
            expectedInputAudioTranscription.Count,
            deserialized.InputAudioTranscription.Count
        );
        foreach (var item in expectedInputAudioTranscription)
        {
            Assert.True(deserialized.InputAudioTranscription.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.InputAudioTranscription[item.Key]);
        }
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
        Assert.Equal(expectedN, deserialized.N);
        Assert.Equal(expectedOutputAudioFormat, deserialized.OutputAudioFormat);
        Assert.Equal(expectedParallelToolCalls, deserialized.ParallelToolCalls);
        Assert.NotNull(deserialized.Prediction);
        Assert.Equal(expectedPrediction.Count, deserialized.Prediction.Count);
        foreach (var item in expectedPrediction)
        {
            Assert.True(deserialized.Prediction.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Prediction[item.Key]);
        }
        Assert.Equal(expectedPresencePenalty, deserialized.PresencePenalty);
        Assert.Equal(expectedPromptCacheKey, deserialized.PromptCacheKey);
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.Equal(expectedReasoningEffort, deserialized.ReasoningEffort);
        Assert.NotNull(deserialized.ResponseFormat);
        Assert.Equal(expectedResponseFormat.Count, deserialized.ResponseFormat.Count);
        foreach (var item in expectedResponseFormat)
        {
            Assert.True(deserialized.ResponseFormat.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ResponseFormat[item.Key]);
        }
        Assert.Equal(expectedSafetyIdentifier, deserialized.SafetyIdentifier);
        Assert.NotNull(deserialized.SafetySettings);
        Assert.Equal(expectedSafetySettings.Count, deserialized.SafetySettings.Count);
        for (int i = 0; i < expectedSafetySettings.Count; i++)
        {
            Assert.Equal(expectedSafetySettings[i].Count, deserialized.SafetySettings[i].Count);
            foreach (var item in expectedSafetySettings[i])
            {
                Assert.True(deserialized.SafetySettings[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, deserialized.SafetySettings[i][item.Key]);
            }
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
        Assert.NotNull(deserialized.StructuredOutput);
        Assert.True(
            JsonElement.DeepEquals(expectedStructuredOutput, deserialized.StructuredOutput.Value)
        );
        Assert.NotNull(deserialized.SystemInstruction);
        Assert.Equal(expectedSystemInstruction.Count, deserialized.SystemInstruction.Count);
        foreach (var item in expectedSystemInstruction)
        {
            Assert.True(deserialized.SystemInstruction.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.SystemInstruction[item.Key]);
        }
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.NotNull(deserialized.Thinking);
        Assert.Equal(expectedThinking.Count, deserialized.Thinking.Count);
        foreach (var item in expectedThinking)
        {
            Assert.True(deserialized.Thinking.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Thinking[item.Key]);
        }
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.NotNull(deserialized.ToolConfig);
        Assert.Equal(expectedToolConfig.Count, deserialized.ToolConfig.Count);
        foreach (var item in expectedToolConfig)
        {
            Assert.True(deserialized.ToolConfig.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ToolConfig[item.Key]);
        }
        Assert.Equal(expectedTopK, deserialized.TopK);
        Assert.Equal(expectedTopLogprobs, deserialized.TopLogprobs);
        Assert.Equal(expectedTopP, deserialized.TopP);
        Assert.Equal(expectedTruncation, deserialized.Truncation);
        Assert.NotNull(deserialized.TurnDetection);
        Assert.Equal(expectedTurnDetection.Count, deserialized.TurnDetection.Count);
        foreach (var item in expectedTurnDetection)
        {
            Assert.True(deserialized.TurnDetection.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TurnDetection[item.Key]);
        }
        Assert.Equal(expectedUser, deserialized.User);
        Assert.Equal(expectedVerbosity, deserialized.Verbosity);
        Assert.Equal(expectedVoice, deserialized.Voice);
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
        var model = new ModelSettings
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelSettings
        {
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.StructuredOutput);
        Assert.False(model.RawData.ContainsKey("structured_output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelSettings
        {
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ModelSettings
        {
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Attributes = null,
            StructuredOutput = null,
        };

        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.StructuredOutput);
        Assert.False(model.RawData.ContainsKey("structured_output"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelSettings
        {
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Attributes = null,
            StructuredOutput = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ModelSettings
        {
            Attributes = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Audio);
        Assert.False(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Deferred);
        Assert.False(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.ExtraArgs);
        Assert.False(model.RawData.ContainsKey("extra_args"));
        Assert.Null(model.ExtraHeaders);
        Assert.False(model.RawData.ContainsKey("extra_headers"));
        Assert.Null(model.ExtraQuery);
        Assert.False(model.RawData.ContainsKey("extra_query"));
        Assert.Null(model.FrequencyPenalty);
        Assert.False(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.IncludeUsage);
        Assert.False(model.RawData.ContainsKey("include_usage"));
        Assert.Null(model.InputAudioFormat);
        Assert.False(model.RawData.ContainsKey("input_audio_format"));
        Assert.Null(model.InputAudioTranscription);
        Assert.False(model.RawData.ContainsKey("input_audio_transcription"));
        Assert.Null(model.LogitBias);
        Assert.False(model.RawData.ContainsKey("logit_bias"));
        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.MaxCompletionTokens);
        Assert.False(model.RawData.ContainsKey("max_completion_tokens"));
        Assert.Null(model.MaxTokens);
        Assert.False(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Modalities);
        Assert.False(model.RawData.ContainsKey("modalities"));
        Assert.Null(model.N);
        Assert.False(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputAudioFormat);
        Assert.False(model.RawData.ContainsKey("output_audio_format"));
        Assert.Null(model.ParallelToolCalls);
        Assert.False(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.Prediction);
        Assert.False(model.RawData.ContainsKey("prediction"));
        Assert.Null(model.PresencePenalty);
        Assert.False(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PromptCacheKey);
        Assert.False(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.ReasoningEffort);
        Assert.False(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ResponseFormat);
        Assert.False(model.RawData.ContainsKey("response_format"));
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
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.ToolConfig);
        Assert.False(model.RawData.ContainsKey("tool_config"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopLogprobs);
        Assert.False(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.False(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.TurnDetection);
        Assert.False(model.RawData.ContainsKey("turn_detection"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
        Assert.Null(model.Verbosity);
        Assert.False(model.RawData.ContainsKey("verbosity"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
        Assert.Null(model.WebSearchOptions);
        Assert.False(model.RawData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ModelSettings
        {
            Attributes = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ModelSettings
        {
            Attributes = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),

            Audio = null,
            Deferred = null,
            ExtraArgs = null,
            ExtraHeaders = null,
            ExtraQuery = null,
            FrequencyPenalty = null,
            GenerationConfig = null,
            IncludeUsage = null,
            InputAudioFormat = null,
            InputAudioTranscription = null,
            LogitBias = null,
            Logprobs = null,
            MaxCompletionTokens = null,
            MaxTokens = null,
            Metadata = null,
            Modalities = null,
            N = null,
            OutputAudioFormat = null,
            ParallelToolCalls = null,
            Prediction = null,
            PresencePenalty = null,
            PromptCacheKey = null,
            Reasoning = null,
            ReasoningEffort = null,
            ResponseFormat = null,
            SafetyIdentifier = null,
            SafetySettings = null,
            SearchParameters = null,
            Seed = null,
            ServiceTier = null,
            Stop = null,
            Store = null,
            Stream = null,
            StreamOptions = null,
            SystemInstruction = null,
            Temperature = null,
            Thinking = null,
            Timeout = null,
            ToolChoice = null,
            ToolConfig = null,
            TopK = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            TurnDetection = null,
            User = null,
            Verbosity = null,
            Voice = null,
            WebSearchOptions = null,
        };

        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
        Assert.Null(model.Deferred);
        Assert.True(model.RawData.ContainsKey("deferred"));
        Assert.Null(model.ExtraArgs);
        Assert.True(model.RawData.ContainsKey("extra_args"));
        Assert.Null(model.ExtraHeaders);
        Assert.True(model.RawData.ContainsKey("extra_headers"));
        Assert.Null(model.ExtraQuery);
        Assert.True(model.RawData.ContainsKey("extra_query"));
        Assert.Null(model.FrequencyPenalty);
        Assert.True(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.GenerationConfig);
        Assert.True(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.IncludeUsage);
        Assert.True(model.RawData.ContainsKey("include_usage"));
        Assert.Null(model.InputAudioFormat);
        Assert.True(model.RawData.ContainsKey("input_audio_format"));
        Assert.Null(model.InputAudioTranscription);
        Assert.True(model.RawData.ContainsKey("input_audio_transcription"));
        Assert.Null(model.LogitBias);
        Assert.True(model.RawData.ContainsKey("logit_bias"));
        Assert.Null(model.Logprobs);
        Assert.True(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.MaxCompletionTokens);
        Assert.True(model.RawData.ContainsKey("max_completion_tokens"));
        Assert.Null(model.MaxTokens);
        Assert.True(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Modalities);
        Assert.True(model.RawData.ContainsKey("modalities"));
        Assert.Null(model.N);
        Assert.True(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputAudioFormat);
        Assert.True(model.RawData.ContainsKey("output_audio_format"));
        Assert.Null(model.ParallelToolCalls);
        Assert.True(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.Prediction);
        Assert.True(model.RawData.ContainsKey("prediction"));
        Assert.Null(model.PresencePenalty);
        Assert.True(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PromptCacheKey);
        Assert.True(model.RawData.ContainsKey("prompt_cache_key"));
        Assert.Null(model.Reasoning);
        Assert.True(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.ReasoningEffort);
        Assert.True(model.RawData.ContainsKey("reasoning_effort"));
        Assert.Null(model.ResponseFormat);
        Assert.True(model.RawData.ContainsKey("response_format"));
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
        Assert.Null(model.Timeout);
        Assert.True(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.ToolChoice);
        Assert.True(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.ToolConfig);
        Assert.True(model.RawData.ContainsKey("tool_config"));
        Assert.Null(model.TopK);
        Assert.True(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopLogprobs);
        Assert.True(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.True(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.True(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.TurnDetection);
        Assert.True(model.RawData.ContainsKey("turn_detection"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
        Assert.Null(model.Verbosity);
        Assert.True(model.RawData.ContainsKey("verbosity"));
        Assert.Null(model.Voice);
        Assert.True(model.RawData.ContainsKey("voice"));
        Assert.Null(model.WebSearchOptions);
        Assert.True(model.RawData.ContainsKey("web_search_options"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ModelSettings
        {
            Attributes = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),

            Audio = null,
            Deferred = null,
            ExtraArgs = null,
            ExtraHeaders = null,
            ExtraQuery = null,
            FrequencyPenalty = null,
            GenerationConfig = null,
            IncludeUsage = null,
            InputAudioFormat = null,
            InputAudioTranscription = null,
            LogitBias = null,
            Logprobs = null,
            MaxCompletionTokens = null,
            MaxTokens = null,
            Metadata = null,
            Modalities = null,
            N = null,
            OutputAudioFormat = null,
            ParallelToolCalls = null,
            Prediction = null,
            PresencePenalty = null,
            PromptCacheKey = null,
            Reasoning = null,
            ReasoningEffort = null,
            ResponseFormat = null,
            SafetyIdentifier = null,
            SafetySettings = null,
            SearchParameters = null,
            Seed = null,
            ServiceTier = null,
            Stop = null,
            Store = null,
            Stream = null,
            StreamOptions = null,
            SystemInstruction = null,
            Temperature = null,
            Thinking = null,
            Timeout = null,
            ToolChoice = null,
            ToolConfig = null,
            TopK = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            TurnDetection = null,
            User = null,
            Verbosity = null,
            Voice = null,
            WebSearchOptions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelSettings
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
            GenerationConfig = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            SafetySettings = [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }],
            SearchParameters = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Seed = 0,
            ServiceTier = "service_tier",
            Stop = "string",
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
            SystemInstruction = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
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
            WebSearchOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
        };

        ModelSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StopTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Stop value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Stop value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Stop value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stop>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Stop value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stop>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TruncationTest : TestBase
{
    [Theory]
    [InlineData(Truncation.Auto)]
    [InlineData(Truncation.Disabled)]
    public void Validation_Works(Truncation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Truncation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Truncation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Truncation.Auto)]
    [InlineData(Truncation.Disabled)]
    public void SerializationRoundtrip_Works(Truncation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Truncation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Truncation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Truncation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Truncation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
