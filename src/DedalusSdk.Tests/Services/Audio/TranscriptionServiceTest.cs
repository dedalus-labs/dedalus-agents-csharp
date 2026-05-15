using System.Text;
using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services.Audio;

public class TranscriptionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var transcription = await this.client.Audio.Transcriptions.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), Model = "model" },
            TestContext.Current.CancellationToken
        );
        transcription.Validate();
    }
}
