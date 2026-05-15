using System.Text;
using System.Threading.Tasks;

namespace DedalusSdk.Tests.Services;

public class ImageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateVariation_Works()
    {
        var imagesResponse = await this.client.Images.CreateVariation(
            new() { Image = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        imagesResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Edit_Works()
    {
        var imagesResponse = await this.client.Images.Edit(
            new() { Image = Encoding.UTF8.GetBytes("Example data"), Prompt = "prompt" },
            TestContext.Current.CancellationToken
        );
        imagesResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Generate_Works()
    {
        var imagesResponse = await this.client.Images.Generate(
            new() { Prompt = "A white siamese cat" },
            TestContext.Current.CancellationToken
        );
        imagesResponse.Validate();
    }
}
