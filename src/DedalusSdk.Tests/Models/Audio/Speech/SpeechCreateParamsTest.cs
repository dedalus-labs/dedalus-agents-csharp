using System;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;
using DedalusSdk.Models.Audio.Speech;

namespace DedalusSdk.Tests.Models.Audio.Speech;

public class SpeechCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpeechCreateParams
        {
            Input = "input",
            Model = Model.Tts1,
            Voice = UnionMember1.Alloy,
            Instructions = "instructions",
            ResponseFormat = ResponseFormat.Mp3,
            Speed = 0.25,
            StreamFormat = StreamFormat.Sse,
        };

        string expectedInput = "input";
        ApiEnum<string, Model> expectedModel = Model.Tts1;
        Voice expectedVoice = UnionMember1.Alloy;
        string expectedInstructions = "instructions";
        ApiEnum<string, ResponseFormat> expectedResponseFormat = ResponseFormat.Mp3;
        double expectedSpeed = 0.25;
        ApiEnum<string, StreamFormat> expectedStreamFormat = StreamFormat.Sse;

        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedVoice, parameters.Voice);
        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedResponseFormat, parameters.ResponseFormat);
        Assert.Equal(expectedSpeed, parameters.Speed);
        Assert.Equal(expectedStreamFormat, parameters.StreamFormat);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SpeechCreateParams
        {
            Input = "input",
            Model = Model.Tts1,
            Voice = UnionMember1.Alloy,
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawBodyData.ContainsKey("speed"));
        Assert.Null(parameters.StreamFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("stream_format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SpeechCreateParams
        {
            Input = "input",
            Model = Model.Tts1,
            Voice = UnionMember1.Alloy,

            // Null should be interpreted as omitted for these properties
            Instructions = null,
            ResponseFormat = null,
            Speed = null,
            StreamFormat = null,
        };

        Assert.Null(parameters.Instructions);
        Assert.False(parameters.RawBodyData.ContainsKey("instructions"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawBodyData.ContainsKey("speed"));
        Assert.Null(parameters.StreamFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("stream_format"));
    }

    [Fact]
    public void Url_Works()
    {
        SpeechCreateParams parameters = new()
        {
            Input = "input",
            Model = Model.Tts1,
            Voice = UnionMember1.Alloy,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/audio/speech"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SpeechCreateParams
        {
            Input = "input",
            Model = Model.Tts1,
            Voice = UnionMember1.Alloy,
            Instructions = "instructions",
            ResponseFormat = ResponseFormat.Mp3,
            Speed = 0.25,
            StreamFormat = StreamFormat.Sse,
        };

        SpeechCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.Tts1)]
    [InlineData(Model.Tts1HD)]
    [InlineData(Model.Gpt4oMiniTts)]
    [InlineData(Model.Gpt4oMiniTts2025_12_15)]
    public void Validation_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Model.Tts1)]
    [InlineData(Model.Tts1HD)]
    [InlineData(Model.Gpt4oMiniTts)]
    [InlineData(Model.Gpt4oMiniTts2025_12_15)]
    public void SerializationRoundtrip_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
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

public class ResponseFormatTest : TestBase
{
    [Theory]
    [InlineData(ResponseFormat.Mp3)]
    [InlineData(ResponseFormat.Opus)]
    [InlineData(ResponseFormat.Aac)]
    [InlineData(ResponseFormat.Flac)]
    [InlineData(ResponseFormat.Wav)]
    [InlineData(ResponseFormat.Pcm)]
    public void Validation_Works(ResponseFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResponseFormat.Mp3)]
    [InlineData(ResponseFormat.Opus)]
    [InlineData(ResponseFormat.Aac)]
    [InlineData(ResponseFormat.Flac)]
    [InlineData(ResponseFormat.Wav)]
    [InlineData(ResponseFormat.Pcm)]
    public void SerializationRoundtrip_Works(ResponseFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StreamFormatTest : TestBase
{
    [Theory]
    [InlineData(StreamFormat.Sse)]
    [InlineData(StreamFormat.Audio)]
    public void Validation_Works(StreamFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StreamFormat.Sse)]
    [InlineData(StreamFormat.Audio)]
    public void SerializationRoundtrip_Works(StreamFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StreamFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StreamFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StreamFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
