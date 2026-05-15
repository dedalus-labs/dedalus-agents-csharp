using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services;

public class ModelServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var model = await this.client.Models.Retrieve(
            "model_id",
            new(),
            TestContext.Current.CancellationToken
        );
        model.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var listModelsResponse = await this.client.Models.List(
            new(),
            TestContext.Current.CancellationToken
        );
        listModelsResponse.Validate();
    }
}
