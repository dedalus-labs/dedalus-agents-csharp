using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class ResponseFormatTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResponseFormatText { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResponseFormatText { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseFormatText>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResponseFormatText { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponseFormatText>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResponseFormatText { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResponseFormatText { };

        ResponseFormatText copied = new(model);

        Assert.Equal(model, copied);
    }
}
