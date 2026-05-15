using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using Responses = DedalusSdk.Models.Responses;

namespace DedalusSdk.Tests.Models.Responses;

public class ResponseResponseCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        bool expectedBackground = true;
        Responses::ResponseResponseCreateParamsConversation expectedConversation = "string";
        Responses::ResponseResponseCreateParamsCredentials expectedCredentials = new Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
        };
        double expectedFrequencyPenalty = 0;
        List<string> expectedInclude = ["message.output_text.logprobs"];
        Responses::ResponseResponseCreateParamsInput expectedInput =
            "What is the capital of France?";
        Responses::ResponseResponseCreateParamsInstructions expectedInstructions =
            "You are a helpful assistant.";
        long expectedMaxOutputTokens = 1000;
        long expectedMaxToolCalls = 10;
        Responses::ResponseResponseCreateParamsMcpServers expectedMcpServers =
            "dedalus-labs/example-server";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Responses::ResponseResponseCreateParamsModel expectedModel = "openai/gpt-4o";
        bool expectedParallelToolCalls = true;
        double expectedPresencePenalty = 0;
        string expectedPreviousResponseID = "previous_response_id";
        Responses::ResponseResponseCreateParamsPrompt expectedPrompt = new()
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };
        string expectedPromptCacheKey = "prompt_cache_key";
        Dictionary<string, JsonValueInput?> expectedReasoning = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier> expectedServiceTier =
            Responses::ResponseResponseCreateParamsServiceTier.Auto;
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedText = new() { { "foo", "string" } };
        Responses::ResponseResponseCreateParamsToolChoice expectedToolChoice = "auto";
        List<Dictionary<string, JsonValueInput?>> expectedTools =
        [
            new Dictionary<string, JsonValueInput?>()
            {
                {
                    "function",
                    new(
                        new Dictionary<string, JsonValueInput?>()
                        {
                            { "description", null },
                            { "name", null },
                            { "parameters", null },
                        }
                    )
                },
                { "type", "function" },
            },
        ];
        long expectedTopLogprobs = 5;
        double expectedTopP = 0.1;
        ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation> expectedTruncation =
            Responses::ResponseResponseCreateParamsTruncation.Auto;
        string expectedUser = "user";

        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedConversation, model.Conversation);
        Assert.Equal(expectedCredentials, model.Credentials);
        Assert.Equal(expectedFrequencyPenalty, model.FrequencyPenalty);
        Assert.NotNull(model.Include);
        Assert.Equal(expectedInclude.Count, model.Include.Count);
        for (int i = 0; i < expectedInclude.Count; i++)
        {
            Assert.Equal(expectedInclude[i], model.Include[i]);
        }
        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedMaxOutputTokens, model.MaxOutputTokens);
        Assert.Equal(expectedMaxToolCalls, model.MaxToolCalls);
        Assert.Equal(expectedMcpServers, model.McpServers);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedParallelToolCalls, model.ParallelToolCalls);
        Assert.Equal(expectedPresencePenalty, model.PresencePenalty);
        Assert.Equal(expectedPreviousResponseID, model.PreviousResponseID);
        Assert.Equal(expectedPrompt, model.Prompt);
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
        Assert.Equal(expectedStream, model.Stream);
        Assert.NotNull(model.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, model.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(model.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.StreamOptions[item.Key]);
        }
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
        Assert.Equal(expectedTopLogprobs, model.TopLogprobs);
        Assert.Equal(expectedTopP, model.TopP);
        Assert.Equal(expectedTruncation, model.Truncation);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedBackground = true;
        Responses::ResponseResponseCreateParamsConversation expectedConversation = "string";
        Responses::ResponseResponseCreateParamsCredentials expectedCredentials = new Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
        };
        double expectedFrequencyPenalty = 0;
        List<string> expectedInclude = ["message.output_text.logprobs"];
        Responses::ResponseResponseCreateParamsInput expectedInput =
            "What is the capital of France?";
        Responses::ResponseResponseCreateParamsInstructions expectedInstructions =
            "You are a helpful assistant.";
        long expectedMaxOutputTokens = 1000;
        long expectedMaxToolCalls = 10;
        Responses::ResponseResponseCreateParamsMcpServers expectedMcpServers =
            "dedalus-labs/example-server";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Responses::ResponseResponseCreateParamsModel expectedModel = "openai/gpt-4o";
        bool expectedParallelToolCalls = true;
        double expectedPresencePenalty = 0;
        string expectedPreviousResponseID = "previous_response_id";
        Responses::ResponseResponseCreateParamsPrompt expectedPrompt = new()
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };
        string expectedPromptCacheKey = "prompt_cache_key";
        Dictionary<string, JsonValueInput?> expectedReasoning = new() { { "foo", "string" } };
        string expectedSafetyIdentifier = "safety_identifier";
        ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier> expectedServiceTier =
            Responses::ResponseResponseCreateParamsServiceTier.Auto;
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, JsonValueInput?> expectedStreamOptions = new() { { "foo", "string" } };
        double expectedTemperature = 0;
        Dictionary<string, JsonValueInput?> expectedText = new() { { "foo", "string" } };
        Responses::ResponseResponseCreateParamsToolChoice expectedToolChoice = "auto";
        List<Dictionary<string, JsonValueInput?>> expectedTools =
        [
            new Dictionary<string, JsonValueInput?>()
            {
                {
                    "function",
                    new(
                        new Dictionary<string, JsonValueInput?>()
                        {
                            { "description", null },
                            { "name", null },
                            { "parameters", null },
                        }
                    )
                },
                { "type", "function" },
            },
        ];
        long expectedTopLogprobs = 5;
        double expectedTopP = 0.1;
        ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation> expectedTruncation =
            Responses::ResponseResponseCreateParamsTruncation.Auto;
        string expectedUser = "user";

        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedConversation, deserialized.Conversation);
        Assert.Equal(expectedCredentials, deserialized.Credentials);
        Assert.Equal(expectedFrequencyPenalty, deserialized.FrequencyPenalty);
        Assert.NotNull(deserialized.Include);
        Assert.Equal(expectedInclude.Count, deserialized.Include.Count);
        for (int i = 0; i < expectedInclude.Count; i++)
        {
            Assert.Equal(expectedInclude[i], deserialized.Include[i]);
        }
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedMaxOutputTokens, deserialized.MaxOutputTokens);
        Assert.Equal(expectedMaxToolCalls, deserialized.MaxToolCalls);
        Assert.Equal(expectedMcpServers, deserialized.McpServers);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedParallelToolCalls, deserialized.ParallelToolCalls);
        Assert.Equal(expectedPresencePenalty, deserialized.PresencePenalty);
        Assert.Equal(expectedPreviousResponseID, deserialized.PreviousResponseID);
        Assert.Equal(expectedPrompt, deserialized.Prompt);
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
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.NotNull(deserialized.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, deserialized.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(deserialized.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.StreamOptions[item.Key]);
        }
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
        Assert.Equal(expectedTopLogprobs, deserialized.TopLogprobs);
        Assert.Equal(expectedTopP, deserialized.TopP);
        Assert.Equal(expectedTruncation, deserialized.Truncation);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",

            // Null should be interpreted as omitted for these properties
            Stream = null,
        };

        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",

            // Null should be interpreted as omitted for these properties
            Stream = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Responses::ResponseResponseCreateParams { Stream = true };

        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Conversation);
        Assert.False(model.RawData.ContainsKey("conversation"));
        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.FrequencyPenalty);
        Assert.False(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.Include);
        Assert.False(model.RawData.ContainsKey("include"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MaxOutputTokens);
        Assert.False(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.MaxToolCalls);
        Assert.False(model.RawData.ContainsKey("max_tool_calls"));
        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.ParallelToolCalls);
        Assert.False(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.PresencePenalty);
        Assert.False(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PreviousResponseID);
        Assert.False(model.RawData.ContainsKey("previous_response_id"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
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
        Assert.Null(model.StreamOptions);
        Assert.False(model.RawData.ContainsKey("stream_options"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopLogprobs);
        Assert.False(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.False(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParams { Stream = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Stream = true,

            Background = null,
            Conversation = null,
            Credentials = null,
            FrequencyPenalty = null,
            Include = null,
            Input = null,
            Instructions = null,
            MaxOutputTokens = null,
            MaxToolCalls = null,
            McpServers = null,
            Metadata = null,
            Model = null,
            ParallelToolCalls = null,
            PresencePenalty = null,
            PreviousResponseID = null,
            Prompt = null,
            PromptCacheKey = null,
            Reasoning = null,
            SafetyIdentifier = null,
            ServiceTier = null,
            Store = null,
            StreamOptions = null,
            Temperature = null,
            Text = null,
            ToolChoice = null,
            Tools = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            User = null,
        };

        Assert.Null(model.Background);
        Assert.True(model.RawData.ContainsKey("background"));
        Assert.Null(model.Conversation);
        Assert.True(model.RawData.ContainsKey("conversation"));
        Assert.Null(model.Credentials);
        Assert.True(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.FrequencyPenalty);
        Assert.True(model.RawData.ContainsKey("frequency_penalty"));
        Assert.Null(model.Include);
        Assert.True(model.RawData.ContainsKey("include"));
        Assert.Null(model.Input);
        Assert.True(model.RawData.ContainsKey("input"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.MaxOutputTokens);
        Assert.True(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.MaxToolCalls);
        Assert.True(model.RawData.ContainsKey("max_tool_calls"));
        Assert.Null(model.McpServers);
        Assert.True(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.ParallelToolCalls);
        Assert.True(model.RawData.ContainsKey("parallel_tool_calls"));
        Assert.Null(model.PresencePenalty);
        Assert.True(model.RawData.ContainsKey("presence_penalty"));
        Assert.Null(model.PreviousResponseID);
        Assert.True(model.RawData.ContainsKey("previous_response_id"));
        Assert.Null(model.Prompt);
        Assert.True(model.RawData.ContainsKey("prompt"));
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
        Assert.Null(model.StreamOptions);
        Assert.True(model.RawData.ContainsKey("stream_options"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.ToolChoice);
        Assert.True(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.True(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopLogprobs);
        Assert.True(model.RawData.ContainsKey("top_logprobs"));
        Assert.Null(model.TopP);
        Assert.True(model.RawData.ContainsKey("top_p"));
        Assert.Null(model.Truncation);
        Assert.True(model.RawData.ContainsKey("truncation"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Stream = true,

            Background = null,
            Conversation = null,
            Credentials = null,
            FrequencyPenalty = null,
            Include = null,
            Input = null,
            Instructions = null,
            MaxOutputTokens = null,
            MaxToolCalls = null,
            McpServers = null,
            Metadata = null,
            Model = null,
            ParallelToolCalls = null,
            PresencePenalty = null,
            PreviousResponseID = null,
            Prompt = null,
            PromptCacheKey = null,
            Reasoning = null,
            SafetyIdentifier = null,
            ServiceTier = null,
            Store = null,
            StreamOptions = null,
            Temperature = null,
            Text = null,
            ToolChoice = null,
            Tools = null,
            TopLogprobs = null,
            TopP = null,
            Truncation = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Responses::ResponseResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, CredentialValue>() { { "api_key", "sk-..." } },
            },
            FrequencyPenalty = 0,
            Include = ["message.output_text.logprobs"],
            Input = "What is the capital of France?",
            Instructions = "You are a helpful assistant.",
            MaxOutputTokens = 1000,
            MaxToolCalls = 10,
            McpServers = "dedalus-labs/example-server",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Model = "openai/gpt-4o",
            ParallelToolCalls = true,
            PresencePenalty = 0,
            PreviousResponseID = "previous_response_id",
            Prompt = new()
            {
                ID = "id",
                Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = Responses::ResponseResponseCreateParamsServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Temperature = 0,
            Text = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, JsonValueInput?>()
                            {
                                { "description", null },
                                { "name", null },
                                { "parameters", null },
                            }
                        )
                    },
                    { "type", "function" },
                },
            ],
            TopLogprobs = 5,
            TopP = 0.1,
            Truncation = Responses::ResponseResponseCreateParamsTruncation.Auto,
            User = "user",
        };

        Responses::ResponseResponseCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResponseResponseCreateParamsConversationTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Responses::ResponseResponseCreateParamsConversation value = "string";
        value.Validate();
    }

    [Fact]
    public void ResponseConversationParamValidationWorks()
    {
        Responses::ResponseResponseCreateParamsConversation value =
            new Responses::ResponseResponseCreateParamsConversationResponseConversationParam("id");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsConversation value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsConversation>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResponseConversationParamSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsConversation value =
            new Responses::ResponseResponseCreateParamsConversationResponseConversationParam("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsConversation>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsConversationResponseConversationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsConversationResponseConversationParam
        {
            ID = "id",
        };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsConversationResponseConversationParam
        {
            ID = "id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsConversationResponseConversationParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsConversationResponseConversationParam
        {
            ID = "id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsConversationResponseConversationParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsConversationResponseConversationParam
        {
            ID = "id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsConversationResponseConversationParam
        {
            ID = "id",
        };

        Responses::ResponseResponseCreateParamsConversationResponseConversationParam copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class ResponseResponseCreateParamsCredentialsTest : TestBase
{
    [Fact]
    public void CredentialValidationWorks()
    {
        Responses::ResponseResponseCreateParamsCredentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void McpValidationWorks()
    {
        Responses::ResponseResponseCreateParamsCredentials value = new(
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
        Responses::ResponseResponseCreateParamsCredentials value = new Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsCredentials>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsCredentials value = new(
            [
                new Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsCredentials>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsInputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Responses::ResponseResponseCreateParamsInput value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        Responses::ResponseResponseCreateParamsInput value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsInput value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsInput value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsInstructionsTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Responses::ResponseResponseCreateParamsInstructions value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        Responses::ResponseResponseCreateParamsInstructions value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsInstructions value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsInstructions>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsInstructions value = new(
            [new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsInstructions>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsMcpServersTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Responses::ResponseResponseCreateParamsMcpServers value = "string";
        value.Validate();
    }

    [Fact]
    public void ServerSpecValidationWorks()
    {
        Responses::ResponseResponseCreateParamsMcpServers value = new McpServerSpec()
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
        Responses::ResponseResponseCreateParamsMcpServers value = new(
            [new UnnamedSchemaWithArrayParent0("string")]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsMcpServers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsMcpServers>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerSpecSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsMcpServers value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsMcpServers>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServersSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsMcpServers value = new(
            [new UnnamedSchemaWithArrayParent0("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsMcpServers>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsModelTest : TestBase
{
    [Fact]
    public void IDValidationWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = "string";
        value.Validate();
    }

    [Fact]
    public void DedalusValidationWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = new DedalusModel()
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
    public void ModelsValidationWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = new(
            [new DedalusModelChoice("string")]
        );
        value.Validate();
    }

    [Fact]
    public void IDSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = new DedalusModel()
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
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ModelsSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsModel value = new(
            [new DedalusModelChoice("string")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsPromptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string expectedID = "id";
        Dictionary<string, JsonValueInput?> expectedVariables = new() { { "foo", "string" } };
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(model.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Variables[item.Key]);
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsPrompt>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsPrompt>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonValueInput?> expectedVariables = new() { { "foo", "string" } };
        string expectedVersion = "version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        foreach (var item in expectedVariables)
        {
            Assert.True(deserialized.Variables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Variables[item.Key]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt { ID = "id" };

        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",

            Variables = null,
            Version = null,
        };

        Assert.Null(model.Variables);
        Assert.True(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",

            Variables = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Responses::ResponseResponseCreateParamsPrompt
        {
            ID = "id",
            Variables = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        Responses::ResponseResponseCreateParamsPrompt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResponseResponseCreateParamsServiceTierTest : TestBase
{
    [Theory]
    [InlineData(Responses::ResponseResponseCreateParamsServiceTier.Auto)]
    [InlineData(Responses::ResponseResponseCreateParamsServiceTier.Default)]
    public void Validation_Works(Responses::ResponseResponseCreateParamsServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Responses::ResponseResponseCreateParamsServiceTier.Auto)]
    [InlineData(Responses::ResponseResponseCreateParamsServiceTier.Default)]
    public void SerializationRoundtrip_Works(
        Responses::ResponseResponseCreateParamsServiceTier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsToolChoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Responses::ResponseResponseCreateParamsToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonObjectInputValidationWorks()
    {
        Responses::ResponseResponseCreateParamsToolChoice value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsToolChoice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonObjectInputSerializationRoundtripWorks()
    {
        Responses::ResponseResponseCreateParamsToolChoice value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Responses::ResponseResponseCreateParamsToolChoice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseResponseCreateParamsTruncationTest : TestBase
{
    [Theory]
    [InlineData(Responses::ResponseResponseCreateParamsTruncation.Auto)]
    [InlineData(Responses::ResponseResponseCreateParamsTruncation.Disabled)]
    public void Validation_Works(Responses::ResponseResponseCreateParamsTruncation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Responses::ResponseResponseCreateParamsTruncation.Auto)]
    [InlineData(Responses::ResponseResponseCreateParamsTruncation.Disabled)]
    public void SerializationRoundtrip_Works(
        Responses::ResponseResponseCreateParamsTruncation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Responses::ResponseResponseCreateParamsTruncation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
