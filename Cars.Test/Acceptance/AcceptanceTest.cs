using System.Net.Http;
using Cars.Api;
using Cars.Test.Acceptance;
using Xunit;

public class AcceptanceTest : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    protected readonly CustomWebApplicationFactory<Startup> factory;
    protected readonly HttpClient http;

    public AcceptanceTest(CustomWebApplicationFactory<Startup> factory)
    {
        this.factory = factory;
        this.http = factory.CreateClient();
    }
}