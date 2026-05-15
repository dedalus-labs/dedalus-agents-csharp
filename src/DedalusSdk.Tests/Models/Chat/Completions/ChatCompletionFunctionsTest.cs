using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionFunctionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",
            Description = "description",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedName = "name";
        string expectedDescription = "description";
        Dictionary<string, JsonElement> expectedParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Parameters);
        Assert.Equal(expectedParameters.Count, model.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(model.Parameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Parameters[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",
            Description = "description",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionFunctions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",
            Description = "description",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionFunctions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        Dictionary<string, JsonElement> expectedParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Parameters);
        Assert.Equal(expectedParameters.Count, deserialized.Parameters.Count);
        foreach (var item in expectedParameters)
        {
            Assert.True(deserialized.Parameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Parameters[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",
            Description = "description",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCompletionFunctions { Name = "name" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCompletionFunctions { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Parameters = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Parameters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionFunctions
        {
            Name = "name",
            Description = "description",
            Parameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ChatCompletionFunctions copied = new(model);

        Assert.Equal(model, copied);
    }
}
