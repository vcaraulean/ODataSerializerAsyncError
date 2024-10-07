using Microsoft.AspNetCore.Mvc.Testing;

namespace TheApp.WebApi.Tests;

public class MetadataEndpointsTests(WebApplicationFactory<Program> factory): IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetMetadata()
    {
        var httpClient = factory.CreateClient();

        _ = await httpClient.GetStringAsync("/odata/$metadata");
    }
}
