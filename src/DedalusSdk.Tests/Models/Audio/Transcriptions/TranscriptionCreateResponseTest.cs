using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Transcriptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Audio.Transcriptions;

public class TranscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void CreateTranscriptionResponseVerboseJsonValidationWorks()
    {
        TranscriptionCreateResponse value = new CreateTranscriptionResponseVerboseJson()
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void CreateTranscriptionResponseJsonValidationWorks()
    {
        TranscriptionCreateResponse value = new CreateTranscriptionResponseJson()
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };
        value.Validate();
    }

    [Fact]
    public void CreateTranscriptionResponseVerboseJsonSerializationRoundtripWorks()
    {
        TranscriptionCreateResponse value = new CreateTranscriptionResponseVerboseJson()
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreateTranscriptionResponseJsonSerializationRoundtripWorks()
    {
        TranscriptionCreateResponse value = new CreateTranscriptionResponseJson()
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateTranscriptionResponseVerboseJsonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };

        double expectedDuration = 0;
        string expectedLanguage = "language";
        string expectedText = "text";
        List<Segment> expectedSegments =
        [
            new()
            {
                ID = 0,
                AvgLogprob = 0,
                CompressionRatio = 0,
                End = 0,
                NoSpeechProb = 0,
                Seek = 0,
                Start = 0,
                Temperature = 0,
                Text = "text",
                Tokens = [0],
            },
        ];
        Usage expectedUsage = new(0);
        List<Word> expectedWords =
        [
            new()
            {
                End = 0,
                Start = 0,
                WordValue = "word",
            },
        ];

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedText, model.Text);
        Assert.NotNull(model.Segments);
        Assert.Equal(expectedSegments.Count, model.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], model.Segments[i]);
        }
        Assert.Equal(expectedUsage, model.Usage);
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseVerboseJson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseVerboseJson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        string expectedLanguage = "language";
        string expectedText = "text";
        List<Segment> expectedSegments =
        [
            new()
            {
                ID = 0,
                AvgLogprob = 0,
                CompressionRatio = 0,
                End = 0,
                NoSpeechProb = 0,
                Seek = 0,
                Start = 0,
                Temperature = 0,
                Text = "text",
                Tokens = [0],
            },
        ];
        Usage expectedUsage = new(0);
        List<Word> expectedWords =
        [
            new()
            {
                End = 0,
                Start = 0,
                WordValue = "word",
            },
        ];

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.NotNull(deserialized.Segments);
        Assert.Equal(expectedSegments.Count, deserialized.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], deserialized.Segments[i]);
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
        };

        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Segments = null,
            Usage = null,
            Words = null,
        };

        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Segments = null,
            Usage = null,
            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateTranscriptionResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
            Segments =
            [
                new()
                {
                    ID = 0,
                    AvgLogprob = 0,
                    CompressionRatio = 0,
                    End = 0,
                    NoSpeechProb = 0,
                    Seek = 0,
                    Start = 0,
                    Temperature = 0,
                    Text = "text",
                    Tokens = [0],
                },
            ],
            Usage = new(0),
            Words =
            [
                new()
                {
                    End = 0,
                    Start = 0,
                    WordValue = "word",
                },
            ],
        };

        CreateTranscriptionResponseVerboseJson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SegmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Segment
        {
            ID = 0,
            AvgLogprob = 0,
            CompressionRatio = 0,
            End = 0,
            NoSpeechProb = 0,
            Seek = 0,
            Start = 0,
            Temperature = 0,
            Text = "text",
            Tokens = [0],
        };

        long expectedID = 0;
        double expectedAvgLogprob = 0;
        double expectedCompressionRatio = 0;
        double expectedEnd = 0;
        double expectedNoSpeechProb = 0;
        long expectedSeek = 0;
        double expectedStart = 0;
        double expectedTemperature = 0;
        string expectedText = "text";
        List<long> expectedTokens = [0];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAvgLogprob, model.AvgLogprob);
        Assert.Equal(expectedCompressionRatio, model.CompressionRatio);
        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedNoSpeechProb, model.NoSpeechProb);
        Assert.Equal(expectedSeek, model.Seek);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTokens.Count, model.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], model.Tokens[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Segment
        {
            ID = 0,
            AvgLogprob = 0,
            CompressionRatio = 0,
            End = 0,
            NoSpeechProb = 0,
            Seek = 0,
            Start = 0,
            Temperature = 0,
            Text = "text",
            Tokens = [0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Segment>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Segment
        {
            ID = 0,
            AvgLogprob = 0,
            CompressionRatio = 0,
            End = 0,
            NoSpeechProb = 0,
            Seek = 0,
            Start = 0,
            Temperature = 0,
            Text = "text",
            Tokens = [0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Segment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 0;
        double expectedAvgLogprob = 0;
        double expectedCompressionRatio = 0;
        double expectedEnd = 0;
        double expectedNoSpeechProb = 0;
        long expectedSeek = 0;
        double expectedStart = 0;
        double expectedTemperature = 0;
        string expectedText = "text";
        List<long> expectedTokens = [0];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAvgLogprob, deserialized.AvgLogprob);
        Assert.Equal(expectedCompressionRatio, deserialized.CompressionRatio);
        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedNoSpeechProb, deserialized.NoSpeechProb);
        Assert.Equal(expectedSeek, deserialized.Seek);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTokens.Count, deserialized.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], deserialized.Tokens[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Segment
        {
            ID = 0,
            AvgLogprob = 0,
            CompressionRatio = 0,
            End = 0,
            NoSpeechProb = 0,
            Seek = 0,
            Start = 0,
            Temperature = 0,
            Text = "text",
            Tokens = [0],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Segment
        {
            ID = 0,
            AvgLogprob = 0,
            CompressionRatio = 0,
            End = 0,
            NoSpeechProb = 0,
            Seek = 0,
            Start = 0,
            Temperature = 0,
            Text = "text",
            Tokens = [0],
        };

        Segment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage { Seconds = 0 };

        double expectedSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("duration");

        Assert.Equal(expectedSeconds, model.Seconds);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage { Seconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage { Seconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("duration");

        Assert.Equal(expectedSeconds, deserialized.Seconds);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage { Seconds = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage { Seconds = 0 };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Word
        {
            End = 0,
            Start = 0,
            WordValue = "word",
        };

        double expectedEnd = 0;
        double expectedStart = 0;
        string expectedWordValue = "word";

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedWordValue, model.WordValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Word
        {
            End = 0,
            Start = 0,
            WordValue = "word",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Word>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Word
        {
            End = 0,
            Start = 0,
            WordValue = "word",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Word>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedEnd = 0;
        double expectedStart = 0;
        string expectedWordValue = "word";

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedWordValue, deserialized.WordValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Word
        {
            End = 0,
            Start = 0,
            WordValue = "word",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Word
        {
            End = 0,
            Start = 0,
            WordValue = "word",
        };

        Word copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateTranscriptionResponseJsonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };

        string expectedText = "text";
        List<Logprob> expectedLogprobs =
        [
            new()
            {
                Token = "token",
                Bytes = [0],
                LogprobValue = 0,
            },
        ];
        CreateTranscriptionResponseJsonUsage expectedUsage = new Tokens()
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        Assert.Equal(expectedText, model.Text);
        Assert.NotNull(model.Logprobs);
        Assert.Equal(expectedLogprobs.Count, model.Logprobs.Count);
        for (int i = 0; i < expectedLogprobs.Count; i++)
        {
            Assert.Equal(expectedLogprobs[i], model.Logprobs[i]);
        }
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseJson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseJson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        List<Logprob> expectedLogprobs =
        [
            new()
            {
                Token = "token",
                Bytes = [0],
                LogprobValue = 0,
            },
        ];
        CreateTranscriptionResponseJsonUsage expectedUsage = new Tokens()
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        Assert.Equal(expectedText, deserialized.Text);
        Assert.NotNull(deserialized.Logprobs);
        Assert.Equal(expectedLogprobs.Count, deserialized.Logprobs.Count);
        for (int i = 0; i < expectedLogprobs.Count; i++)
        {
            Assert.Equal(expectedLogprobs[i], deserialized.Logprobs[i]);
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateTranscriptionResponseJson { Text = "text" };

        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateTranscriptionResponseJson { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Logprobs = null,
            Usage = null,
        };

        Assert.Null(model.Logprobs);
        Assert.False(model.RawData.ContainsKey("logprobs"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Logprobs = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateTranscriptionResponseJson
        {
            Text = "text",
            Logprobs =
            [
                new()
                {
                    Token = "token",
                    Bytes = [0],
                    LogprobValue = 0,
                },
            ],
            Usage = new Tokens()
            {
                InputTokens = 0,
                OutputTokens = 0,
                TotalTokens = 0,
                InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
            },
        };

        CreateTranscriptionResponseJson copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LogprobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Logprob
        {
            Token = "token",
            Bytes = [0],
            LogprobValue = 0,
        };

        string expectedToken = "token";
        List<double> expectedBytes = [0];
        double expectedLogprobValue = 0;

        Assert.Equal(expectedToken, model.Token);
        Assert.NotNull(model.Bytes);
        Assert.Equal(expectedBytes.Count, model.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], model.Bytes[i]);
        }
        Assert.Equal(expectedLogprobValue, model.LogprobValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Logprob
        {
            Token = "token",
            Bytes = [0],
            LogprobValue = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Logprob>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Logprob
        {
            Token = "token",
            Bytes = [0],
            LogprobValue = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Logprob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        List<double> expectedBytes = [0];
        double expectedLogprobValue = 0;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.NotNull(deserialized.Bytes);
        Assert.Equal(expectedBytes.Count, deserialized.Bytes.Count);
        for (int i = 0; i < expectedBytes.Count; i++)
        {
            Assert.Equal(expectedBytes[i], deserialized.Bytes[i]);
        }
        Assert.Equal(expectedLogprobValue, deserialized.LogprobValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Logprob
        {
            Token = "token",
            Bytes = [0],
            LogprobValue = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Logprob { };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.Bytes);
        Assert.False(model.RawData.ContainsKey("bytes"));
        Assert.Null(model.LogprobValue);
        Assert.False(model.RawData.ContainsKey("logprob"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Logprob { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Logprob
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            Bytes = null,
            LogprobValue = null,
        };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.Bytes);
        Assert.False(model.RawData.ContainsKey("bytes"));
        Assert.Null(model.LogprobValue);
        Assert.False(model.RawData.ContainsKey("logprob"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Logprob
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            Bytes = null,
            LogprobValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Logprob
        {
            Token = "token",
            Bytes = [0],
            LogprobValue = 0,
        };

        Logprob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateTranscriptionResponseJsonUsageTest : TestBase
{
    [Fact]
    public void TokensValidationWorks()
    {
        CreateTranscriptionResponseJsonUsage value = new Tokens()
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };
        value.Validate();
    }

    [Fact]
    public void DurationValidationWorks()
    {
        CreateTranscriptionResponseJsonUsage value = new Duration(0);
        value.Validate();
    }

    [Fact]
    public void TokensSerializationRoundtripWorks()
    {
        CreateTranscriptionResponseJsonUsage value = new Tokens()
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseJsonUsage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DurationSerializationRoundtripWorks()
    {
        CreateTranscriptionResponseJsonUsage value = new Duration(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseJsonUsage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TokensTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        long expectedInputTokens = 0;
        long expectedOutputTokens = 0;
        long expectedTotalTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("tokens");
        InputTokenDetails expectedInputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 };

        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedInputTokenDetails, model.InputTokenDetails);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tokens>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tokens>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedInputTokens = 0;
        long expectedOutputTokens = 0;
        long expectedTotalTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("tokens");
        InputTokenDetails expectedInputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 };

        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedInputTokenDetails, deserialized.InputTokenDetails);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
        };

        Assert.Null(model.InputTokenDetails);
        Assert.False(model.RawData.ContainsKey("input_token_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            InputTokenDetails = null,
        };

        Assert.Null(model.InputTokenDetails);
        Assert.False(model.RawData.ContainsKey("input_token_details"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,

            // Null should be interpreted as omitted for these properties
            InputTokenDetails = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tokens
        {
            InputTokens = 0,
            OutputTokens = 0,
            TotalTokens = 0,
            InputTokenDetails = new() { AudioTokens = 0, TextTokens = 0 },
        };

        Tokens copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Duration { Seconds = 0 };

        double expectedSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("duration");

        Assert.Equal(expectedSeconds, model.Seconds);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Duration { Seconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Duration>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Duration { Seconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Duration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("duration");

        Assert.Equal(expectedSeconds, deserialized.Seconds);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Duration { Seconds = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Duration { Seconds = 0 };

        Duration copied = new(model);

        Assert.Equal(model, copied);
    }
}
