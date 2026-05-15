using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services;

public class ResponseServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var response = await this.client.Responses.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
