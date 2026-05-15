using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services;

public class OcrServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Process_Works()
    {
        var ocrResponse = await this.client.Ocr.Process(
            new()
            {
                Document = new() { DocumentUrl = "document_url", Type = "type" },
            },
            TestContext.Current.CancellationToken
        );
        ocrResponse.Validate();
    }
}
