using System;
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using Models = DedalusSdk.Models.Models;

namespace DedalusSdk.Tests.Models.Models;

public class ListModelsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
            Object = Models::Object.List,
        };

        List<Models::Model> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Provider = Models::Provider.OpenAI,
                Capabilities = new()
                {
                    Audio = true,
                    ImageGeneration = true,
                    InputTokenLimit = 0,
                    OutputTokenLimit = 0,
                    Streaming = true,
                    StructuredOutput = true,
                    Text = true,
                    Thinking = true,
                    Tools = true,
                    Vision = true,
                },
                Defaults = new()
                {
                    MaxOutputTokens = 0,
                    Temperature = 0,
                    TopK = 0,
                    TopP = 0,
                },
                Description = "description",
                DisplayName = "display_name",
                ProviderDeclaredGenerationMethods = ["string"],
                ProviderInfo = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Version = "version",
            },
        ];
        ApiEnum<string, Models::Object> expectedObject = Models::Object.List;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedObject, model.Object);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
            Object = Models::Object.List,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Models::ListModelsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
            Object = Models::Object.List,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Models::ListModelsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Models::Model> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Provider = Models::Provider.OpenAI,
                Capabilities = new()
                {
                    Audio = true,
                    ImageGeneration = true,
                    InputTokenLimit = 0,
                    OutputTokenLimit = 0,
                    Streaming = true,
                    StructuredOutput = true,
                    Text = true,
                    Thinking = true,
                    Tools = true,
                    Vision = true,
                },
                Defaults = new()
                {
                    MaxOutputTokens = 0,
                    Temperature = 0,
                    TopK = 0,
                    TopP = 0,
                },
                Description = "description",
                DisplayName = "display_name",
                ProviderDeclaredGenerationMethods = ["string"],
                ProviderInfo = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Version = "version",
            },
        ];
        ApiEnum<string, Models::Object> expectedObject = Models::Object.List;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedObject, deserialized.Object);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
            Object = Models::Object.List,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
        };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Object = null,
        };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Object = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Models::ListModelsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Provider = Models::Provider.OpenAI,
                    Capabilities = new()
                    {
                        Audio = true,
                        ImageGeneration = true,
                        InputTokenLimit = 0,
                        OutputTokenLimit = 0,
                        Streaming = true,
                        StructuredOutput = true,
                        Text = true,
                        Thinking = true,
                        Tools = true,
                        Vision = true,
                    },
                    Defaults = new()
                    {
                        MaxOutputTokens = 0,
                        Temperature = 0,
                        TopK = 0,
                        TopP = 0,
                    },
                    Description = "description",
                    DisplayName = "display_name",
                    ProviderDeclaredGenerationMethods = ["string"],
                    ProviderInfo = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Version = "version",
                },
            ],
            Object = Models::Object.List,
        };

        Models::ListModelsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Models::Object.List)]
    public void Validation_Works(Models::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Models::Object> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Models::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Models::Object.List)]
    public void SerializationRoundtrip_Works(Models::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Models::Object> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Models::Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Models::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Models::Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
