using DiPractice.ProductCode;
using DiPractice.ProductCode.Enum;
using DiPractice.ProductCode.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DiPractice.Test
{
	[TestClass]
	public class GameServiceTest
	{
		private const int DefaultPlayerId = 123;

		[TestMethod]
		public void place_bet()
		{
			var log = Substitute.For<ILog>();
			var player = Substitute.For<Player>();
			player.GetPlayerId().ReturnsForAnyArgs(DefaultPlayerId);
			var gameService = new GameService(player);

			gameService.PlaceBet(EnumBetOption.Banker, 200);

			log.Received(0).Error(Arg.Any<string>());
		}
	}
}