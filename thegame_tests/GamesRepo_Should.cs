using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using thegame.Services;

namespace thegame_tests
{
    [TestFixture]
    public class GamesRepo_Should
    {
        [Test]
        public void GetGame_AfterAddGame_ReturnsExpectedGame()
        {
            var expectedGame = A.Dummy<Game>();
            var guid = new Guid();
            expectedGame.GameField.Id = guid;

            GamesRepo.AddGame(expectedGame);

            var game = GamesRepo.GetGame(guid);

            game.Should().Be(expectedGame);
        }
    }
}
