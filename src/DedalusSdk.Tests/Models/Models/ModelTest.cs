using System;
using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Models;

namespace DedalusSdk.Tests.Models.Models;

public class ModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
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
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Provider> expectedProvider = Provider.OpenAI;
        Capabilities expectedCapabilities = new()
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
        };
        Defaults expectedDefaults = new()
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        List<string> expectedProviderDeclaredGenerationMethods = ["string"];
        Dictionary<string, JsonElement> expectedProviderInfo = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedCapabilities, model.Capabilities);
        Assert.Equal(expectedDefaults, model.Defaults);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.ProviderDeclaredGenerationMethods);
        Assert.Equal(
            expectedProviderDeclaredGenerationMethods.Count,
            model.ProviderDeclaredGenerationMethods.Count
        );
        for (int i = 0; i < expectedProviderDeclaredGenerationMethods.Count; i++)
        {
            Assert.Equal(
                expectedProviderDeclaredGenerationMethods[i],
                model.ProviderDeclaredGenerationMethods[i]
            );
        }
        Assert.NotNull(model.ProviderInfo);
        Assert.Equal(expectedProviderInfo.Count, model.ProviderInfo.Count);
        foreach (var item in expectedProviderInfo)
        {
            Assert.True(model.ProviderInfo.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ProviderInfo[item.Key]));
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Provider> expectedProvider = Provider.OpenAI;
        Capabilities expectedCapabilities = new()
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
        };
        Defaults expectedDefaults = new()
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "display_name";
        List<string> expectedProviderDeclaredGenerationMethods = ["string"];
        Dictionary<string, JsonElement> expectedProviderInfo = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedVersion = "version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedCapabilities, deserialized.Capabilities);
        Assert.Equal(expectedDefaults, deserialized.Defaults);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.ProviderDeclaredGenerationMethods);
        Assert.Equal(
            expectedProviderDeclaredGenerationMethods.Count,
            deserialized.ProviderDeclaredGenerationMethods.Count
        );
        for (int i = 0; i < expectedProviderDeclaredGenerationMethods.Count; i++)
        {
            Assert.Equal(
                expectedProviderDeclaredGenerationMethods[i],
                deserialized.ProviderDeclaredGenerationMethods[i]
            );
        }
        Assert.NotNull(deserialized.ProviderInfo);
        Assert.Equal(expectedProviderInfo.Count, deserialized.ProviderInfo.Count);
        foreach (var item in expectedProviderInfo)
        {
            Assert.True(deserialized.ProviderInfo.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ProviderInfo[item.Key]));
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
        };

        Assert.Null(model.Capabilities);
        Assert.False(model.RawData.ContainsKey("capabilities"));
        Assert.Null(model.Defaults);
        Assert.False(model.RawData.ContainsKey("defaults"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.ProviderDeclaredGenerationMethods);
        Assert.False(model.RawData.ContainsKey("provider_declared_generation_methods"));
        Assert.Null(model.ProviderInfo);
        Assert.False(model.RawData.ContainsKey("provider_info"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,

            Capabilities = null,
            Defaults = null,
            Description = null,
            DisplayName = null,
            ProviderDeclaredGenerationMethods = null,
            ProviderInfo = null,
            Version = null,
        };

        Assert.Null(model.Capabilities);
        Assert.True(model.RawData.ContainsKey("capabilities"));
        Assert.Null(model.Defaults);
        Assert.True(model.RawData.ContainsKey("defaults"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
        Assert.Null(model.ProviderDeclaredGenerationMethods);
        Assert.True(model.RawData.ContainsKey("provider_declared_generation_methods"));
        Assert.Null(model.ProviderInfo);
        Assert.True(model.RawData.ContainsKey("provider_info"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,

            Capabilities = null,
            Defaults = null,
            Description = null,
            DisplayName = null,
            ProviderDeclaredGenerationMethods = null,
            ProviderInfo = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Model
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Provider = Provider.OpenAI,
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
        };

        Model copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Provider.OpenAI)]
    [InlineData(Provider.Anthropic)]
    [InlineData(Provider.Google)]
    [InlineData(Provider.Xai)]
    [InlineData(Provider.Mistral)]
    [InlineData(Provider.Groq)]
    [InlineData(Provider.Fireworks)]
    [InlineData(Provider.Deepseek)]
    [InlineData(Provider.Moonshot)]
    [InlineData(Provider.Cerebras)]
    public void Validation_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Provider.OpenAI)]
    [InlineData(Provider.Anthropic)]
    [InlineData(Provider.Google)]
    [InlineData(Provider.Xai)]
    [InlineData(Provider.Mistral)]
    [InlineData(Provider.Groq)]
    [InlineData(Provider.Fireworks)]
    [InlineData(Provider.Deepseek)]
    [InlineData(Provider.Moonshot)]
    [InlineData(Provider.Cerebras)]
    public void SerializationRoundtrip_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CapabilitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Capabilities
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
        };

        bool expectedAudio = true;
        bool expectedImageGeneration = true;
        long expectedInputTokenLimit = 0;
        long expectedOutputTokenLimit = 0;
        bool expectedStreaming = true;
        bool expectedStructuredOutput = true;
        bool expectedText = true;
        bool expectedThinking = true;
        bool expectedTools = true;
        bool expectedVision = true;

        Assert.Equal(expectedAudio, model.Audio);
        Assert.Equal(expectedImageGeneration, model.ImageGeneration);
        Assert.Equal(expectedInputTokenLimit, model.InputTokenLimit);
        Assert.Equal(expectedOutputTokenLimit, model.OutputTokenLimit);
        Assert.Equal(expectedStreaming, model.Streaming);
        Assert.Equal(expectedStructuredOutput, model.StructuredOutput);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.Equal(expectedTools, model.Tools);
        Assert.Equal(expectedVision, model.Vision);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Capabilities
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Capabilities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Capabilities
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Capabilities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAudio = true;
        bool expectedImageGeneration = true;
        long expectedInputTokenLimit = 0;
        long expectedOutputTokenLimit = 0;
        bool expectedStreaming = true;
        bool expectedStructuredOutput = true;
        bool expectedText = true;
        bool expectedThinking = true;
        bool expectedTools = true;
        bool expectedVision = true;

        Assert.Equal(expectedAudio, deserialized.Audio);
        Assert.Equal(expectedImageGeneration, deserialized.ImageGeneration);
        Assert.Equal(expectedInputTokenLimit, deserialized.InputTokenLimit);
        Assert.Equal(expectedOutputTokenLimit, deserialized.OutputTokenLimit);
        Assert.Equal(expectedStreaming, deserialized.Streaming);
        Assert.Equal(expectedStructuredOutput, deserialized.StructuredOutput);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.Equal(expectedTools, deserialized.Tools);
        Assert.Equal(expectedVision, deserialized.Vision);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Capabilities
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Capabilities { };

        Assert.Null(model.Audio);
        Assert.False(model.RawData.ContainsKey("audio"));
        Assert.Null(model.ImageGeneration);
        Assert.False(model.RawData.ContainsKey("image_generation"));
        Assert.Null(model.InputTokenLimit);
        Assert.False(model.RawData.ContainsKey("input_token_limit"));
        Assert.Null(model.OutputTokenLimit);
        Assert.False(model.RawData.ContainsKey("output_token_limit"));
        Assert.Null(model.Streaming);
        Assert.False(model.RawData.ContainsKey("streaming"));
        Assert.Null(model.StructuredOutput);
        Assert.False(model.RawData.ContainsKey("structured_output"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Vision);
        Assert.False(model.RawData.ContainsKey("vision"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Capabilities { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Capabilities
        {
            Audio = null,
            ImageGeneration = null,
            InputTokenLimit = null,
            OutputTokenLimit = null,
            Streaming = null,
            StructuredOutput = null,
            Text = null,
            Thinking = null,
            Tools = null,
            Vision = null,
        };

        Assert.Null(model.Audio);
        Assert.True(model.RawData.ContainsKey("audio"));
        Assert.Null(model.ImageGeneration);
        Assert.True(model.RawData.ContainsKey("image_generation"));
        Assert.Null(model.InputTokenLimit);
        Assert.True(model.RawData.ContainsKey("input_token_limit"));
        Assert.Null(model.OutputTokenLimit);
        Assert.True(model.RawData.ContainsKey("output_token_limit"));
        Assert.Null(model.Streaming);
        Assert.True(model.RawData.ContainsKey("streaming"));
        Assert.Null(model.StructuredOutput);
        Assert.True(model.RawData.ContainsKey("structured_output"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.Thinking);
        Assert.True(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.Tools);
        Assert.True(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Vision);
        Assert.True(model.RawData.ContainsKey("vision"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Capabilities
        {
            Audio = null,
            ImageGeneration = null,
            InputTokenLimit = null,
            OutputTokenLimit = null,
            Streaming = null,
            StructuredOutput = null,
            Text = null,
            Thinking = null,
            Tools = null,
            Vision = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Capabilities
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
        };

        Capabilities copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DefaultsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };

        long expectedMaxOutputTokens = 0;
        double expectedTemperature = 0;
        long expectedTopK = 0;
        double expectedTopP = 0;

        Assert.Equal(expectedMaxOutputTokens, model.MaxOutputTokens);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopP, model.TopP);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Defaults>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Defaults>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxOutputTokens = 0;
        double expectedTemperature = 0;
        long expectedTopK = 0;
        double expectedTopP = 0;

        Assert.Equal(expectedMaxOutputTokens, deserialized.MaxOutputTokens);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedTopK, deserialized.TopK);
        Assert.Equal(expectedTopP, deserialized.TopP);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Defaults { };

        Assert.Null(model.MaxOutputTokens);
        Assert.False(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Defaults { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = null,
            Temperature = null,
            TopK = null,
            TopP = null,
        };

        Assert.Null(model.MaxOutputTokens);
        Assert.True(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.TopK);
        Assert.True(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.True(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = null,
            Temperature = null,
            TopK = null,
            TopP = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Defaults
        {
            MaxOutputTokens = 0,
            Temperature = 0,
            TopK = 0,
            TopP = 0,
        };

        Defaults copied = new(model);

        Assert.Equal(model, copied);
    }
}
