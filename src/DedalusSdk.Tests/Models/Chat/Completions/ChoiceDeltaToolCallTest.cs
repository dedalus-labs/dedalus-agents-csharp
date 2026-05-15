using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChoiceDeltaToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            Type = ChoiceDeltaToolCallType.Function,
        };

        long expectedIndex = 0;
        string expectedID = "id";
        ChoiceDeltaToolCallFunction expectedFunction = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        ApiEnum<string, ChoiceDeltaToolCallType> expectedType = ChoiceDeltaToolCallType.Function;

        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            Type = ChoiceDeltaToolCallType.Function,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaToolCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            Type = ChoiceDeltaToolCallType.Function,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedIndex = 0;
        string expectedID = "id";
        ChoiceDeltaToolCallFunction expectedFunction = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        ApiEnum<string, ChoiceDeltaToolCallType> expectedType = ChoiceDeltaToolCallType.Function;

        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            Type = ChoiceDeltaToolCallType.Function,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceDeltaToolCall { Index = 0 };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Function);
        Assert.False(model.RawData.ContainsKey("function"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceDeltaToolCall { Index = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Function = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Function);
        Assert.False(model.RawData.ContainsKey("function"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Function = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChoiceDeltaToolCall
        {
            Index = 0,
            ID = "id",
            Function = new() { Arguments = "arguments", Name = "name" },
            Type = ChoiceDeltaToolCallType.Function,
        };

        ChoiceDeltaToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChoiceDeltaToolCallFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { Arguments = "arguments", Name = "name" };

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { Arguments = "arguments", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaToolCallFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { Arguments = "arguments", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaToolCallFunction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { Arguments = "arguments", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChoiceDeltaToolCallFunction
        {
            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Name = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceDeltaToolCallFunction
        {
            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChoiceDeltaToolCallFunction { Arguments = "arguments", Name = "name" };

        ChoiceDeltaToolCallFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChoiceDeltaToolCallTypeTest : TestBase
{
    [Theory]
    [InlineData(ChoiceDeltaToolCallType.Function)]
    public void Validation_Works(ChoiceDeltaToolCallType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChoiceDeltaToolCallType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChoiceDeltaToolCallType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChoiceDeltaToolCallType.Function)]
    public void SerializationRoundtrip_Works(ChoiceDeltaToolCallType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChoiceDeltaToolCallType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChoiceDeltaToolCallType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChoiceDeltaToolCallType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChoiceDeltaToolCallType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
