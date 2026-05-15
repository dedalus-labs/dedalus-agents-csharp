using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChoiceLogprobsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceLogprobs
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
        var model = new ChoiceLogprobs
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
        var deserialized = JsonSerializer.Deserialize<ChoiceLogprobs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceLogprobs
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
        var deserialized = JsonSerializer.Deserialize<ChoiceLogprobs>(
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
        var model = new ChoiceLogprobs
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
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceLogprobs { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Refusal);
        Assert.False(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceLogprobs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChoiceLogprobs { Content = null, Refusal = null };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Refusal);
        Assert.True(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceLogprobs { Content = null, Refusal = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChoiceLogprobs
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

        ChoiceLogprobs copied = new(model);

        Assert.Equal(model, copied);
    }
}
