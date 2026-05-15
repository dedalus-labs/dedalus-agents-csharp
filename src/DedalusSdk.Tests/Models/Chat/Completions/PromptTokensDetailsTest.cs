using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class PromptTokensDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromptTokensDetails { AudioTokens = 0, CachedTokens = 0 };

        long expectedAudioTokens = 0;
        long expectedCachedTokens = 0;

        Assert.Equal(expectedAudioTokens, model.AudioTokens);
        Assert.Equal(expectedCachedTokens, model.CachedTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromptTokensDetails { AudioTokens = 0, CachedTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromptTokensDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromptTokensDetails { AudioTokens = 0, CachedTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromptTokensDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAudioTokens = 0;
        long expectedCachedTokens = 0;

        Assert.Equal(expectedAudioTokens, deserialized.AudioTokens);
        Assert.Equal(expectedCachedTokens, deserialized.CachedTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PromptTokensDetails { AudioTokens = 0, CachedTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PromptTokensDetails { };

        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.CachedTokens);
        Assert.False(model.RawData.ContainsKey("cached_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PromptTokensDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PromptTokensDetails
        {
            // Null should be interpreted as omitted for these properties
            AudioTokens = null,
            CachedTokens = null,
        };

        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.CachedTokens);
        Assert.False(model.RawData.ContainsKey("cached_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PromptTokensDetails
        {
            // Null should be interpreted as omitted for these properties
            AudioTokens = null,
            CachedTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PromptTokensDetails { AudioTokens = 0, CachedTokens = 0 };

        PromptTokensDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
