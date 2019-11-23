using Moq;
using PhotoAlbum.api.Controllers;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PhotoAlbum.api.tests
{
    public class AlbumPhotoControllerTest
    {
        private readonly IEnumerable<AlbumDomainModel> albumTestData = 
            new List<AlbumDomainModel> { new AlbumDomainModel { Id=1, Title="People", UserId=1 },
                                         new AlbumDomainModel { Id=2, Title="Cars", UserId=1 },
                                         new AlbumDomainModel { Id=3, Title="Boats", UserId=2 }};

        private readonly IEnumerable<PhotoDomainModel> photoTestData =
            new List<PhotoDomainModel> { new PhotoDomainModel {  Id=1, Title="Fast Car", AlbumId=2, Url="https://foo.com", ThumbnailUrl="https://goo.com" },
                                         new PhotoDomainModel { Id=2, Title="Old Car", AlbumId=2, Url="https://bar.com", ThumbnailUrl="https://baz.com" }};

        [Fact]
        public async Task Return_array_of_album_title_and_id()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(sm => sm.GetAlbums())
                .ReturnsAsync(this.albumTestData);

            var controller = new AlbumPhotosController(serviceMock.Object);

            // act
            var albums = await controller.GetAsync(1);

            // assert
            albums.Should().NotBeNull();
            albums.Should().BeOfType<ActionResult<IEnumerable<AlbumViewModel>>>();
            albums.Result.Should().BeOfType<OkObjectResult>();
            
            ((OkObjectResult)albums.Result).Value.Should().BeEquivalentTo(new List<AlbumViewModel>{
                new AlbumViewModel {AlbumId=1, AlbumTitle="People"},
                new AlbumViewModel {AlbumId=2, AlbumTitle="Cars"}
            });
        }

        [Fact]
        public async Task Return_array_of_photos_in_an_album()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(mock => mock.GetAlbums())
                .ReturnsAsync(this.albumTestData);
            serviceMock.Setup(mock => mock.GetPhotos())
                .ReturnsAsync(this.photoTestData);

            var controller = new AlbumPhotosController(serviceMock.Object);

            // act
            int userId = 1, albumId = 2;
            var photos = await controller.GetAsync(userId, albumId);

            // assert
            photos.Should().NotBeNull();
            photos.Should().BeOfType<ActionResult<IEnumerable<PhotoViewModel>>>();
            photos.Result.Should().BeOfType<OkObjectResult>();
            
            ((OkObjectResult) photos.Result).Value.Should().BeEquivalentTo(new List<PhotoViewModel>{
                new PhotoViewModel {PhotoId=1, AlbumTitle="Cars", PhotoTitle="Fast Car", URL="https://foo.com", ThumbnailUrl="https://goo.com"},
                new PhotoViewModel {PhotoId=2, AlbumTitle="Cars", PhotoTitle="Old Car", URL="https://bar.com", ThumbnailUrl="https://baz.com"}
            });
        }

        [Fact]
        public async Task Return_a_photo_in_an_album()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(mock => mock.GetAlbums())
                .ReturnsAsync(this.albumTestData);
            serviceMock.Setup(mock => mock.GetPhotos())
                .ReturnsAsync(this.photoTestData);

            var controller = new AlbumPhotosController(serviceMock.Object);

            // act
            int userId = 1, albumId = 2, photoId = 1;
            var response = await controller.GetAsync(userId, albumId, photoId);

            // assert
            response.Should().NotBeNull();
            var photo = response.Value;

            photo.Should().BeEquivalentTo(new PhotoViewModel { PhotoId = 1, AlbumTitle = "Cars", PhotoTitle = "Fast Car", URL = "https://foo.com", ThumbnailUrl = "https://goo.com" });
        }

        [Fact]
        public async Task Return_an_404_if_photo_not_found()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(mock => mock.GetAlbums())
                .ReturnsAsync(this.albumTestData);
            serviceMock.Setup(mock => mock.GetPhotos())
                .ReturnsAsync(this.photoTestData);

            var controller = new AlbumPhotosController(serviceMock.Object);

            // act
            int userId = 1, albumId = 1, photoId = 1;
            var response = await controller.GetAsync(userId, albumId, photoId);

            // assert
            response.Should().NotBeNull();
            ((StatusCodeResult)response.Result).StatusCode.Should().Be(404);
        }
    }
}
