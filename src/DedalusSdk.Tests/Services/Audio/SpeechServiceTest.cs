using System.Threading.Tasks;
using DedalusSdk.Models.Audio.Speech;

namespace DedalusSdk.Tests.Services.Audio;

public class SpeechServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Audio.Speech.Create(
            new()
            {
                Input = "input",
                Model = Model.Tts1,
                Voice = UnionMember1.Alloy,
            },
            TestContext.Current.CancellationToken
        );
    }
}
