using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class ReasoningTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Reasoning
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };

        ApiEnum<string, Effort> expectedEffort = Effort.None;
        ApiEnum<string, GenerateSummary> expectedGenerateSummary = GenerateSummary.Auto;
        ApiEnum<string, Summary> expectedSummary = Summary.Auto;

        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedGenerateSummary, model.GenerateSummary);
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Reasoning
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reasoning>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Reasoning
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reasoning>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Effort> expectedEffort = Effort.None;
        ApiEnum<string, GenerateSummary> expectedGenerateSummary = GenerateSummary.Auto;
        ApiEnum<string, Summary> expectedSummary = Summary.Auto;

        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedGenerateSummary, deserialized.GenerateSummary);
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Reasoning
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Reasoning { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.GenerateSummary);
        Assert.False(model.RawData.ContainsKey("generate_summary"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Reasoning { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Reasoning
        {
            Effort = null,
            GenerateSummary = null,
            Summary = null,
        };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
        Assert.Null(model.GenerateSummary);
        Assert.True(model.RawData.ContainsKey("generate_summary"));
        Assert.Null(model.Summary);
        Assert.True(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Reasoning
        {
            Effort = null,
            GenerateSummary = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Reasoning
        {
            Effort = Effort.None,
            GenerateSummary = GenerateSummary.Auto,
            Summary = Summary.Auto,
        };

        Reasoning copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EffortTest : TestBase
{
    [Theory]
    [InlineData(Effort.None)]
    [InlineData(Effort.Minimal)]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Xhigh)]
    public void Validation_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Effort.None)]
    [InlineData(Effort.Minimal)]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Xhigh)]
    public void SerializationRoundtrip_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GenerateSummaryTest : TestBase
{
    [Theory]
    [InlineData(GenerateSummary.Auto)]
    [InlineData(GenerateSummary.Concise)]
    [InlineData(GenerateSummary.Detailed)]
    public void Validation_Works(GenerateSummary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GenerateSummary> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GenerateSummary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GenerateSummary.Auto)]
    [InlineData(GenerateSummary.Concise)]
    [InlineData(GenerateSummary.Detailed)]
    public void SerializationRoundtrip_Works(GenerateSummary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GenerateSummary> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GenerateSummary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GenerateSummary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GenerateSummary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SummaryTest : TestBase
{
    [Theory]
    [InlineData(Summary.Auto)]
    [InlineData(Summary.Concise)]
    [InlineData(Summary.Detailed)]
    public void Validation_Works(Summary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Summary> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Summary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Summary.Auto)]
    [InlineData(Summary.Concise)]
    [InlineData(Summary.Detailed)]
    public void SerializationRoundtrip_Works(Summary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Summary> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Summary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Summary>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Summary>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
