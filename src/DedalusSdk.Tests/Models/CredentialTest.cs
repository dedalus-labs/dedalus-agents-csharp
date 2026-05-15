using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class CredentialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credential
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };

        string expectedConnectionName = "connection_name";
        Dictionary<string, CredentialValue> expectedValues = new() { { "foo", "string" } };

        Assert.Equal(expectedConnectionName, model.ConnectionName);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        foreach (var item in expectedValues)
        {
            Assert.True(model.Values.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Values[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credential
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credential>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credential
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credential>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectionName = "connection_name";
        Dictionary<string, CredentialValue> expectedValues = new() { { "foo", "string" } };

        Assert.Equal(expectedConnectionName, deserialized.ConnectionName);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        foreach (var item in expectedValues)
        {
            Assert.True(deserialized.Values.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Values[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credential
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credential
        {
            ConnectionName = "connection_name",
            Values = new Dictionary<string, CredentialValue>() { { "foo", "string" } },
        };

        Credential copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CredentialValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        CredentialValue value = "string";
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        CredentialValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CredentialValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CredentialValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CredentialValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        CredentialValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CredentialValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CredentialValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CredentialValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
