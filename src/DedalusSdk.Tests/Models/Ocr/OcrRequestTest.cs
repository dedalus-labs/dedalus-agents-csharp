using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Tests.Models.Ocr;

public class OcrRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        OcrDocument expectedDocument = new() { DocumentUrl = "document_url", Type = "type" };
        string expectedModel = "model";

        Assert.Equal(expectedDocument, model.Document);
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        OcrDocument expectedDocument = new() { DocumentUrl = "document_url", Type = "type" };
        string expectedModel = "model";

        Assert.Equal(expectedDocument, deserialized.Document);
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },

            // Null should be interpreted as omitted for these properties
            Model = null,
        };

        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },

            // Null should be interpreted as omitted for these properties
            Model = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OcrRequest
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        OcrRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
