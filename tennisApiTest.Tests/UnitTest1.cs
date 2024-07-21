using System.Diagnostics.Metrics;
using Moq;
using System.Numerics;
using tennisApiTest.Models;
using tennisApiTest.Repositories;
using tennisApiTest.Services;

namespace tennisApiTest.Tests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void GetSortedPlayers_ReturnsPlayersSortedByPoints()
        {
            // Arrange
            var mockRepo = new Mock<IPlayerRepository>();
            mockRepo.Setup(repo => repo.GetAllPlayers()).Returns(new List<Player>
            {
                new Player { data = new PlayerData { points = 1000 } },
                new Player { data = new PlayerData { points = 2000 } },
                new Player { data = new PlayerData { points = 1500 } },
            });
            var service = new PlayerService(mockRepo.Object);

            // Act
            var result = service.GetSortedPlayers();

            // Assert
            Assert.Equal(2000, result.First().data.points);
            Assert.Equal(1000, result.Last().data.points);
        }

        [Fact]
        public void GetPlayerById_ReturnsCorrectPlayer()
        {
            // Arrange
            var mockRepo = new Mock<IPlayerRepository>();
            mockRepo.Setup(repo => repo.GetPlayerById(1)).Returns(new Player { id = 1, firstname = "Test" });
            var service = new PlayerService(mockRepo.Object);

            // Act
            var result = service.GetPlayerById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Test", result.firstname);
        }

        [Fact]
        public void GetStatistics_ReturnsCorrectStats()
        {
            // Arrange
            var mockRepo = new Mock<IPlayerRepository>();
            mockRepo.Setup(repo => repo.GetAllPlayers()).Returns(new List<Player>
            {
                new Player { data = new PlayerData { weight = 80000, height = 200, last = new List<int> { 1, 1, 1, 1, 1 } }, country = new Country { code = "USA" } },
                new Player { data = new PlayerData { weight = 90000, height = 190, last = new List<int> { 1, 0, 0, 0, 0 } }, country = new Country { code = "SRB" } },
                new Player { data = new PlayerData { weight = 85000, height = 180, last = new List<int> { 1, 1, 1, 1, 1 } }, country = new Country { code = "USA" } },


            });
            var service = new PlayerService(mockRepo.Object);

            // Act
            var result = service.GetStatistics();

            // Assert
            Assert.Equal("USA", result.CountryWithHighestWinRatio);
            Assert.Equal(23.72, result.AverageIMC, 2);
            Assert.Equal(190, result.MedianHeight);
        }
    }
}