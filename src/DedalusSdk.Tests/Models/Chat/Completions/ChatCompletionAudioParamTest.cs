using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionAudioParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionAudioParam
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };

        ApiEnum<string, Format> expectedFormat = Format.Wav;
        Voice expectedVoice = UnionMember1.Alloy;

        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionAudioParam
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionAudioParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionAudioParam
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionAudioParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Format> expectedFormat = Format.Wav;
        Voice expectedVoice = UnionMember1.Alloy;

        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionAudioParam
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionAudioParam
        {
            Format = Format.Wav,
            Voice = UnionMember1.Alloy,
        };

        ChatCompletionAudioParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Format.Wav)]
    [InlineData(Format.Aac)]
    [InlineData(Format.Mp3)]
    [InlineData(Format.Flac)]
    [InlineData(Format.Opus)]
    [InlineData(Format.Pcm16)]
    public void Validation_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Format.Wav)]
    [InlineData(Format.Aac)]
    [InlineData(Format.Mp3)]
    [InlineData(Format.Flac)]
    [InlineData(Format.Opus)]
    [InlineData(Format.Pcm16)]
    public void SerializationRoundtrip_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VoiceTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Voice value = "string";
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        Voice value = UnionMember1.Alloy;
        value.Validate();
    }

    [Fact]
    public void IdsOrCustomValidationWorks()
    {
        Voice value = new VoiceIdsOrCustomVoice("id");
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Voice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Voice>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        Voice value = UnionMember1.Alloy;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Voice>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void IdsOrCustomSerializationRoundtripWorks()
    {
        Voice value = new VoiceIdsOrCustomVoice("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Voice>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Theory]
    [InlineData(UnionMember1.Alloy)]
    [InlineData(UnionMember1.Ash)]
    [InlineData(UnionMember1.Ballad)]
    [InlineData(UnionMember1.Coral)]
    [InlineData(UnionMember1.Echo)]
    [InlineData(UnionMember1.Sage)]
    [InlineData(UnionMember1.Shimmer)]
    [InlineData(UnionMember1.Verse)]
    [InlineData(UnionMember1.Marin)]
    [InlineData(UnionMember1.Cedar)]
    public void Validation_Works(UnionMember1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1.Alloy)]
    [InlineData(UnionMember1.Ash)]
    [InlineData(UnionMember1.Ballad)]
    [InlineData(UnionMember1.Coral)]
    [InlineData(UnionMember1.Echo)]
    [InlineData(UnionMember1.Sage)]
    [InlineData(UnionMember1.Shimmer)]
    [InlineData(UnionMember1.Verse)]
    [InlineData(UnionMember1.Marin)]
    [InlineData(UnionMember1.Cedar)]
    public void SerializationRoundtrip_Works(UnionMember1 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
