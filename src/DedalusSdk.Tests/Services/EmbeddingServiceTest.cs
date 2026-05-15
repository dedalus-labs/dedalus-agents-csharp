using System.Threading.Tasks;
using DedalusSdk.Models.Embeddings;

namespace DedalusSdk.Tests.Services;

public class EmbeddingServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var createEmbeddingResponse = await this.client.Embeddings.Create(
            new() { Input = "string", Model = Model.TextEmbeddingAda002 },
            TestContext.Current.CancellationToken
        );
        createEmbeddingResponse.Validate();
    }
}
