using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Tests.Models.Ocr;

public class OcrResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedModel = "model";
        List<OcrPage> expectedPages = [new() { Index = 0, Markdown = "markdown" }];
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
        Assert.NotNull(model.Usage);
        Assert.Equal(expectedUsage.Count, model.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(model.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Usage[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedModel = "model";
        List<OcrPage> expectedPages = [new() { Index = 0, Markdown = "markdown" }];
        Dictionary<string, JsonElement> expectedUsage = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
        Assert.NotNull(deserialized.Usage);
        Assert.Equal(expectedUsage.Count, deserialized.Usage.Count);
        foreach (var item in expectedUsage)
        {
            Assert.True(deserialized.Usage.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Usage[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
        };

        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],

            Usage = null,
        };

        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],

            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OcrResponse
        {
            Model = "model",
            Pages = [new() { Index = 0, Markdown = "markdown" }],
            Usage = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        OcrResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
