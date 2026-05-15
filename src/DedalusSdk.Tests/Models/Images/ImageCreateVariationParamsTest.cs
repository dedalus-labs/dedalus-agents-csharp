using System;
using System.Text;
using DedalusSdk.Core;
using DedalusSdk.Models.Images;

namespace DedalusSdk.Tests.Models.Images;

public class ImageCreateVariationParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new ImageCreateVariationParams
        {
            Image = image,
            Model = "model",
            N = 0,
            ResponseFormat = "response_format",
            Size = "size",
            User = "user",
        };

        BinaryContent expectedImage = image;
        string expectedModel = "model";
        long expectedN = 0;
        string expectedResponseFormat = "response_format";
        string expectedSize = "size";
        string expectedUser = "user";

        Assert.Equal(expectedImage, parameters.Image);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedN, parameters.N);
        Assert.Equal(expectedResponseFormat, parameters.ResponseFormat);
        Assert.Equal(expectedSize, parameters.Size);
        Assert.Equal(expectedUser, parameters.User);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new ImageCreateVariationParams { Image = image };

        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.N);
        Assert.False(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.ResponseFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Size);
        Assert.False(parameters.RawBodyData.ContainsKey("size"));
        Assert.Null(parameters.User);
        Assert.False(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new ImageCreateVariationParams
        {
            Image = image,

            Model = null,
            N = null,
            ResponseFormat = null,
            Size = null,
            User = null,
        };

        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.N);
        Assert.True(parameters.RawBodyData.ContainsKey("n"));
        Assert.Null(parameters.ResponseFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("response_format"));
        Assert.Null(parameters.Size);
        Assert.True(parameters.RawBodyData.ContainsKey("size"));
        Assert.Null(parameters.User);
        Assert.True(parameters.RawBodyData.ContainsKey("user"));
    }

    [Fact]
    public void Url_Works()
    {
        ImageCreateVariationParams parameters = new()
        {
            Image = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/images/variations"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageCreateVariationParams
        {
            Image = Encoding.UTF8.GetBytes("Example data"),
            Model = "model",
            N = 0,
            ResponseFormat = "response_format",
            Size = "size",
            User = "user",
        };

        ImageCreateVariationParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
