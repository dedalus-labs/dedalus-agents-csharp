using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class McpServerSpecTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };

        string expectedName = "name";
        Dictionary<string, string> expectedCredentials = new() { { "foo", "string" } };
        string expectedSlug = "_1K--W2kIFj1/_-Mtu--_-p";
        string expectedUrl = "url";
        string expectedVersion = "version";

        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Credentials);
        Assert.Equal(expectedCredentials.Count, model.Credentials.Count);
        foreach (var item in expectedCredentials)
        {
            Assert.True(model.Credentials.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Credentials[item.Key]);
        }
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerSpec>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerSpec>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        Dictionary<string, string> expectedCredentials = new() { { "foo", "string" } };
        string expectedSlug = "_1K--W2kIFj1/_-Mtu--_-p";
        string expectedUrl = "url";
        string expectedVersion = "version";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Credentials);
        Assert.Equal(expectedCredentials.Count, deserialized.Credentials.Count);
        foreach (var item in expectedCredentials)
        {
            Assert.True(deserialized.Credentials.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Credentials[item.Key]);
        }
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpServerSpec { Name = "name" };

        Assert.Null(model.Credentials);
        Assert.False(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpServerSpec { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",

            Credentials = null,
            Slug = null,
            Url = null,
            Version = null,
        };

        Assert.Null(model.Credentials);
        Assert.True(model.RawData.ContainsKey("credentials"));
        Assert.Null(model.Slug);
        Assert.True(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",

            Credentials = null,
            Slug = null,
            Url = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpServerSpec
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };

        McpServerSpec copied = new(model);

        Assert.Equal(model, copied);
    }
}
