using System;
using DedalusSdk.Models.Models;

namespace DedalusSdk.Tests.Models.Models;

public class ModelRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ModelRetrieveParams { ModelID = "model_id" };

        string expectedModelID = "model_id";

        Assert.Equal(expectedModelID, parameters.ModelID);
    }

    [Fact]
    public void Url_Works()
    {
        ModelRetrieveParams parameters = new() { ModelID = "model_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.dedaluslabs.ai/v1/models/model_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ModelRetrieveParams { ModelID = "model_id" };

        ModelRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
