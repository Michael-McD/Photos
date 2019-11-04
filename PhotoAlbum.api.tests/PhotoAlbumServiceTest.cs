using Moq;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;
using FluentAssertions;
using System.Linq;
using Newtonsoft.Json;

namespace PhotoAlbum.api.tests
{
    public class PhotoAlbumServiceTest
    {
        [Fact]
        public void CanGetPhotos()
        {
            // arrange
            var expected = new List<PhotoDomainModel> { new PhotoDomainModel() { Id = 1, AlbumId = 2, Title = "Title", ThumbnailUrl = "TURL", Url = "URL" } };
            
            var configuration = new HttpConfiguration();
            var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) => {
                request.SetConfiguration(configuration);
                var response = request.CreateResponse(HttpStatusCode.OK, expected, "application/json");
                return Task.FromResult(response);
            });
            var client = new HttpClient(clientHandlerStub);
            client.BaseAddress = new Uri("http://nowhere/");
            var service = new PhotoAlbumService(client);

            // act
            var actual = service.GetPhotos().Result;

            // assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
