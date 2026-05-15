using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class CompletionUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompletionUsage
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

        long expectedCompletionTokens = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;
        CompletionTokensDetails expectedCompletionTokensDetails = new()
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };
        PromptTokensDetails expectedPromptTokensDetails = new()
        {
            AudioTokens = 0,
            CachedTokens = 0,
        };

        Assert.Equal(expectedCompletionTokens, model.CompletionTokens);
        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
        Assert.Equal(expectedCompletionTokensDetails, model.CompletionTokensDetails);
        Assert.Equal(expectedPromptTokensDetails, model.PromptTokensDetails);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompletionUsage
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompletionUsage
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCompletionTokens = 0;
        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;
        CompletionTokensDetails expectedCompletionTokensDetails = new()
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };
        PromptTokensDetails expectedPromptTokensDetails = new()
        {
            AudioTokens = 0,
            CachedTokens = 0,
        };

        Assert.Equal(expectedCompletionTokens, deserialized.CompletionTokens);
        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
        Assert.Equal(expectedCompletionTokensDetails, deserialized.CompletionTokensDetails);
        Assert.Equal(expectedPromptTokensDetails, deserialized.PromptTokensDetails);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompletionUsage
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompletionUsage
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        Assert.Null(model.CompletionTokensDetails);
        Assert.False(model.RawData.ContainsKey("completion_tokens_details"));
        Assert.Null(model.PromptTokensDetails);
        Assert.False(model.RawData.ContainsKey("prompt_tokens_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompletionUsage
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompletionUsage
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            CompletionTokensDetails = null,
            PromptTokensDetails = null,
        };

        Assert.Null(model.CompletionTokensDetails);
        Assert.False(model.RawData.ContainsKey("completion_tokens_details"));
        Assert.Null(model.PromptTokensDetails);
        Assert.False(model.RawData.ContainsKey("prompt_tokens_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompletionUsage
        {
            CompletionTokens = 0,
            PromptTokens = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            CompletionTokensDetails = null,
            PromptTokensDetails = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CompletionUsage
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

        CompletionUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
