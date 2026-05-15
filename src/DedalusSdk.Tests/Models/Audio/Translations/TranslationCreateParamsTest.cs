using System;
using System.Text;
using DedalusSdk.Core;
using DedalusSdk.Models.Audio.Translations;

namespace DedalusSdk.Tests.Models.Audio.Translations;

public class TranslationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new TranslationCreateParams
        {
            File = file,
            Model = "model",
            Prompt = "prompt",
            ResponseFormat = "response_format",
            Temperature = 0,
        };

        BinaryContent expectedFile = file;
        string expectedModel = "model";
        string expectedPrompt = "prompt";
        string expectedResponseFormat = "response_format";
        double expectedTemperature = 0;

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedPrompt, parameters.Prompt);
        Assert.Equal(expectedResponseFormat, parameters.ResponseFormat);
        Assert.Equal(expectedTemperature, parameters.Temperature);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new TranslationCreateParams { File = file, Model = "model" };

        Assert.Null(parameters.Prompt);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new TranslationCreateParams
        {
            File = file,
            Model = "model",

            Prompt = null,
            ResponseFormat = null,
            Temperature = null,
        };

        Assert.Null(parameters.Prompt);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt"));
        Assert.Null(parameters.ResponseFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Temperature);
        Assert.True(parameters.RawBodyData.ContainsKey("temperature"));
    }

    [Fact]
    public void Url_Works()
    {
        TranslationCreateParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Model = "model",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/audio/translations"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranslationCreateParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Model = "model",
            Prompt = "prompt",
            ResponseFormat = "response_format",
            Temperature = 0,
        };

        TranslationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
