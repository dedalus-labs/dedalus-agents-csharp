using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Tests.Models.Ocr;

public class OcrDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url", Type = "type" };

        string expectedDocumentUrl = "document_url";
        string expectedType = "type";

        Assert.Equal(expectedDocumentUrl, model.DocumentUrl);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url", Type = "type" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url", Type = "type" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDocumentUrl = "document_url";
        string expectedType = "type";

        Assert.Equal(expectedDocumentUrl, deserialized.DocumentUrl);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OcrDocument
        {
            DocumentUrl = "document_url",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OcrDocument
        {
            DocumentUrl = "document_url",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OcrDocument { DocumentUrl = "document_url", Type = "type" };

        OcrDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}
