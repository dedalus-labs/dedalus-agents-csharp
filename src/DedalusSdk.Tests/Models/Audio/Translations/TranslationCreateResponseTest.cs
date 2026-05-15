using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Translations;

namespace DedalusSdk.Tests.Models.Audio.Translations;

public class TranslationCreateResponseTest : TestBase
{
    [Fact]
    public void CreateTranslationResponseVerboseJsonValidationWorks()
    {
        TranslationCreateResponse value = new CreateTranslationResponseVerboseJson()
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
        };
        value.Validate();
    }

    [Fact]
    public void CreateTranslationResponseJsonValidationWorks()
    {
        TranslationCreateResponse value = new CreateTranslationResponseJson("text");
        value.Validate();
    }

    [Fact]
    public void CreateTranslationResponseVerboseJsonSerializationRoundtripWorks()
    {
        TranslationCreateResponse value = new CreateTranslationResponseVerboseJson()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranslationCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreateTranslationResponseJsonSerializationRoundtripWorks()
    {
        TranslationCreateResponse value = new CreateTranslationResponseJson("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranslationCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateTranslationResponseVerboseJsonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedText, model.Text);
        Assert.NotNull(model.Segments);
        Assert.Equal(expectedSegments.Count, model.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], model.Segments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseVerboseJson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseVerboseJson>(
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

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.NotNull(deserialized.Segments);
        Assert.Equal(expectedSegments.Count, deserialized.Segments.Count);
        for (int i = 0; i < expectedSegments.Count; i++)
        {
            Assert.Equal(expectedSegments[i], deserialized.Segments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",
        };

        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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
        var model = new CreateTranslationResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Segments = null,
        };

        Assert.Null(model.Segments);
        Assert.False(model.RawData.ContainsKey("segments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
        {
            Duration = 0,
            Language = "language",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Segments = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateTranslationResponseVerboseJson
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
        };

        CreateTranslationResponseVerboseJson copied = new(model);

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

public class CreateTranslationResponseJsonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateTranslationResponseJson { Text = "text" };

        string expectedText = "text";

        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateTranslationResponseJson { Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseJson>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateTranslationResponseJson { Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseJson>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";

        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateTranslationResponseJson { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateTranslationResponseJson { Text = "text" };

        CreateTranslationResponseJson copied = new(model);

        Assert.Equal(model, copied);
    }
}
