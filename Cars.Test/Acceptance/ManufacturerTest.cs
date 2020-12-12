using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Cars.Api;
using Cars.Domain.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xbehave;

namespace Cars.Test.Acceptance
{
    public class ManufacturerTest : AcceptanceTest
    {
        public ManufacturerTest(CustomWebApplicationFactory<Startup> factory) : base(factory) {}

        [Scenario]
        public void ShouldReturnOkWhenPostingManufacturer(StringContent content, HttpResponseMessage response)
        {
            "Given a new manufacturer needs to be registered"
                .x(() => content = new StringContent(
                    JsonConvert.SerializeObject(new Manufacturer { Name = "Dodge" }),
                    Encoding.UTF8,
                    "application/json")
                );

            "It is sent to towards the API"
                .x(async () => response = await this.http.PostAsync("/manufacturers", content));        

            "And should be salved successfully"
                .x(() => response.StatusCode.Should().Be(HttpStatusCode.Created));
        }
        
        [Scenario]
        public void ShouldReturnOkAndBeAListOfManufacturersWhenGetIndex(HttpResponseMessage response, List<Manufacturer> content)
        {
            "Given seeded manufacturers, a request is sent to query them"
                .x(async () => response = await this.http.GetAsync("/manufacturers"));

            "The result is then deserialized"
                .x(async () => content = JsonConvert.DeserializeObject<List<Manufacturer>>(await response.Content.ReadAsStringAsync()));

            "And it must be a successful response with a list of manufacturer as result"
                .x(() => { 
                    content.Should().BeOfType<List<Manufacturer>>();
                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                });
            
        }

        [Scenario]
        public void ShouldReturnOkAndBeAManufacturerWhenGetOne(HttpResponseMessage response, Manufacturer content)
        {
            "Given seeded manufacturers, a request is sent to query one with a valid ID"
                .x(async () => response = await this.http.GetAsync("/manufacturers/1"));
            
            "The result is then deserialized"
                .x(async () => content = JsonConvert.DeserializeObject<Manufacturer>(await response.Content.ReadAsStringAsync()));

            "And it must be a successful response with a manufacturer as result"
                .x(() => { 
                    content.Should().BeOfType<Manufacturer>();
                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                });
        }

        [Scenario]
        public void ShouldReturnNotFoundWhenGetOneInvalid(HttpResponseMessage response)
        {
            "Given seeded manufacturers, a request is sent to query one with an invalid ID"
                .x(async () => response = await this.http.GetAsync("/manufacturers/0"));
            
            "The response must be Not Found"
                .x(() => response.StatusCode.Should().Be(HttpStatusCode.NotFound));
        }
    }
}