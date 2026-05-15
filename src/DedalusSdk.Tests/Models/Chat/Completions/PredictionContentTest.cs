using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class PredictionContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PredictionContent { Content = "string" };

        PredictionContentContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.SerializeToElement("content");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PredictionContent { Content = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PredictionContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PredictionContent { Content = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PredictionContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PredictionContentContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.SerializeToElement("content");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PredictionContent { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PredictionContent { Content = "string" };

        PredictionContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PredictionContentContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        PredictionContentContent value = "string";
        value.Validate();
    }

    [Fact]
    public void PredictionContentArrayValidationWorks()
    {
        PredictionContentContent value = new([new ChatCompletionContentPartTextParam("text")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PredictionContentContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PredictionContentContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PredictionContentArraySerializationRoundtripWorks()
    {
        PredictionContentContent value = new([new ChatCompletionContentPartTextParam("text")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PredictionContentContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
