using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChatCompletionTokenLogprobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCompletionTokenLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
            TopLogprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                },
            ],
        };

        string expectedToken = "token";
        List<long> expectedBytes = [0];
        double expectedLogprob = 0;
        List<TopLogprob> expectedTopLogprobs =
        [
            new()
            {
                Token = "token",
                Bytes = [0],
                Logprob = 0,
            },
        ];

        Assert.Equal(expectedToken, model.Token);
        Assert.NotNull(model.Bytes);
        Assert.Equal(expectedBytes.Count, model.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], model.Bytes[i]);
        }
        Assert.Equal(expectedLogprob, model.Logprob);
        Assert.Equal(expectedTopLogprobs.Count, model.TopLogprobs.Count);
        for (int i = 0; i < expectedTopLogprobs.Count; i++)
        {
            Assert.Equal(expectedTopLogprobs[i], model.TopLogprobs[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCompletionTokenLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
            TopLogprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionTokenLogprob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCompletionTokenLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
            TopLogprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCompletionTokenLogprob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        List<long> expectedBytes = [0];
        double expectedLogprob = 0;
        List<TopLogprob> expectedTopLogprobs =
        [
            new()
            {
                Token = "token",
                Bytes = [0],
                Logprob = 0,
            },
        ];

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.NotNull(deserialized.Bytes);
        Assert.Equal(expectedBytes.Count, deserialized.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], deserialized.Bytes[i]);
        }
        Assert.Equal(expectedLogprob, deserialized.Logprob);
        Assert.Equal(expectedTopLogprobs.Count, deserialized.TopLogprobs.Count);
        for (int i = 0; i < expectedTopLogprobs.Count; i++)
        {
            Assert.Equal(expectedTopLogprobs[i], deserialized.TopLogprobs[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCompletionTokenLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
            TopLogprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCompletionTokenLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
            TopLogprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    Logprob = 0,
                },
            ],
        };

        ChatCompletionTokenLogprob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TopLogprobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
        };

        string expectedToken = "token";
        List<long> expectedBytes = [0];
        double expectedLogprob = 0;

        Assert.Equal(expectedToken, model.Token);
        Assert.NotNull(model.Bytes);
        Assert.Equal(expectedBytes.Count, model.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], model.Bytes[i]);
        }
        Assert.Equal(expectedLogprob, model.Logprob);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopLogprob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopLogprob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        List<long> expectedBytes = [0];
        double expectedLogprob = 0;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.NotNull(deserialized.Bytes);
        Assert.Equal(expectedBytes.Count, deserialized.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], deserialized.Bytes[i]);
        }
        Assert.Equal(expectedLogprob, deserialized.Logprob);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopLogprob
        {
            Token = "token",
            Bytes = [0],
            Logprob = 0,
        };

        TopLogprob copied = new(model);

        Assert.Equal(model, copied);
    }
}
