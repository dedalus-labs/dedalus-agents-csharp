using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class DedalusModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DedalusModel
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

        string expectedModel = "model";
        ModelSettings expectedSettings = new()
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

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSettings, model.Settings);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DedalusModel
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DedalusModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DedalusModel
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DedalusModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModel = "model";
        ModelSettings expectedSettings = new()
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

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSettings, deserialized.Settings);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DedalusModel
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DedalusModel { Model = "model" };

        Assert.Null(model.Settings);
        Assert.False(model.RawData.ContainsKey("settings"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DedalusModel { Model = "model" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DedalusModel
        {
            Model = "model",

            Settings = null,
        };

        Assert.Null(model.Settings);
        Assert.True(model.RawData.ContainsKey("settings"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DedalusModel
        {
            Model = "model",

            Settings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DedalusModel
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

        DedalusModel copied = new(model);

        Assert.Equal(model, copied);
    }
}
