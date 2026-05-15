using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class VoiceIdsOrCustomVoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceIdsOrCustomVoice { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceIdsOrCustomVoice { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceIdsOrCustomVoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceIdsOrCustomVoice { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceIdsOrCustomVoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceIdsOrCustomVoice { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceIdsOrCustomVoice { ID = "id" };

        VoiceIdsOrCustomVoice copied = new(model);

        Assert.Equal(model, copied);
    }
}
