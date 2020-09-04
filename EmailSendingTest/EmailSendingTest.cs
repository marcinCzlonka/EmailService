using EmailService;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using EmailService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Toggl;
using Xunit;
using Task = System.Threading.Tasks.Task;
using FluentAssertions;

namespace EmailSendingTest
{
    public class EmailSendingTest
    {
        private readonly HttpClient _client;

        public EmailSendingTest()
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
        public async Task Get_All_Emails_Without_Any_Test_Returns_Empty_Response()
        {
            var response = await _client.GetAsync("http://localhost:5050/api/GetAll");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
