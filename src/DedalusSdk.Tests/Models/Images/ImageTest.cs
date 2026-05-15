using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Tests.Models.Images;

public class ImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Image
        {
            B64Json = "b64_json",
            RevisedPrompt = "revised_prompt",
            Url = "url",
        };

        string expectedB64Json = "b64_json";
        string expectedRevisedPrompt = "revised_prompt";
        string expectedUrl = "url";

        Assert.Equal(expectedB64Json, model.B64Json);
        Assert.Equal(expectedRevisedPrompt, model.RevisedPrompt);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Image
        {
            B64Json = "b64_json",
            RevisedPrompt = "revised_prompt",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Image
        {
            B64Json = "b64_json",
            RevisedPrompt = "revised_prompt",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedB64Json = "b64_json";
        string expectedRevisedPrompt = "revised_prompt";
        string expectedUrl = "url";

        Assert.Equal(expectedB64Json, deserialized.B64Json);
        Assert.Equal(expectedRevisedPrompt, deserialized.RevisedPrompt);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Image
        {
            B64Json = "b64_json",
            RevisedPrompt = "revised_prompt",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Image { };

        Assert.Null(model.B64Json);
        Assert.False(model.RawData.ContainsKey("b64_json"));
        Assert.Null(model.RevisedPrompt);
        Assert.False(model.RawData.ContainsKey("revised_prompt"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Image { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Image
        {
            B64Json = null,
            RevisedPrompt = null,
            Url = null,
        };

        Assert.Null(model.B64Json);
        Assert.True(model.RawData.ContainsKey("b64_json"));
        Assert.Null(model.RevisedPrompt);
        Assert.True(model.RawData.ContainsKey("revised_prompt"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Image
        {
            B64Json = null,
            RevisedPrompt = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Image
        {
            B64Json = "b64_json",
            RevisedPrompt = "revised_prompt",
            Url = "url",
        };

        Image copied = new(model);

        Assert.Equal(model, copied);
    }
}
