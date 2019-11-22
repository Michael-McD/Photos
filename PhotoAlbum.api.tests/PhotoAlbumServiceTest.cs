using Moq;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
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
    public class PhotoAlbumServiceTest
    {
        [Fact]
        public void CanGetPhotos()
        {
            // arrange
            var expected = new List<PhotoDomainModel> { new PhotoDomainModel() { Id = 1, AlbumId = 2, Title = "Title", ThumbnailUrl = "TURL", Url = "URL" } };
            var source = JsonConvert.SerializeObject(expected);
            
            var delegatingHandlerStub = new DelegatingHandlerStub(new HttpResponseMessage() {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(source, Encoding.UTF8, "application/json") 
            });
            var fakeHttpClient = new HttpClient(delegatingHandlerStub) {BaseAddress = new Uri("http://foo/")};
            var service = new PhotoAlbumService(fakeHttpClient);

            // act
            var actual = service.GetPhotos().Result;

            // assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
