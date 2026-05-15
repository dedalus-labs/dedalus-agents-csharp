using System.Collections.Generic;
using System.Text.Json;
using DedalusSdk.Core;
using DedalusSdk.Models;
using DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Tests.Models.Chat.Completions;

public class DeferredCallResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            BlockedBy = ["string"],
            Dependencies = ["string"],
            Venue = "venue",
        };

        string expectedID = "id";
        string expectedName = "name";
        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        List<string> expectedBlockedBy = ["string"];
        List<string> expectedDependencies = ["string"];
        string expectedVenue = "venue";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Arguments);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Arguments[item.Key]);
        }
        Assert.NotNull(model.BlockedBy);
        Assert.Equal(expectedBlockedBy.Count, model.BlockedBy.Count);
        for (int i = 0; i < expectedBlockedBy.Count; i++)
        {
            Assert.Equal(expectedBlockedBy[i], model.BlockedBy[i]);
        }
        Assert.NotNull(model.Dependencies);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], model.Dependencies[i]);
        }
        Assert.Equal(expectedVenue, model.Venue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            BlockedBy = ["string"],
            Dependencies = ["string"],
            Venue = "venue",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeferredCallResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            BlockedBy = ["string"],
            Dependencies = ["string"],
            Venue = "venue",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeferredCallResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        Dictionary<string, JsonValueInput?> expectedArguments = new() { { "foo", "string" } };
        List<string> expectedBlockedBy = ["string"];
        List<string> expectedDependencies = ["string"];
        string expectedVenue = "venue";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Arguments);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Arguments[item.Key]);
        }
        Assert.NotNull(deserialized.BlockedBy);
        Assert.Equal(expectedBlockedBy.Count, deserialized.BlockedBy.Count);
        for (int i = 0; i < expectedBlockedBy.Count; i++)
        {
            Assert.Equal(expectedBlockedBy[i], deserialized.BlockedBy[i]);
        }
        Assert.NotNull(deserialized.Dependencies);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], deserialized.Dependencies[i]);
        }
        Assert.Equal(expectedVenue, deserialized.Venue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            BlockedBy = ["string"],
            Dependencies = ["string"],
            Venue = "venue",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeferredCallResponse { ID = "id", Name = "name" };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.BlockedBy);
        Assert.False(model.RawData.ContainsKey("blocked_by"));
        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
        Assert.Null(model.Venue);
        Assert.False(model.RawData.ContainsKey("venue"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeferredCallResponse { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            BlockedBy = null,
            Dependencies = null,
            Venue = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.BlockedBy);
        Assert.False(model.RawData.ContainsKey("blocked_by"));
        Assert.Null(model.Dependencies);
        Assert.False(model.RawData.ContainsKey("dependencies"));
        Assert.Null(model.Venue);
        Assert.False(model.RawData.ContainsKey("venue"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            BlockedBy = null,
            Dependencies = null,
            Venue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeferredCallResponse
        {
            ID = "id",
            Name = "name",
            Arguments = new Dictionary<string, JsonValueInput?>() { { "foo", "string" } },
            BlockedBy = ["string"],
            Dependencies = ["string"],
            Venue = "venue",
        };

        DeferredCallResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
