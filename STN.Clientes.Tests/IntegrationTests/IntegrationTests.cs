using FluentAssertions;
using STN.Clientes.Tests.Fixtures;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace STN.Clientes.Tests.IntegrationTests
{
    public class IntegrationTests
    {
        private readonly TestContext _testContext;

        public IntegrationTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/v1/Cliente");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetCpf_ValuesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/v1/Cliente/34799633821");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetCpf_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/v1/Cliente/639557000XX");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
