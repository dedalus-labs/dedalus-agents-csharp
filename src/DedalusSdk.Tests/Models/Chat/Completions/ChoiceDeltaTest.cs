using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class ChoiceDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        string expectedContent = "content";
        ChoiceDeltaFunctionCall expectedFunctionCall = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        string expectedRefusal = "refusal";
        ApiEnum<string, Role> expectedRole = Role.Developer;
        List<ChoiceDeltaToolCall> expectedToolCalls =
        [
            new()
            {
                Index = 0,
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                Type = ChoiceDeltaToolCallType.Function,
            },
        ];

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFunctionCall, model.FunctionCall);
        Assert.Equal(expectedRefusal, model.Refusal);
        Assert.Equal(expectedRole, model.Role);
        Assert.NotNull(model.ToolCalls);
        Assert.Equal(expectedToolCalls.Count, model.ToolCalls.Count);
        for (int i = 0; i < expectedToolCalls.Count; i++)
        {
            Assert.Equal(expectedToolCalls[i], model.ToolCalls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ChoiceDeltaFunctionCall expectedFunctionCall = new()
        {
            Arguments = "arguments",
            Name = "name",
        };
        string expectedRefusal = "refusal";
        ApiEnum<string, Role> expectedRole = Role.Developer;
        List<ChoiceDeltaToolCall> expectedToolCalls =
        [
            new()
            {
                Index = 0,
                ID = "id",
                Function = new() { Arguments = "arguments", Name = "name" },
                Type = ChoiceDeltaToolCallType.Function,
            },
        ];

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFunctionCall, deserialized.FunctionCall);
        Assert.Equal(expectedRefusal, deserialized.Refusal);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.NotNull(deserialized.ToolCalls);
        Assert.Equal(expectedToolCalls.Count, deserialized.ToolCalls.Count);
        for (int i = 0; i < expectedToolCalls.Count; i++)
        {
            Assert.Equal(expectedToolCalls[i], deserialized.ToolCalls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceDelta { Content = "content", Refusal = "refusal" };

        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceDelta { Content = "content", Refusal = "refusal" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            Refusal = "refusal",

            // Null should be interpreted as omitted for these properties
            FunctionCall = null,
            Role = null,
            ToolCalls = null,
        };

        Assert.Null(model.FunctionCall);
        Assert.False(model.RawData.ContainsKey("function_call"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("tool_calls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            Refusal = "refusal",

            // Null should be interpreted as omitted for these properties
            FunctionCall = null,
            Role = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceDelta
        {
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Refusal);
        Assert.False(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceDelta
        {
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChoiceDelta
        {
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],

            Content = null,
            Refusal = null,
        };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Refusal);
        Assert.True(model.RawData.ContainsKey("refusal"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceDelta
        {
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],

            Content = null,
            Refusal = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChoiceDelta
        {
            Content = "content",
            FunctionCall = new() { Arguments = "arguments", Name = "name" },
            Refusal = "refusal",
            Role = Role.Developer,
            ToolCalls =
            [
                new()
                {
                    Index = 0,
                    ID = "id",
                    Function = new() { Arguments = "arguments", Name = "name" },
                    Type = ChoiceDeltaToolCallType.Function,
                },
            ],
        };

        ChoiceDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChoiceDeltaFunctionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChoiceDeltaFunctionCall { Arguments = "arguments", Name = "name" };

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChoiceDeltaFunctionCall { Arguments = "arguments", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaFunctionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChoiceDeltaFunctionCall { Arguments = "arguments", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChoiceDeltaFunctionCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArguments = "arguments";
        string expectedName = "name";

        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChoiceDeltaFunctionCall { Arguments = "arguments", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChoiceDeltaFunctionCall { };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChoiceDeltaFunctionCall { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChoiceDeltaFunctionCall
        {
            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Name = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChoiceDeltaFunctionCall
        {
            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChoiceDeltaFunctionCall { Arguments = "arguments", Name = "name" };

        ChoiceDeltaFunctionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Developer)]
    [InlineData(Role.System)]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.Tool)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Developer)]
    [InlineData(Role.System)]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.Tool)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
