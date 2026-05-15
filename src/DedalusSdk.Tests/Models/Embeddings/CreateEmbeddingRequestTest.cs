using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Tests.Models.Embeddings;

public class CreateEmbeddingRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = CreateEmbeddingRequestEncodingFormat.Float,
            User = "user",
        };

        CreateEmbeddingRequestInput expectedInput = "string";
        ApiEnum<string, CreateEmbeddingRequestModel> expectedModel =
            CreateEmbeddingRequestModel.TextEmbeddingAda002;
        long expectedDimensions = 1;
        ApiEnum<string, CreateEmbeddingRequestEncodingFormat> expectedEncodingFormat =
            CreateEmbeddingRequestEncodingFormat.Float;
        string expectedUser = "user";

        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedDimensions, model.Dimensions);
        Assert.Equal(expectedEncodingFormat, model.EncodingFormat);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = CreateEmbeddingRequestEncodingFormat.Float,
            User = "user",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = CreateEmbeddingRequestEncodingFormat.Float,
            User = "user",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CreateEmbeddingRequestInput expectedInput = "string";
        ApiEnum<string, CreateEmbeddingRequestModel> expectedModel =
            CreateEmbeddingRequestModel.TextEmbeddingAda002;
        long expectedDimensions = 1;
        ApiEnum<string, CreateEmbeddingRequestEncodingFormat> expectedEncodingFormat =
            CreateEmbeddingRequestEncodingFormat.Float;
        string expectedUser = "user";

        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedDimensions, deserialized.Dimensions);
        Assert.Equal(expectedEncodingFormat, deserialized.EncodingFormat);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = CreateEmbeddingRequestEncodingFormat.Float,
            User = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
        };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.EncodingFormat);
        Assert.False(model.RawData.ContainsKey("encoding_format"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            EncodingFormat = null,
            User = null,
        };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.EncodingFormat);
        Assert.False(model.RawData.ContainsKey("encoding_format"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            EncodingFormat = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateEmbeddingRequest
        {
            Input = "string",
            Model = CreateEmbeddingRequestModel.TextEmbeddingAda002,
            Dimensions = 1,
            EncodingFormat = CreateEmbeddingRequestEncodingFormat.Float,
            User = "user",
        };

        CreateEmbeddingRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateEmbeddingRequestInputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CreateEmbeddingRequestInput value = "string";
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks()
    {
        CreateEmbeddingRequestInput value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks1()
    {
        CreateEmbeddingRequestInput value = new List<long>() { 0 };
        value.Validate();
    }

    [Fact]
    public void EmbeddingRequestInputArrayValidationWorks2()
    {
        CreateEmbeddingRequestInput value = new([new List<long>() { 0 }]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CreateEmbeddingRequestInput value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequestInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks()
    {
        CreateEmbeddingRequestInput value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequestInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks1()
    {
        CreateEmbeddingRequestInput value = new List<long>() { 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequestInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EmbeddingRequestInputArraySerializationRoundtripWorks2()
    {
        CreateEmbeddingRequestInput value = new([new List<long>() { 0 }]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingRequestInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateEmbeddingRequestModelTest : TestBase
{
    [Theory]
    [InlineData(CreateEmbeddingRequestModel.TextEmbeddingAda002)]
    [InlineData(CreateEmbeddingRequestModel.TextEmbedding3Small)]
    [InlineData(CreateEmbeddingRequestModel.TextEmbedding3Large)]
    public void Validation_Works(CreateEmbeddingRequestModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateEmbeddingRequestModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateEmbeddingRequestModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateEmbeddingRequestModel.TextEmbeddingAda002)]
    [InlineData(CreateEmbeddingRequestModel.TextEmbedding3Small)]
    [InlineData(CreateEmbeddingRequestModel.TextEmbedding3Large)]
    public void SerializationRoundtrip_Works(CreateEmbeddingRequestModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateEmbeddingRequestModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateEmbeddingRequestModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateEmbeddingRequestModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateEmbeddingRequestModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateEmbeddingRequestEncodingFormatTest : TestBase
{
    [Theory]
    [InlineData(CreateEmbeddingRequestEncodingFormat.Float)]
    [InlineData(CreateEmbeddingRequestEncodingFormat.Base64)]
    public void Validation_Works(CreateEmbeddingRequestEncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateEmbeddingRequestEncodingFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateEmbeddingRequestEncodingFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateEmbeddingRequestEncodingFormat.Float)]
    [InlineData(CreateEmbeddingRequestEncodingFormat.Base64)]
    public void SerializationRoundtrip_Works(CreateEmbeddingRequestEncodingFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateEmbeddingRequestEncodingFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateEmbeddingRequestEncodingFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateEmbeddingRequestEncodingFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateEmbeddingRequestEncodingFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
