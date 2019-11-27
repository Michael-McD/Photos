using Moq;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using FluentAssertions;
using System.Linq;
using Newtonsoft.Json;

namespace PhotoAlbum.api.tests
{
    public class F1DriverServiceTest
    {
        [Fact]
        public void Can_Get_Drivers()
        {
            // arrange
            
            var source = File.ReadAllText("F1Drivers.json");
            
            var delegatingHandlerStub = new DelegatingHandlerStub(new HttpResponseMessage() {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(source, Encoding.UTF8, "application/json") 
            });
            var httpClient = new HttpClient(delegatingHandlerStub) {BaseAddress = new Uri("http://foo/")};
            var service = new F1DriverService(httpClient);

            // act
            var actual = service.GetDrivers();

            // assert
            //actual.Should().BeEquivalentTo(expected);
        }
    }
}
