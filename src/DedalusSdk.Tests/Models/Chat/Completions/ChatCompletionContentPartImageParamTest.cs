using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionContentPartImageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartImageParam
        {
            ImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto },
        };

        ImageUrl expectedImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image_url");

        Assert.Equal(expectedImageUrl, model.ImageUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionContentPartImageParam
        {
            ImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartImageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionContentPartImageParam
        {
            ImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionContentPartImageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ImageUrl expectedImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image_url");

        Assert.Equal(expectedImageUrl, deserialized.ImageUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionContentPartImageParam
        {
            ImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionContentPartImageParam
        {
            ImageUrl = new() { Url = "https://example.com", Detail = Detail.Auto },
        };

        ChatCompletionContentPartImageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageUrl { Url = "https://example.com", Detail = Detail.Auto };

        string expectedUrl = "https://example.com";
        ApiEnum<string, Detail> expectedDetail = Detail.Auto;

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedDetail, model.Detail);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageUrl { Url = "https://example.com", Detail = Detail.Auto };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageUrl>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageUrl { Url = "https://example.com", Detail = Detail.Auto };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";
        ApiEnum<string, Detail> expectedDetail = Detail.Auto;

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedDetail, deserialized.Detail);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageUrl { Url = "https://example.com", Detail = Detail.Auto };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageUrl { Url = "https://example.com" };

        Assert.Null(model.Detail);
        Assert.False(model.RawData.ContainsKey("detail"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageUrl { Url = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageUrl
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Detail = null,
        };

        Assert.Null(model.Detail);
        Assert.False(model.RawData.ContainsKey("detail"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageUrl
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Detail = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageUrl { Url = "https://example.com", Detail = Detail.Auto };

        ImageUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DetailTest : TestBase
{
    [Theory]
    [InlineData(Detail.Auto)]
    [InlineData(Detail.Low)]
    [InlineData(Detail.High)]
    public void Validation_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Detail.Auto)]
    [InlineData(Detail.Low)]
    [InlineData(Detail.High)]
    public void SerializationRoundtrip_Works(Detail rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Detail> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Detail>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
