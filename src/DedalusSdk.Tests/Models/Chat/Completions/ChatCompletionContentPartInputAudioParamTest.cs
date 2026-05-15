using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionContentPartInputAudioParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartInputAudioParam
        {
            InputAudio = new() { Data = "data", Format = InputAudioFormat.Wav },
        };

        InputAudio expectedInputAudio = new() { Data = "data", Format = InputAudioFormat.Wav };
        JsonElement expectedType = JsonSerializer.SerializeToElement("input_audio");

        Assert.Equal(expectedInputAudio, model.InputAudio);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartInputAudioParam
        {
            InputAudio = new() { Data = "data", Format = InputAudioFormat.Wav },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartInputAudioParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionContentPartInputAudioParam
        {
            InputAudio = new() { Data = "data", Format = InputAudioFormat.Wav },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartInputAudioParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        InputAudio expectedInputAudio = new() { Data = "data", Format = InputAudioFormat.Wav };
        JsonElement expectedType = JsonSerializer.SerializeToElement("input_audio");

        Assert.Equal(expectedInputAudio, deserialized.InputAudio);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionContentPartInputAudioParam
        {
            InputAudio = new() { Data = "data", Format = InputAudioFormat.Wav },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionContentPartInputAudioParam
        {
            InputAudio = new() { Data = "data", Format = InputAudioFormat.Wav },
        };

        ChatCompletionContentPartInputAudioParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputAudioTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputAudio { Data = "data", Format = InputAudioFormat.Wav };

        string expectedData = "data";
        ApiEnum<string, InputAudioFormat> expectedFormat = InputAudioFormat.Wav;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedFormat, model.Format);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputAudio { Data = "data", Format = InputAudioFormat.Wav };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputAudio>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputAudio { Data = "data", Format = InputAudioFormat.Wav };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputAudio>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "data";
        ApiEnum<string, InputAudioFormat> expectedFormat = InputAudioFormat.Wav;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedFormat, deserialized.Format);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputAudio { Data = "data", Format = InputAudioFormat.Wav };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InputAudio { Data = "data", Format = InputAudioFormat.Wav };

        InputAudio copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputAudioFormatTest : TestBase
{
    [Theory]
    [InlineData(InputAudioFormat.Wav)]
    [InlineData(InputAudioFormat.Mp3)]
    public void Validation_Works(InputAudioFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputAudioFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputAudioFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputAudioFormat.Wav)]
    [InlineData(InputAudioFormat.Mp3)]
    public void SerializationRoundtrip_Works(InputAudioFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputAudioFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputAudioFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputAudioFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InputAudioFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
