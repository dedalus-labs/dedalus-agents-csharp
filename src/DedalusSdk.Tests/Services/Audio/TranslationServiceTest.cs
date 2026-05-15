using System.Text;
using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services.Audio;

public class TranslationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var translation = await this.client.Audio.Translations.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), Model = "model" },
            TestContext.Current.CancellationToken
        );
        translation.Validate();
    }
}
