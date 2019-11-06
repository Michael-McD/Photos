using Moq;
using PhotoAlbum.api.Controllers;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace PhotoAlbum.api.tests
{
    public class AlbumPhotoControlerTest
    {
        private readonly IEnumerable<AlbumDomainModel> _albumTestData = 
            new List<AlbumDomainModel> { new AlbumDomainModel { Id=1, Title="People", UserId=1 },
                                         new AlbumDomainModel { Id=2, Title="Cars", UserId=1 },
                                         new AlbumDomainModel { Id=3, Title="Boats", UserId=2 }};

        private readonly IEnumerable<PhotoDomainModel> _photoTestData =
            new List<PhotoDomainModel> { new PhotoDomainModel {  Id=2, Title="Fast Car", AlbumId=1, Url="https://foo.com", ThumbnailUrl="https://goo.com" },
                                         new PhotoDomainModel { Id=2, Title="Old Car", AlbumId=1, Url="https://foo.com", ThumbnailUrl="https://goo.com" }};

        [Fact]
        public async Task Return_array_of_album_title_and_id()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(serviceMock => serviceMock.GetAlbums())
                .ReturnsAsync(_albumTestData);

            var controller = new AlbumPhotoController(serviceMock.Object);

            // act
            var albums = await controller.GetAsync(1);

            // assert
            albums.Should().BeEquivalentTo(new List<AlbumViewModel>{
                new AlbumViewModel {AlbumId=1, AlbumTitle="People"},
                new AlbumViewModel {AlbumId=2, AlbumTitle="Cars"}
            });
        }
    }
}
