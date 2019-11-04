using Moq;
using PhotoAlbum.api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PhotoAlbum.api.tests
{
    public class AlbumControlerTest
    {
        private readonly IEnumerable<AlbumDomainModel> _albumTestData = 
            new List<AlbumDomainModel> { new AlbumDomainModel { Id=1, Title="People", UserId=1 },
                                         new AlbumDomainModel { Id=2, Title="Cars", UserId=1 },
                                         new AlbumDomainModel { Id=3, Title="People", UserId=2 },
                                         new AlbumDomainModel { Id=4, Title="Holidays", UserId=2 }};

        [Fact]
        public void Return_array_of_album_title_and_id()
        {
            // arrange
            var serviceMock = new Mock<PhotoAlbumService>();
            serviceMock.Setup(serviceMock => serviceMock.GetAlbums())
                .ReturnsAsync(_albumTestData);

            // act

            // assert

        }
    }
}
