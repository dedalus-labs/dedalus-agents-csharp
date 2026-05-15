using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class DedalusModelChoiceTest : TestBase
{
    [Fact]
    public void ModelIDValidationWorks()
    {
        DedalusModelChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void DedalusModelValidationWorks()
    {
        DedalusModelChoice value = new DedalusModel()
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
    public void ModelIDSerializationRoundtripWorks()
    {
        DedalusModelChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DedalusModelChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusModelSerializationRoundtripWorks()
    {
        DedalusModelChoice value = new DedalusModel()
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
        var deserialized = JsonSerializer.Deserialize<DedalusModelChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
