using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;

namespace DedalusSdk.Tests.Models;

public class McpToolResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
            DurationMs = 0,
            Result = "string",
        };

        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        bool expectedIsError = true;
        string expectedServerName = "server_name";
        string expectedToolName = "tool_name";
        long expectedDurationMs = 0;
        JsonValueInput expectedResult = "string";

        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Arguments[item.Key]);
        }
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedServerName, model.ServerName);
        Assert.Equal(expectedToolName, model.ToolName);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
            DurationMs = 0,
            Result = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpToolResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
            DurationMs = 0,
            Result = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpToolResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        bool expectedIsError = true;
        string expectedServerName = "server_name";
        string expectedToolName = "tool_name";
        long expectedDurationMs = 0;
        JsonValueInput expectedResult = "string";

        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Arguments[item.Key]);
        }
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedServerName, deserialized.ServerName);
        Assert.Equal(expectedToolName, deserialized.ToolName);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
            DurationMs = 0,
            Result = "string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
        };

        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",

            DurationMs = null,
            Result = null,
        };

        Assert.Null(model.DurationMs);
        Assert.True(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",

            DurationMs = null,
            Result = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpToolResult
        {
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            IsError = true,
            ServerName = "server_name",
            ToolName = "tool_name",
            DurationMs = 0,
            Result = "string",
        };

        McpToolResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
