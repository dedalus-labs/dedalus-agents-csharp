using System;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Tests.Models.Images;

public class ImageGenerateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageGenerateParams
        {
            Prompt = "A white siamese cat",
            Background = Background.Transparent,
            Model = "openai/dall-e-3",
            Moderation = Moderation.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = OutputFormat.Png,
            PartialImages = 0,
            Quality = Quality.Standard,
            ResponseFormat = ResponseFormat.Url,
            Size = Size.V1024x1024,
            Stream = true,
            Style = Style.Vivid,
            User = "user",
        };

        string expectedPrompt = "A white siamese cat";
        ApiEnum<string, Background> expectedBackground = Background.Transparent;
        string expectedModel = "openai/dall-e-3";
        ApiEnum<string, Moderation> expectedModeration = Moderation.Auto;
        long expectedN = 1;
        long expectedOutputCompression = 85;
        ApiEnum<string, OutputFormat> expectedOutputFormat = OutputFormat.Png;
        long expectedPartialImages = 0;
        ApiEnum<string, Quality> expectedQuality = Quality.Standard;
        ApiEnum<string, ResponseFormat> expectedResponseFormat = ResponseFormat.Url;
        ApiEnum<string, Size> expectedSize = Size.V1024x1024;
        bool expectedStream = true;
        ApiEnum<string, Style> expectedStyle = Style.Vivid;
        string expectedUser = "user";

        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedBackground, parameters.Background);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedModeration, parameters.Moderation);
        Assert.Equal(expectedN, parameters.N);
        Assert.Equal(expectedOutputCompression, parameters.OutputCompression);
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
        Assert.Equal(expectedPartialImages, parameters.PartialImages);
        Assert.Equal(expectedQuality, parameters.Quality);
        Assert.Equal(expectedResponseFormat, parameters.ResponseFormat);
        Assert.Equal(expectedSize, parameters.Size);
        Assert.Equal(expectedStream, parameters.Stream);
        Assert.Equal(expectedStyle, parameters.Style);
        Assert.Equal(expectedUser, parameters.User);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ImageGenerateParams { Prompt = "A white siamese cat" };

        Assert.Null(parameters.Background);
        Assert.False(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Moderation);
        Assert.False(parameters.RawBodyData.ContainsKey("moderation"));
        Assert.Null(parameters.N);
        Assert.False(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.OutputCompression);
        Assert.False(parameters.RawBodyData.ContainsKey("output_compression"));
        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
        Assert.Null(parameters.PartialImages);
        Assert.False(parameters.RawBodyData.ContainsKey("partial_images"));
        Assert.Null(parameters.Quality);
        Assert.False(parameters.RawBodyData.ContainsKey("quality"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Size);
        Assert.False(parameters.RawBodyData.ContainsKey("size"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Style);
        Assert.False(parameters.RawBodyData.ContainsKey("style"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ImageGenerateParams
        {
            Prompt = "A white siamese cat",

            Background = null,
            Model = null,
            Moderation = null,
            N = null,
            OutputCompression = null,
            OutputFormat = null,
            PartialImages = null,
            Quality = null,
            ResponseFormat = null,
            Size = null,
            Stream = null,
            Style = null,
            User = null,
        };

        Assert.Null(parameters.Background);
        Assert.True(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.Moderation);
        Assert.True(parameters.RawBodyData.ContainsKey("moderation"));
        Assert.Null(parameters.N);
        Assert.True(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.OutputCompression);
        Assert.True(parameters.RawBodyData.ContainsKey("output_compression"));
        Assert.Null(parameters.OutputFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("output_format"));
        Assert.Null(parameters.PartialImages);
        Assert.True(parameters.RawBodyData.ContainsKey("partial_images"));
        Assert.Null(parameters.Quality);
        Assert.True(parameters.RawBodyData.ContainsKey("quality"));
        Assert.Null(parameters.ResponseFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Size);
        Assert.True(parameters.RawBodyData.ContainsKey("size"));
        Assert.Null(parameters.Stream);
        Assert.True(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Style);
        Assert.True(parameters.RawBodyData.ContainsKey("style"));
        Assert.Null(parameters.User);
        Assert.True(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void Url_Works()
    {
        ImageGenerateParams parameters = new() { Prompt = "A white siamese cat" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/images/generations"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageGenerateParams
        {
            Prompt = "A white siamese cat",
            Background = Background.Transparent,
            Model = "openai/dall-e-3",
            Moderation = Moderation.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = OutputFormat.Png,
            PartialImages = 0,
            Quality = Quality.Standard,
            ResponseFormat = ResponseFormat.Url,
            Size = Size.V1024x1024,
            Stream = true,
            Style = Style.Vivid,
            User = "user",
        };

        ImageGenerateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BackgroundTest : TestBase
{
    [Theory]
    [InlineData(Background.Transparent)]
    [InlineData(Background.Opaque)]
    [InlineData(Background.Auto)]
    public void Validation_Works(Background rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Background> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Background>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Background.Transparent)]
    [InlineData(Background.Opaque)]
    [InlineData(Background.Auto)]
    public void SerializationRoundtrip_Works(Background rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Background> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Background>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Background>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Background>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ModerationTest : TestBase
{
    [Theory]
    [InlineData(Moderation.Low)]
    [InlineData(Moderation.Auto)]
    public void Validation_Works(Moderation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Moderation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Moderation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Moderation.Low)]
    [InlineData(Moderation.Auto)]
    public void SerializationRoundtrip_Works(Moderation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Moderation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Moderation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Moderation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Moderation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputFormatTest : TestBase
{
    [Theory]
    [InlineData(OutputFormat.Png)]
    [InlineData(OutputFormat.Jpeg)]
    [InlineData(OutputFormat.Webp)]
    public void Validation_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputFormat.Png)]
    [InlineData(OutputFormat.Jpeg)]
    [InlineData(OutputFormat.Webp)]
    public void SerializationRoundtrip_Works(OutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class QualityTest : TestBase
{
    [Theory]
    [InlineData(Quality.Auto)]
    [InlineData(Quality.High)]
    [InlineData(Quality.Medium)]
    [InlineData(Quality.Low)]
    [InlineData(Quality.HD)]
    [InlineData(Quality.Standard)]
    public void Validation_Works(Quality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Quality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Quality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Quality.Auto)]
    [InlineData(Quality.High)]
    [InlineData(Quality.Medium)]
    [InlineData(Quality.Low)]
    [InlineData(Quality.HD)]
    [InlineData(Quality.Standard)]
    public void SerializationRoundtrip_Works(Quality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Quality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Quality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Quality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Quality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResponseFormatTest : TestBase
{
    [Theory]
    [InlineData(ResponseFormat.Url)]
    [InlineData(ResponseFormat.B64Json)]
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
    [InlineData(ResponseFormat.Url)]
    [InlineData(ResponseFormat.B64Json)]
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

public class SizeTest : TestBase
{
    [Theory]
    [InlineData(Size.V256x256)]
    [InlineData(Size.V512x512)]
    [InlineData(Size.V1024x1024)]
    [InlineData(Size.V1536x1024)]
    [InlineData(Size.V1024x1536)]
    [InlineData(Size.V1792x1024)]
    [InlineData(Size.V1024x1792)]
    [InlineData(Size.Auto)]
    public void Validation_Works(Size rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Size> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Size.V256x256)]
    [InlineData(Size.V512x512)]
    [InlineData(Size.V1024x1024)]
    [InlineData(Size.V1536x1024)]
    [InlineData(Size.V1024x1536)]
    [InlineData(Size.V1792x1024)]
    [InlineData(Size.V1024x1792)]
    [InlineData(Size.Auto)]
    public void SerializationRoundtrip_Works(Size rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Size> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Size>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StyleTest : TestBase
{
    [Theory]
    [InlineData(Style.Vivid)]
    [InlineData(Style.Natural)]
    public void Validation_Works(Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Style> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Style.Vivid)]
    [InlineData(Style.Natural)]
    public void SerializationRoundtrip_Works(Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Style> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
