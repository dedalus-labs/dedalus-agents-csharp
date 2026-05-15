using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = "string";
        value.Validate();
    }

    [Fact]
    public void McpServerSpecValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerSpecSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = new McpServerSpec()
        {
            Name = "name",
            Credentials = new Dictionary<string, string>() { { "foo", "string" } },
            Slug = "_1K--W2kIFj1/_-Mtu--_-p",
            Url = "url",
            Version = "version",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
