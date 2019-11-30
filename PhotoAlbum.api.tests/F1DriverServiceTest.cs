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
using PhotoAlbum.API.Models;

namespace PhotoAlbum.api.tests
{
    public class F1DriverServiceTest
    {
        private string foo = "ewe";

        private List<F1DriversDomainModel> expectedF1Drivers = new List<F1DriversDomainModel>
        {
            new F1DriversDomainModel {Forename = "Valtteri", Surname = "Bottas", Fullname = "Valtteri Bottas", Nationality = "Finnish", Team = "Mercedes"},
            new F1DriversDomainModel {Forename = "Lewis", Surname = "Hamilton", Fullname = "Lewis Hamilton", Nationality = "British", Team = "Mercedes"},
            new F1DriversDomainModel {Forename = "Max", Surname = "Verstappen", Fullname = "Max Verstappen", Nationality = "Dutch", Team = "Red Bull"}
        };
        
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
            actual.Should().BeEquivalentTo(expectedF1Drivers);
        }
    }
}
