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
    public class AlbumControlerTest
    {
        private readonly IEnumerable<AlbumDomainModel> _albumTestData = 
            new List<AlbumDomainModel> { new AlbumDomainModel { Id=1, Title="People", UserId=1 },
                                         new AlbumDomainModel { Id=2, Title="Cars", UserId=1 },
                                         new AlbumDomainModel { Id=3, Title="Boats", UserId=2 }};

        [Fact]
        public async Task Return_array_of_album_title_and_id()
        {
            // arrange
            var serviceMock = new Mock<IPhotoAlbumService>();
            serviceMock.Setup(serviceMock => serviceMock.GetAlbums())
                .ReturnsAsync(_albumTestData);

            var controller = new AlbumController(serviceMock.Object);

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
