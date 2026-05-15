using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Tests.Models.Images;

public class ImagesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImagesResponse
        {
            Created = 0,
            Data =
            [
                new()
                {
                    B64Json = "b64_json",
                    RevisedPrompt = "revised_prompt",
                    Url = "url",
                },
            ],
        };

        long expectedCreated = 0;
        List<Image> expectedData =
        [
            new()
            {
                B64Json = "b64_json",
                RevisedPrompt = "revised_prompt",
                Url = "url",
            },
        ];

        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImagesResponse
        {
            Created = 0,
            Data =
            [
                new()
                {
                    B64Json = "b64_json",
                    RevisedPrompt = "revised_prompt",
                    Url = "url",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImagesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImagesResponse
        {
            Created = 0,
            Data =
            [
                new()
                {
                    B64Json = "b64_json",
                    RevisedPrompt = "revised_prompt",
                    Url = "url",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImagesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCreated = 0;
        List<Image> expectedData =
        [
            new()
            {
                B64Json = "b64_json",
                RevisedPrompt = "revised_prompt",
                Url = "url",
            },
        ];

        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImagesResponse
        {
            Created = 0,
            Data =
            [
                new()
                {
                    B64Json = "b64_json",
                    RevisedPrompt = "revised_prompt",
                    Url = "url",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImagesResponse
        {
            Created = 0,
            Data =
            [
                new()
                {
                    B64Json = "b64_json",
                    RevisedPrompt = "revised_prompt",
                    Url = "url",
                },
            ],
        };

        ImagesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
