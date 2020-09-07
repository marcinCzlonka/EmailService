using EmailService;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using EmailService.Database;
using EmailService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Toggl;
using Xunit;
using Task = System.Threading.Tasks.Task;
using FluentAssertions;

namespace GetAllEmailsTest
{
    public class GetAllEmailsTest
    {
        private readonly HttpClient _client;

        public GetAllEmailsTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder=>
                    builder.ConfigureServices(services =>
                        {
                            services.RemoveAll(typeof(ServiceContext));
                            services.AddDbContext<ServiceContext>(options => options.UseInMemoryDatabase("TestDb"));
                        }
                    ));
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task Get_All_Emails_Returns_Not_Empty_Response()
        {
            var response = await _client.GetAsync("http://localhost:50335/GetAll");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Email>>()).Should().NotBeEmpty();
        }
    }
}
