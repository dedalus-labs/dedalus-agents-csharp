using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class StreamChoiceLogprobsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamChoiceLogprobs
        {
            Content =
            [
                new()
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
                },
            ],
            Refusal =
            [
                new()
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
                },
            ],
        };

        List<ChatCompletionTokenLogprob> expectedContent =
        [
            new()
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
            },
        ];
        List<ChatCompletionTokenLogprob> expectedRefusal =
        [
            new()
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
            },
        ];

        Assert.NotNull(model.Content);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.NotNull(model.Refusal);
        Assert.Equal(expectedRefusal.Count, model.Refusal.Count);
        for (int i = 0; i < expectedRefusal.Count; i++)
        {
            Assert.Equal(expectedRefusal[i], model.Refusal[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamChoiceLogprobs
        {
            Content =
            [
                new()
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
                },
            ],
            Refusal =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StreamChoiceLogprobs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamChoiceLogprobs
        {
            Content =
            [
                new()
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
                },
            ],
            Refusal =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StreamChoiceLogprobs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ChatCompletionTokenLogprob> expectedContent =
        [
            new()
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
            },
        ];
        List<ChatCompletionTokenLogprob> expectedRefusal =
        [
            new()
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
            },
        ];

        Assert.NotNull(deserialized.Content);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.NotNull(deserialized.Refusal);
        Assert.Equal(expectedRefusal.Count, deserialized.Refusal.Count);
        for (int i = 0; i < expectedRefusal.Count; i++)
        {
            Assert.Equal(expectedRefusal[i], deserialized.Refusal[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamChoiceLogprobs
        {
            Content =
            [
                new()
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
                },
            ],
            Refusal =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StreamChoiceLogprobs
        {
            Content =
            [
                new()
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
                },
            ],
            Refusal =
            [
                new()
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
                },
            ],
        };

        StreamChoiceLogprobs copied = new(model);

        Assert.Equal(model, copied);
    }
}
