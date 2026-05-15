using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class JsonValueInputTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        JsonValueInput value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        JsonValueInput value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        JsonValueInput value = true;
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks()
    {
        JsonValueInput value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        value.Validate();
    }

    [Fact]
    public void JsonValueInputsValidationWorks1()
    {
        JsonValueInput value = new([new JsonValueInput("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        JsonValueInput value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JsonValueInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        JsonValueInput value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JsonValueInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        JsonValueInput value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JsonValueInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks()
    {
        JsonValueInput value = new(
            new Dictionary<string, JsonValueInput?>() { { "foo", "string" } }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JsonValueInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonValueInputsSerializationRoundtripWorks1()
    {
        JsonValueInput value = new([new JsonValueInput("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JsonValueInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
