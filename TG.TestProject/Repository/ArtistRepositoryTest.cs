
using Example.Domain.Repositories;
using NUnit.Framework;

namespace Chinook.UnitTest.Repository
{
    public class ArtistRepositoryTest
    {
        private readonly IArtistRepository _repo;

        public ArtistRepositoryTest()
        {
        }
        
        [Test]
        public void ArtistGetAll()
        {
            // Act
            var artists = _repo.GetAll();

            // Assert
            Assert.True(artists.Count > 1, "The number of artists was not greater than 1");
        }
    }
}