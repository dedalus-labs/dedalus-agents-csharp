using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void UnionMember0ValidationWorks()
    {
        ToolChoice value = UnionMember0.Auto;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ToolChoice value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        ToolChoice value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void McpValidationWorks()
    {
        ToolChoice value = new McpToolChoice() { Name = "name", ServerLabel = "server_label" };
        value.Validate();
    }

    [Fact]
    public void UnionMember0SerializationRoundtripWorks()
    {
        ToolChoice value = UnionMember0.Auto;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ToolChoice value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ToolChoice value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpSerializationRoundtripWorks()
    {
        ToolChoice value = new McpToolChoice() { Name = "name", ServerLabel = "server_label" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0Test : TestBase
{
    [Theory]
    [InlineData(UnionMember0.Auto)]
    [InlineData(UnionMember0.Required)]
    [InlineData(UnionMember0.None)]
    public void Validation_Works(UnionMember0 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember0.Auto)]
    [InlineData(UnionMember0.Required)]
    [InlineData(UnionMember0.None)]
    public void SerializationRoundtrip_Works(UnionMember0 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember0>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class McpToolChoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpToolChoice { Name = "name", ServerLabel = "server_label" };

        string expectedName = "name";
        string expectedServerLabel = "server_label";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedServerLabel, model.ServerLabel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpToolChoice { Name = "name", ServerLabel = "server_label" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpToolChoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpToolChoice { Name = "name", ServerLabel = "server_label" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpToolChoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedServerLabel = "server_label";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedServerLabel, deserialized.ServerLabel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpToolChoice { Name = "name", ServerLabel = "server_label" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpToolChoice { Name = "name", ServerLabel = "server_label" };

        McpToolChoice copied = new(model);

        Assert.Equal(model, copied);
    }
}
