using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Tests.Models.Embeddings;

public class CreateEmbeddingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateEmbeddingResponse
        {
            Data = [new() { Embedding = [0], Index = 0 }],
            Model = "model",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        List<Data> expectedData = [new() { Embedding = [0], Index = 0 }];
        string expectedModel = "model";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("list");
        Usage expectedUsage = new() { PromptTokens = 0, TotalTokens = 0 };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateEmbeddingResponse
        {
            Data = [new() { Embedding = [0], Index = 0 }],
            Model = "model",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateEmbeddingResponse
        {
            Data = [new() { Embedding = [0], Index = 0 }],
            Model = "model",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateEmbeddingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData = [new() { Embedding = [0], Index = 0 }];
        string expectedModel = "model";
        JsonElement expectedObject = JsonSerializer.SerializeToElement("list");
        Usage expectedUsage = new() { PromptTokens = 0, TotalTokens = 0 };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateEmbeddingResponse
        {
            Data = [new() { Embedding = [0], Index = 0 }],
            Model = "model",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateEmbeddingResponse
        {
            Data = [new() { Embedding = [0], Index = 0 }],
            Model = "model",
            Usage = new() { PromptTokens = 0, TotalTokens = 0 },
        };

        CreateEmbeddingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data { Embedding = [0], Index = 0 };

        List<double> expectedEmbedding = [0];
        long expectedIndex = 0;
        JsonElement expectedObject = JsonSerializer.SerializeToElement("embedding");

        Assert.Equal(expectedEmbedding.Count, model.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], model.Embedding[i]);
        }
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data { Embedding = [0], Index = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data { Embedding = [0], Index = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<double> expectedEmbedding = [0];
        long expectedIndex = 0;
        JsonElement expectedObject = JsonSerializer.SerializeToElement("embedding");

        Assert.Equal(expectedEmbedding.Count, deserialized.Embedding.Count);
        for (int i = 0; i < expectedEmbedding.Count; i++)
        {
            Assert.Equal(expectedEmbedding[i], deserialized.Embedding[i]);
        }
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data { Embedding = [0], Index = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data { Embedding = [0], Index = 0 };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedPromptTokens, model.PromptTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedPromptTokens = 0;
        long expectedTotalTokens = 0;

        Assert.Equal(expectedPromptTokens, deserialized.PromptTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage { PromptTokens = 0, TotalTokens = 0 };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}
