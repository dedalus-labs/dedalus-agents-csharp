using System;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Tests.Models.Ocr;

public class OcrProcessParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OcrProcessParams
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        OcrDocument expectedDocument = new() { DocumentUrl = "document_url", Type = "type" };
        string expectedModel = "model";

        Assert.Equal(expectedDocument, parameters.Document);
        Assert.Equal(expectedModel, parameters.Model);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new OcrProcessParams
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new OcrProcessParams
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },

            // Null should be interpreted as omitted for these properties
            Model = null,
        };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
    }

    [Fact]
    public void Url_Works()
    {
        OcrProcessParams parameters = new()
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/ocr"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OcrProcessParams
        {
            Document = new() { DocumentUrl = "document_url", Type = "type" },
            Model = "model",
        };

        OcrProcessParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
