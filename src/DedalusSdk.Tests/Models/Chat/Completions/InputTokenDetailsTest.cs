using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class InputTokenDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputTokenDetails { AudioTokens = 0, TextTokens = 0 };

        long expectedAudioTokens = 0;
        long expectedTextTokens = 0;

        Assert.Equal(expectedAudioTokens, model.AudioTokens);
        Assert.Equal(expectedTextTokens, model.TextTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputTokenDetails { AudioTokens = 0, TextTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputTokenDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputTokenDetails { AudioTokens = 0, TextTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputTokenDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAudioTokens = 0;
        long expectedTextTokens = 0;

        Assert.Equal(expectedAudioTokens, deserialized.AudioTokens);
        Assert.Equal(expectedTextTokens, deserialized.TextTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputTokenDetails { AudioTokens = 0, TextTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InputTokenDetails { };

        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.TextTokens);
        Assert.False(model.RawData.ContainsKey("text_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InputTokenDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InputTokenDetails
        {
            // Null should be interpreted as omitted for these properties
            AudioTokens = null,
            TextTokens = null,
        };

        Assert.Null(model.AudioTokens);
        Assert.False(model.RawData.ContainsKey("audio_tokens"));
        Assert.Null(model.TextTokens);
        Assert.False(model.RawData.ContainsKey("text_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InputTokenDetails
        {
            // Null should be interpreted as omitted for these properties
            AudioTokens = null,
            TextTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InputTokenDetails { AudioTokens = 0, TextTokens = 0 };

        InputTokenDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
