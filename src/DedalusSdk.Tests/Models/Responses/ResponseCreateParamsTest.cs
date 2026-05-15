using System;
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Responses;
using Models = DedalusSdk.Models;

namespace DedalusSdk.Tests.Models.Responses;

public class ResponseCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Models::Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, Models::CredentialValue>()
                {
                    { "api_key", "sk-..." },
                },
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
                Variables = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = ServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
            {
                { "include_usage", true },
            },
            Temperature = 0,
            Text = new Dictionary<string, Models::JsonValueInput?>() { { "type", "text" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, Models::JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, Models::JsonValueInput?>()
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
            Truncation = Truncation.Auto,
            User = "user",
        };

        bool expectedBackground = true;
        Conversation expectedConversation = "string";
        Credentials expectedCredentials = new Models::Credential()
        {
            ConnectionName = "external-service",
            Values = new Dictionary<string, Models::CredentialValue>() { { "api_key", "sk-..." } },
        };
        double expectedFrequencyPenalty = 0;
        List<string> expectedInclude = ["message.output_text.logprobs"];
        Input expectedInput = "What is the capital of France?";
        Instructions expectedInstructions = "You are a helpful assistant.";
        long expectedMaxOutputTokens = 1000;
        long expectedMaxToolCalls = 10;
        McpServers expectedMcpServers = "dedalus-labs/example-server";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Model expectedModel = "openai/gpt-4o";
        bool expectedParallelToolCalls = true;
        double expectedPresencePenalty = 0;
        string expectedPreviousResponseID = "previous_response_id";
        Prompt expectedPrompt = new()
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };
        string expectedPromptCacheKey = "prompt_cache_key";
        Dictionary<string, Models::JsonValueInput?> expectedReasoning = new()
        {
            { "foo", "string" },
        };
        string expectedSafetyIdentifier = "safety_identifier";
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        bool expectedStore = true;
        bool expectedStream = true;
        Dictionary<string, Models::JsonValueInput?> expectedStreamOptions = new()
        {
            { "include_usage", true },
        };
        double expectedTemperature = 0;
        Dictionary<string, Models::JsonValueInput?> expectedText = new() { { "type", "text" } };
        ToolChoice expectedToolChoice = "auto";
        List<Dictionary<string, Models::JsonValueInput?>> expectedTools =
        [
            new Dictionary<string, Models::JsonValueInput?>()
            {
                {
                    "function",
                    new(
                        new Dictionary<string, Models::JsonValueInput?>()
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
        ApiEnum<string, Truncation> expectedTruncation = Truncation.Auto;
        string expectedUser = "user";

        Assert.Equal(expectedBackground, parameters.Background);
        Assert.Equal(expectedConversation, parameters.Conversation);
        Assert.Equal(expectedCredentials, parameters.Credentials);
        Assert.Equal(expectedFrequencyPenalty, parameters.FrequencyPenalty);
        Assert.NotNull(parameters.Include);
        Assert.Equal(expectedInclude.Count, parameters.Include.Count);
        for (int i = 0; i < expectedInclude.Count; i++)
        {
            Assert.Equal(expectedInclude[i], parameters.Include[i]);
        }
        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedMaxOutputTokens, parameters.MaxOutputTokens);
        Assert.Equal(expectedMaxToolCalls, parameters.MaxToolCalls);
        Assert.Equal(expectedMcpServers, parameters.McpServers);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedParallelToolCalls, parameters.ParallelToolCalls);
        Assert.Equal(expectedPresencePenalty, parameters.PresencePenalty);
        Assert.Equal(expectedPreviousResponseID, parameters.PreviousResponseID);
        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedPromptCacheKey, parameters.PromptCacheKey);
        Assert.NotNull(parameters.Reasoning);
        Assert.Equal(expectedReasoning.Count, parameters.Reasoning.Count);
        foreach (var item in expectedReasoning)
        {
            Assert.True(parameters.Reasoning.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Reasoning[item.Key]);
        }
        Assert.Equal(expectedSafetyIdentifier, parameters.SafetyIdentifier);
        Assert.Equal(expectedServiceTier, parameters.ServiceTier);
        Assert.Equal(expectedStore, parameters.Store);
        Assert.Equal(expectedStream, parameters.Stream);
        Assert.NotNull(parameters.StreamOptions);
        Assert.Equal(expectedStreamOptions.Count, parameters.StreamOptions.Count);
        foreach (var item in expectedStreamOptions)
        {
            Assert.True(parameters.StreamOptions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.StreamOptions[item.Key]);
        }
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.NotNull(parameters.Text);
        Assert.Equal(expectedText.Count, parameters.Text.Count);
        foreach (var item in expectedText)
        {
            Assert.True(parameters.Text.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Text[item.Key]);
        }
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i].Count, parameters.Tools[i].Count);
            foreach (var item in expectedTools[i])
            {
                Assert.True(parameters.Tools[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, parameters.Tools[i][item.Key]);
            }
        }
        Assert.Equal(expectedTopLogprobs, parameters.TopLogprobs);
        Assert.Equal(expectedTopP, parameters.TopP);
        Assert.Equal(expectedTruncation, parameters.Truncation);
        Assert.Equal(expectedUser, parameters.User);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Models::Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, Models::CredentialValue>()
                {
                    { "api_key", "sk-..." },
                },
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
                Variables = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = ServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
            {
                { "include_usage", true },
            },
            Temperature = 0,
            Text = new Dictionary<string, Models::JsonValueInput?>() { { "type", "text" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, Models::JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, Models::JsonValueInput?>()
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
            Truncation = Truncation.Auto,
            User = "user",
        };

        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Models::Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, Models::CredentialValue>()
                {
                    { "api_key", "sk-..." },
                },
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
                Variables = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = ServiceTier.Auto,
            Store = true,
            StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
            {
                { "include_usage", true },
            },
            Temperature = 0,
            Text = new Dictionary<string, Models::JsonValueInput?>() { { "type", "text" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, Models::JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, Models::JsonValueInput?>()
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
            Truncation = Truncation.Auto,
            User = "user",

            // Null should be interpreted as omitted for these properties
            Stream = null,
        };

        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ResponseCreateParams { Stream = true };

        Assert.Null(parameters.Background);
        Assert.False(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.Conversation);
        Assert.False(parameters.RawBodyData.ContainsKey("conversation"));
        Assert.Null(parameters.Credentials);
        Assert.False(parameters.RawBodyData.ContainsKey("credentials"));
        Assert.Null(parameters.FrequencyPenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.Include);
        Assert.False(parameters.RawBodyData.ContainsKey("include"));
        Assert.Null(parameters.Input);
        Assert.False(parameters.RawBodyData.ContainsKey("input"));
        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.MaxOutputTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("max_output_tokens"));
        Assert.Null(parameters.MaxToolCalls);
        Assert.False(parameters.RawBodyData.ContainsKey("max_tool_calls"));
        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ParallelToolCalls);
        Assert.False(parameters.RawBodyData.ContainsKey("parallel_tool_calls"));
        Assert.Null(parameters.PresencePenalty);
        Assert.False(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.PreviousResponseID);
        Assert.False(parameters.RawBodyData.ContainsKey("previous_response_id"));
        Assert.Null(parameters.Prompt);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt"));
        Assert.Null(parameters.PromptCacheKey);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt_cache_key"));
        Assert.Null(parameters.Reasoning);
        Assert.False(parameters.RawBodyData.ContainsKey("reasoning"));
        Assert.Null(parameters.SafetyIdentifier);
        Assert.False(parameters.RawBodyData.ContainsKey("safety_identifier"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Store);
        Assert.False(parameters.RawBodyData.ContainsKey("store"));
        Assert.Null(parameters.StreamOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("stream_options"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopLogprobs);
        Assert.False(parameters.RawBodyData.ContainsKey("top_logprobs"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.Truncation);
        Assert.False(parameters.RawBodyData.ContainsKey("truncation"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ResponseCreateParams
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

        Assert.Null(parameters.Background);
        Assert.True(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.Conversation);
        Assert.True(parameters.RawBodyData.ContainsKey("conversation"));
        Assert.Null(parameters.Credentials);
        Assert.True(parameters.RawBodyData.ContainsKey("credentials"));
        Assert.Null(parameters.FrequencyPenalty);
        Assert.True(parameters.RawBodyData.ContainsKey("frequency_penalty"));
        Assert.Null(parameters.Include);
        Assert.True(parameters.RawBodyData.ContainsKey("include"));
        Assert.Null(parameters.Input);
        Assert.True(parameters.RawBodyData.ContainsKey("input"));
        Assert.Null(parameters.Instructions);
        Assert.True(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.MaxOutputTokens);
        Assert.True(parameters.RawBodyData.ContainsKey("max_output_tokens"));
        Assert.Null(parameters.MaxToolCalls);
        Assert.True(parameters.RawBodyData.ContainsKey("max_tool_calls"));
        Assert.Null(parameters.McpServers);
        Assert.True(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ParallelToolCalls);
        Assert.True(parameters.RawBodyData.ContainsKey("parallel_tool_calls"));
        Assert.Null(parameters.PresencePenalty);
        Assert.True(parameters.RawBodyData.ContainsKey("presence_penalty"));
        Assert.Null(parameters.PreviousResponseID);
        Assert.True(parameters.RawBodyData.ContainsKey("previous_response_id"));
        Assert.Null(parameters.Prompt);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt"));
        Assert.Null(parameters.PromptCacheKey);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt_cache_key"));
        Assert.Null(parameters.Reasoning);
        Assert.True(parameters.RawBodyData.ContainsKey("reasoning"));
        Assert.Null(parameters.SafetyIdentifier);
        Assert.True(parameters.RawBodyData.ContainsKey("safety_identifier"));
        Assert.Null(parameters.ServiceTier);
        Assert.True(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.Store);
        Assert.True(parameters.RawBodyData.ContainsKey("store"));
        Assert.Null(parameters.StreamOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("stream_options"));
        Assert.Null(parameters.Temperature);
        Assert.True(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Text);
        Assert.True(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.ToolChoice);
        Assert.True(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.True(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopLogprobs);
        Assert.True(parameters.RawBodyData.ContainsKey("top_logprobs"));
        Assert.Null(parameters.TopP);
        Assert.True(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.Truncation);
        Assert.True(parameters.RawBodyData.ContainsKey("truncation"));
        Assert.Null(parameters.User);
        Assert.True(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void Url_Works()
    {
        ResponseCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/responses"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ResponseCreateParams
        {
            Background = true,
            Conversation = "string",
            Credentials = new Models::Credential()
            {
                ConnectionName = "external-service",
                Values = new Dictionary<string, Models::CredentialValue>()
                {
                    { "api_key", "sk-..." },
                },
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
                Variables = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Version = "version",
            },
            PromptCacheKey = "prompt_cache_key",
            Reasoning = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            SafetyIdentifier = "safety_identifier",
            ServiceTier = ServiceTier.Auto,
            Store = true,
            Stream = true,
            StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
            {
                { "include_usage", true },
            },
            Temperature = 0,
            Text = new Dictionary<string, Models::JsonValueInput?>() { { "type", "text" } },
            ToolChoice = "auto",
            Tools =
            [
                new Dictionary<string, Models::JsonValueInput?>()
                {
                    {
                        "function",
                        new(
                            new Dictionary<string, Models::JsonValueInput?>()
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
            Truncation = Truncation.Auto,
            User = "user",
        };

        ResponseCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConversationTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Conversation value = "string";
        value.Validate();
    }

    [Fact]
    public void ResponseConversationParamValidationWorks()
    {
        Conversation value = new ResponseConversationParam("id");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Conversation value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Conversation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResponseConversationParamSerializationRoundtripWorks()
    {
        Conversation value = new ResponseConversationParam("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Conversation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseConversationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResponseConversationParam { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResponseConversationParam { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseConversationParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResponseConversationParam { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseConversationParam>(
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
        var model = new ResponseConversationParam { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResponseConversationParam { ID = "id" };

        ResponseConversationParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CredentialsTest : TestBase
{
    [Fact]
    public void CredentialValidationWorks()
    {
        Credentials value = new Models::Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, Models::CredentialValue>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void McpValidationWorks()
    {
        Credentials value = new(
            [
                new Models::Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, Models::CredentialValue>()
                    {
                        { "foo", "string" },
                    },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void CredentialSerializationRoundtripWorks()
    {
        Credentials value = new Models::Credential()
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, Models::CredentialValue>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpSerializationRoundtripWorks()
    {
        Credentials value = new(
            [
                new Models::Credential()
                {
                    ConnectionName = "connection_name",
                    Values = new Dictionary<string, Models::CredentialValue>()
                    {
                        { "foo", "string" },
                    },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Input value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        Input value = new(
            [new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Input value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        Input value = new(
            [new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InstructionsTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Instructions value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        Instructions value = new(
            [new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Instructions value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instructions>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        Instructions value = new(
            [new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instructions>(
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
        McpServers value = "string";
        value.Validate();
    }

    [Fact]
    public void ServerSpecValidationWorks()
    {
        McpServers value = new Models::McpServerSpec()
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
        McpServers value = new([new Models::UnnamedSchemaWithArrayParent0("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        McpServers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerSpecSerializationRoundtripWorks()
    {
        McpServers value = new Models::McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServersSerializationRoundtripWorks()
    {
        McpServers value = new([new Models::UnnamedSchemaWithArrayParent0("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void IDValidationWorks()
    {
        Model value = "string";
        value.Validate();
    }

    [Fact]
    public void DedalusValidationWorks()
    {
        Model value = new Models::DedalusModel()
        {
            Model = "model",
            Settings = new()
            {
                Attributes = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Audio = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
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
                GenerationConfig = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                IncludeUsage = true,
                InputAudioFormat = "input_audio_format",
                InputAudioTranscription = new Dictionary<string, Models::JsonValueInput?>()
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
                Prediction = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                PresencePenalty = 0,
                PromptCacheKey = "prompt_cache_key",
                Reasoning = new()
                {
                    Effort = Models::Effort.None,
                    GenerateSummary = Models::GenerateSummary.Auto,
                    Summary = Models::Summary.Auto,
                },
                ReasoningEffort = "reasoning_effort",
                ResponseFormat = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                SafetyIdentifier = "safety_identifier",
                SafetySettings =
                [
                    new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
                ],
                SearchParameters = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Seed = 0,
                ServiceTier = "service_tier",
                Stop = "string",
                Store = true,
                Stream = true,
                StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                SystemInstruction = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Temperature = 0,
                Thinking = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Timeout = 0,
                ToolChoice = Models::UnionMember0.Auto,
                ToolConfig = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                TopK = 0,
                TopLogprobs = 0,
                TopP = 0,
                Truncation = Models::Truncation.Auto,
                TurnDetection = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                User = "user",
                Verbosity = "verbosity",
                Voice = "voice",
                WebSearchOptions = new Dictionary<string, Models::JsonValueInput?>()
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
        Model value = new([new Models::DedalusModelChoice("string")]);
        value.Validate();
    }

    [Fact]
    public void IDSerializationRoundtripWorks()
    {
        Model value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DedalusSerializationRoundtripWorks()
    {
        Model value = new Models::DedalusModel()
        {
            Model = "model",
            Settings = new()
            {
                Attributes = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Audio = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
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
                GenerationConfig = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                IncludeUsage = true,
                InputAudioFormat = "input_audio_format",
                InputAudioTranscription = new Dictionary<string, Models::JsonValueInput?>()
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
                Prediction = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                PresencePenalty = 0,
                PromptCacheKey = "prompt_cache_key",
                Reasoning = new()
                {
                    Effort = Models::Effort.None,
                    GenerateSummary = Models::GenerateSummary.Auto,
                    Summary = Models::Summary.Auto,
                },
                ReasoningEffort = "reasoning_effort",
                ResponseFormat = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                SafetyIdentifier = "safety_identifier",
                SafetySettings =
                [
                    new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
                ],
                SearchParameters = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Seed = 0,
                ServiceTier = "service_tier",
                Stop = "string",
                Store = true,
                Stream = true,
                StreamOptions = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                StructuredOutput = JsonSerializer.Deserialize<JsonElement>("{}"),
                SystemInstruction = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Temperature = 0,
                Thinking = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                Timeout = 0,
                ToolChoice = Models::UnionMember0.Auto,
                ToolConfig = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                TopK = 0,
                TopLogprobs = 0,
                TopP = 0,
                Truncation = Models::Truncation.Auto,
                TurnDetection = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
                User = "user",
                Verbosity = "verbosity",
                Voice = "voice",
                WebSearchOptions = new Dictionary<string, Models::JsonValueInput?>()
                {
                    { "foo", "string" },
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ModelsSerializationRoundtripWorks()
    {
        Model value = new([new Models::DedalusModelChoice("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string expectedID = "id";
        Dictionary<string, Models::JsonValueInput?> expectedVariables = new()
        {
            { "foo", "string" },
        };
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
        var model = new Prompt
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Prompt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Prompt
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Prompt>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, Models::JsonValueInput?> expectedVariables = new()
        {
            { "foo", "string" },
        };
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
        var model = new Prompt
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Prompt { ID = "id" };

        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Prompt { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Prompt
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
        var model = new Prompt
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
        var model = new Prompt
        {
            ID = "id",
            Variables = new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } },
            Version = "version",
        };

        Prompt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.Default)]
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

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonObjectInputValidationWorks()
    {
        ToolChoice value = new(
            new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonObjectInputSerializationRoundtripWorks()
    {
        ToolChoice value = new(
            new Dictionary<string, Models::JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

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
