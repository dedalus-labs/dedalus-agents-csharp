using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class FunctionDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionDefinition { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionDefinition { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDefinition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionDefinition { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionDefinition { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionDefinition { Name = "name" };

        FunctionDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}
