using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Ocr;

namespace DedalusSdk.Tests.Models.Ocr;

public class OcrPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OcrPage { Index = 0, Markdown = "markdown" };

        long expectedIndex = 0;
        string expectedMarkdown = "markdown";

        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedMarkdown, model.Markdown);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OcrPage { Index = 0, Markdown = "markdown" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrPage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OcrPage { Index = 0, Markdown = "markdown" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OcrPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedIndex = 0;
        string expectedMarkdown = "markdown";

        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedMarkdown, deserialized.Markdown);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OcrPage { Index = 0, Markdown = "markdown" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OcrPage { Index = 0, Markdown = "markdown" };

        OcrPage copied = new(model);

        Assert.Equal(model, copied);
    }
}
