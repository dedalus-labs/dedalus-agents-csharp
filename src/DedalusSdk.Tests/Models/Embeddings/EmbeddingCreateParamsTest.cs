using System;
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Tests.Models.Embeddings;

public class EmbeddingCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EmbeddingCreateParams
        {
            Input = "string",
            Model = Model.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = EncodingFormat.Float,
            User = "user",
        };

        Input expectedInput = "string";
        ApiEnum<string, Model> expectedModel = Model.TextEmbeddingAda002;
        long expectedDimensions = 1;
        ApiEnum<string, EncodingFormat> expectedEncodingFormat = EncodingFormat.Float;
        string expectedUser = "user";

        Assert.Equal(expectedInput, parameters.Input);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedDimensions, parameters.Dimensions);
        Assert.Equal(expectedEncodingFormat, parameters.EncodingFormat);
        Assert.Equal(expectedUser, parameters.User);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EmbeddingCreateParams
        {
            Input = "string",
            Model = Model.TextEmbeddingAda002,
        };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.EncodingFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("encoding_format"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EmbeddingCreateParams
        {
            Input = "string",
            Model = Model.TextEmbeddingAda002,

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            EncodingFormat = null,
            User = null,
        };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.EncodingFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("encoding_format"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void Url_Works()
    {
        EmbeddingCreateParams parameters = new()
        {
            Input = "string",
            Model = Model.TextEmbeddingAda002,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/embeddings"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EmbeddingCreateParams
        {
            Input = "string",
            Model = Model.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = EncodingFormat.Float,
            User = "user",
        };

        EmbeddingCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Input value = "string";
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks()
    {
        Input value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks1()
    {
        Input value = new List<long>() { 0 };
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks2()
    {
        Input value = new([new List<long>() { 0 }]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Input value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks()
    {
        Input value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks1()
    {
        Input value = new List<long>() { 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks2()
    {
        Input value = new([new List<long>() { 0 }]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.TextEmbeddingAda002)]
    [InlineData(Model.TextEmbedding3Small)]
    [InlineData(Model.TextEmbedding3Large)]
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
    [InlineData(Model.TextEmbeddingAda002)]
    [InlineData(Model.TextEmbedding3Small)]
    [InlineData(Model.TextEmbedding3Large)]
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

public class EncodingFormatTest : TestBase
{
    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void Validation_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EncodingFormat.Float)]
    [InlineData(EncodingFormat.Base64)]
    public void SerializationRoundtrip_Works(EncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EncodingFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EncodingFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
