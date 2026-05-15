using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Tests.Models.Images;

public class CreateImageRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateImageRequest
        {
            Prompt = "A white siamese cat",
            Background = CreateImageRequestBackground.Transparent,
            Model = "openai/dall-e-3",
            Moderation = CreateImageRequestModeration.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = CreateImageRequestOutputFormat.Png,
            PartialImages = 0,
            Quality = CreateImageRequestQuality.Standard,
            ResponseFormat = CreateImageRequestResponseFormat.Url,
            Size = CreateImageRequestSize.V1024x1024,
            Stream = true,
            Style = CreateImageRequestStyle.Vivid,
            User = "user",
        };

        string expectedPrompt = "A white siamese cat";
        ApiEnum<string, CreateImageRequestBackground> expectedBackground =
            CreateImageRequestBackground.Transparent;
        string expectedModel = "openai/dall-e-3";
        ApiEnum<string, CreateImageRequestModeration> expectedModeration =
            CreateImageRequestModeration.Auto;
        long expectedN = 1;
        long expectedOutputCompression = 85;
        ApiEnum<string, CreateImageRequestOutputFormat> expectedOutputFormat =
            CreateImageRequestOutputFormat.Png;
        long expectedPartialImages = 0;
        ApiEnum<string, CreateImageRequestQuality> expectedQuality =
            CreateImageRequestQuality.Standard;
        ApiEnum<string, CreateImageRequestResponseFormat> expectedResponseFormat =
            CreateImageRequestResponseFormat.Url;
        ApiEnum<string, CreateImageRequestSize> expectedSize = CreateImageRequestSize.V1024x1024;
        bool expectedStream = true;
        ApiEnum<string, CreateImageRequestStyle> expectedStyle = CreateImageRequestStyle.Vivid;
        string expectedUser = "user";

        Assert.Equal(expectedPrompt, model.Prompt);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedModeration, model.Moderation);
        Assert.Equal(expectedN, model.N);
        Assert.Equal(expectedOutputCompression, model.OutputCompression);
        Assert.Equal(expectedOutputFormat, model.OutputFormat);
        Assert.Equal(expectedPartialImages, model.PartialImages);
        Assert.Equal(expectedQuality, model.Quality);
        Assert.Equal(expectedResponseFormat, model.ResponseFormat);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedStream, model.Stream);
        Assert.Equal(expectedStyle, model.Style);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateImageRequest
        {
            Prompt = "A white siamese cat",
            Background = CreateImageRequestBackground.Transparent,
            Model = "openai/dall-e-3",
            Moderation = CreateImageRequestModeration.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = CreateImageRequestOutputFormat.Png,
            PartialImages = 0,
            Quality = CreateImageRequestQuality.Standard,
            ResponseFormat = CreateImageRequestResponseFormat.Url,
            Size = CreateImageRequestSize.V1024x1024,
            Stream = true,
            Style = CreateImageRequestStyle.Vivid,
            User = "user",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateImageRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateImageRequest
        {
            Prompt = "A white siamese cat",
            Background = CreateImageRequestBackground.Transparent,
            Model = "openai/dall-e-3",
            Moderation = CreateImageRequestModeration.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = CreateImageRequestOutputFormat.Png,
            PartialImages = 0,
            Quality = CreateImageRequestQuality.Standard,
            ResponseFormat = CreateImageRequestResponseFormat.Url,
            Size = CreateImageRequestSize.V1024x1024,
            Stream = true,
            Style = CreateImageRequestStyle.Vivid,
            User = "user",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateImageRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPrompt = "A white siamese cat";
        ApiEnum<string, CreateImageRequestBackground> expectedBackground =
            CreateImageRequestBackground.Transparent;
        string expectedModel = "openai/dall-e-3";
        ApiEnum<string, CreateImageRequestModeration> expectedModeration =
            CreateImageRequestModeration.Auto;
        long expectedN = 1;
        long expectedOutputCompression = 85;
        ApiEnum<string, CreateImageRequestOutputFormat> expectedOutputFormat =
            CreateImageRequestOutputFormat.Png;
        long expectedPartialImages = 0;
        ApiEnum<string, CreateImageRequestQuality> expectedQuality =
            CreateImageRequestQuality.Standard;
        ApiEnum<string, CreateImageRequestResponseFormat> expectedResponseFormat =
            CreateImageRequestResponseFormat.Url;
        ApiEnum<string, CreateImageRequestSize> expectedSize = CreateImageRequestSize.V1024x1024;
        bool expectedStream = true;
        ApiEnum<string, CreateImageRequestStyle> expectedStyle = CreateImageRequestStyle.Vivid;
        string expectedUser = "user";

        Assert.Equal(expectedPrompt, deserialized.Prompt);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedModeration, deserialized.Moderation);
        Assert.Equal(expectedN, deserialized.N);
        Assert.Equal(expectedOutputCompression, deserialized.OutputCompression);
        Assert.Equal(expectedOutputFormat, deserialized.OutputFormat);
        Assert.Equal(expectedPartialImages, deserialized.PartialImages);
        Assert.Equal(expectedQuality, deserialized.Quality);
        Assert.Equal(expectedResponseFormat, deserialized.ResponseFormat);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.Equal(expectedStyle, deserialized.Style);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateImageRequest
        {
            Prompt = "A white siamese cat",
            Background = CreateImageRequestBackground.Transparent,
            Model = "openai/dall-e-3",
            Moderation = CreateImageRequestModeration.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = CreateImageRequestOutputFormat.Png,
            PartialImages = 0,
            Quality = CreateImageRequestQuality.Standard,
            ResponseFormat = CreateImageRequestResponseFormat.Url,
            Size = CreateImageRequestSize.V1024x1024,
            Stream = true,
            Style = CreateImageRequestStyle.Vivid,
            User = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateImageRequest { Prompt = "A white siamese cat" };

        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Moderation);
        Assert.False(model.RawData.ContainsKey("moderation"));
        Assert.Null(model.N);
        Assert.False(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputCompression);
        Assert.False(model.RawData.ContainsKey("output_compression"));
        Assert.Null(model.OutputFormat);
        Assert.False(model.RawData.ContainsKey("output_format"));
        Assert.Null(model.PartialImages);
        Assert.False(model.RawData.ContainsKey("partial_images"));
        Assert.Null(model.Quality);
        Assert.False(model.RawData.ContainsKey("quality"));
        Assert.Null(model.ResponseFormat);
        Assert.False(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateImageRequest { Prompt = "A white siamese cat" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreateImageRequest
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

        Assert.Null(model.Background);
        Assert.True(model.RawData.ContainsKey("background"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.Moderation);
        Assert.True(model.RawData.ContainsKey("moderation"));
        Assert.Null(model.N);
        Assert.True(model.RawData.ContainsKey("n"));
        Assert.Null(model.OutputCompression);
        Assert.True(model.RawData.ContainsKey("output_compression"));
        Assert.Null(model.OutputFormat);
        Assert.True(model.RawData.ContainsKey("output_format"));
        Assert.Null(model.PartialImages);
        Assert.True(model.RawData.ContainsKey("partial_images"));
        Assert.Null(model.Quality);
        Assert.True(model.RawData.ContainsKey("quality"));
        Assert.Null(model.ResponseFormat);
        Assert.True(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.Size);
        Assert.True(model.RawData.ContainsKey("size"));
        Assert.Null(model.Stream);
        Assert.True(model.RawData.ContainsKey("stream"));
        Assert.Null(model.Style);
        Assert.True(model.RawData.ContainsKey("style"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateImageRequest
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateImageRequest
        {
            Prompt = "A white siamese cat",
            Background = CreateImageRequestBackground.Transparent,
            Model = "openai/dall-e-3",
            Moderation = CreateImageRequestModeration.Auto,
            N = 1,
            OutputCompression = 85,
            OutputFormat = CreateImageRequestOutputFormat.Png,
            PartialImages = 0,
            Quality = CreateImageRequestQuality.Standard,
            ResponseFormat = CreateImageRequestResponseFormat.Url,
            Size = CreateImageRequestSize.V1024x1024,
            Stream = true,
            Style = CreateImageRequestStyle.Vivid,
            User = "user",
        };

        CreateImageRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateImageRequestBackgroundTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestBackground.Transparent)]
    [InlineData(CreateImageRequestBackground.Opaque)]
    [InlineData(CreateImageRequestBackground.Auto)]
    public void Validation_Works(CreateImageRequestBackground rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestBackground> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestBackground>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestBackground.Transparent)]
    [InlineData(CreateImageRequestBackground.Opaque)]
    [InlineData(CreateImageRequestBackground.Auto)]
    public void SerializationRoundtrip_Works(CreateImageRequestBackground rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestBackground> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestBackground>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestBackground>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestBackground>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestModerationTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestModeration.Low)]
    [InlineData(CreateImageRequestModeration.Auto)]
    public void Validation_Works(CreateImageRequestModeration rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestModeration> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestModeration>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestModeration.Low)]
    [InlineData(CreateImageRequestModeration.Auto)]
    public void SerializationRoundtrip_Works(CreateImageRequestModeration rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestModeration> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestModeration>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestModeration>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestModeration>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestOutputFormat.Png)]
    [InlineData(CreateImageRequestOutputFormat.Jpeg)]
    [InlineData(CreateImageRequestOutputFormat.Webp)]
    public void Validation_Works(CreateImageRequestOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestOutputFormat.Png)]
    [InlineData(CreateImageRequestOutputFormat.Jpeg)]
    [InlineData(CreateImageRequestOutputFormat.Webp)]
    public void SerializationRoundtrip_Works(CreateImageRequestOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestQualityTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestQuality.Auto)]
    [InlineData(CreateImageRequestQuality.High)]
    [InlineData(CreateImageRequestQuality.Medium)]
    [InlineData(CreateImageRequestQuality.Low)]
    [InlineData(CreateImageRequestQuality.HD)]
    [InlineData(CreateImageRequestQuality.Standard)]
    public void Validation_Works(CreateImageRequestQuality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestQuality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestQuality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestQuality.Auto)]
    [InlineData(CreateImageRequestQuality.High)]
    [InlineData(CreateImageRequestQuality.Medium)]
    [InlineData(CreateImageRequestQuality.Low)]
    [InlineData(CreateImageRequestQuality.HD)]
    [InlineData(CreateImageRequestQuality.Standard)]
    public void SerializationRoundtrip_Works(CreateImageRequestQuality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestQuality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestQuality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestQuality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestQuality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestResponseFormatTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestResponseFormat.Url)]
    [InlineData(CreateImageRequestResponseFormat.B64Json)]
    public void Validation_Works(CreateImageRequestResponseFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestResponseFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestResponseFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestResponseFormat.Url)]
    [InlineData(CreateImageRequestResponseFormat.B64Json)]
    public void SerializationRoundtrip_Works(CreateImageRequestResponseFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestResponseFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestResponseFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestResponseFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateImageRequestResponseFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestSizeTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestSize.V256x256)]
    [InlineData(CreateImageRequestSize.V512x512)]
    [InlineData(CreateImageRequestSize.V1024x1024)]
    [InlineData(CreateImageRequestSize.V1536x1024)]
    [InlineData(CreateImageRequestSize.V1024x1536)]
    [InlineData(CreateImageRequestSize.V1792x1024)]
    [InlineData(CreateImageRequestSize.V1024x1792)]
    [InlineData(CreateImageRequestSize.Auto)]
    public void Validation_Works(CreateImageRequestSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestSize> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestSize.V256x256)]
    [InlineData(CreateImageRequestSize.V512x512)]
    [InlineData(CreateImageRequestSize.V1024x1024)]
    [InlineData(CreateImageRequestSize.V1536x1024)]
    [InlineData(CreateImageRequestSize.V1024x1536)]
    [InlineData(CreateImageRequestSize.V1792x1024)]
    [InlineData(CreateImageRequestSize.V1024x1792)]
    [InlineData(CreateImageRequestSize.Auto)]
    public void SerializationRoundtrip_Works(CreateImageRequestSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestSize> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateImageRequestStyleTest : TestBase
{
    [Theory]
    [InlineData(CreateImageRequestStyle.Vivid)]
    [InlineData(CreateImageRequestStyle.Natural)]
    public void Validation_Works(CreateImageRequestStyle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestStyle> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestStyle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateImageRequestStyle.Vivid)]
    [InlineData(CreateImageRequestStyle.Natural)]
    public void SerializationRoundtrip_Works(CreateImageRequestStyle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateImageRequestStyle> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestStyle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestStyle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateImageRequestStyle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
