﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace CzyDobrze.IntegrationTests.Scenarios.Swagger
{
    public class SwaggerScenarios : IClassFixture<WebAppFactory>
    {
        private readonly WebAppFactory _factory;

        public SwaggerScenarios(WebAppFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_SwaggerUIEndpointReturnsSuccess_InDeveloperMode()
        {
            var client = _factory
                .CreateClient();

            var response = await client.GetAsync("/swagger");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Get_SwaggerUIEndpointReturns404_InRelease()
        {
            var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment("Production");
                })
                .CreateClient();

            var response = await client.GetAsync("/swagger");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}