using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class CompletionTokensDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompletionTokensDetails
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };

        long expectedAcceptedPredictionTokens = 0;
        long expectedAudioTokens = 0;
        long expectedReasoningTokens = 0;
        long expectedRejectedPredictionTokens = 0;

        Assert.Equal(expectedAcceptedPredictionTokens, model.AcceptedPredictionTokens);
        Assert.Equal(expectedAudioTokens, model.AudioTokens);
        Assert.Equal(expectedReasoningTokens, model.ReasoningTokens);
        Assert.Equal(expectedRejectedPredictionTokens, model.RejectedPredictionTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompletionTokensDetails
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionTokensDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompletionTokensDetails
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompletionTokensDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAcceptedPredictionTokens = 0;
        long expectedAudioTokens = 0;
        long expectedReasoningTokens = 0;
        long expectedRejectedPredictionTokens = 0;

        Assert.Equal(expectedAcceptedPredictionTokens, deserialized.AcceptedPredictionTokens);
        Assert.Equal(expectedAudioTokens, deserialized.AudioTokens);
        Assert.Equal(expectedReasoningTokens, deserialized.ReasoningTokens);
        Assert.Equal(expectedRejectedPredictionTokens, deserialized.RejectedPredictionTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompletionTokensDetails
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompletionTokensDetails { };

        Assert.Null(model.AcceptedPredictionTokens);
        Assert.False(model.RawData.ContainsKey("accepted_prediction_tokens"));
        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoning_tokens"));
        Assert.Null(model.RejectedPredictionTokens);
        Assert.False(model.RawData.ContainsKey("rejected_prediction_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompletionTokensDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompletionTokensDetails
        {
            // Null should be interpreted as omitted for these properties
            AcceptedPredictionTokens = null,
            AudioTokens = null,
            ReasoningTokens = null,
            RejectedPredictionTokens = null,
        };

        Assert.Null(model.AcceptedPredictionTokens);
        Assert.False(model.RawData.ContainsKey("accepted_prediction_tokens"));
        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.ReasoningTokens);
        Assert.False(model.RawData.ContainsKey("reasoning_tokens"));
        Assert.Null(model.RejectedPredictionTokens);
        Assert.False(model.RawData.ContainsKey("rejected_prediction_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompletionTokensDetails
        {
            // Null should be interpreted as omitted for these properties
            AcceptedPredictionTokens = null,
            AudioTokens = null,
            ReasoningTokens = null,
            RejectedPredictionTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CompletionTokensDetails
        {
            AcceptedPredictionTokens = 0,
            AudioTokens = 0,
            ReasoningTokens = 0,
            RejectedPredictionTokens = 0,
        };

        CompletionTokensDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
