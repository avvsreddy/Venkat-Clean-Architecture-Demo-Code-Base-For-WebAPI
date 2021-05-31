
using Example.Data.Repositories;
using Example.Domain.Repositories;

using NUnit.Framework;

namespace TG.UnitTest.Repository
{
    public class AlbumRepositoryTest
    {
        private readonly IAlbumRepository _repo;

        public AlbumRepositoryTest()
        {
            //_repo = new MockAlbumRepository();
        }

        [Test]
        public void AlbumGetAll()
        {
            // Arrange

            // Act
            var albums = _repo.GetAll();

            // Assert
            Assert.True(albums.Count > 1, "The number of albums was not greater than 1");
        }

        [Test]
        public void AlbumGetOne()
        {
            // Arrange
            var id = 1;

            // Act
            var album = _repo.GetById(id);

            // Assert
            Assert.Equals(id, album.AlbumId);
        }
    }
}