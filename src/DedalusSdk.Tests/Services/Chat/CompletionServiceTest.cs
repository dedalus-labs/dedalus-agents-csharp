using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services.Chat;

public class CompletionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var chatCompletion = await this.client.Chat.Completions.Create(
            new() { Model = "openai/gpt-5" },
            TestContext.Current.CancellationToken
        );
        chatCompletion.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Chat.Completions.CreateStreaming(
            new() { Model = "openai/gpt-5" },
            TestContext.Current.CancellationToken
        );

        await foreach (var chatCompletion in stream)
        {
            chatCompletion.Validate();
        }
    }
}
