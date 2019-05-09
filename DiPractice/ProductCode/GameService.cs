using DiPractice.ProductCode.Enum;

namespace DiPractice.ProductCode
{
	public class GameService
	{
		private readonly Player _player;

		public GameService(Player player)
		{
			_player = player;
		}

		public void PlaceBet(EnumBetOption option, int stake)
		{
			var gameStatus = new GameStatus();
			if (gameStatus.IsOpenBet())
			{
				var isOk = new CasinoRepo().PlaceBet((int)option, stake);
				if (!isOk)
				{
					new Log().Error($"place bet error, playerId:{_player.GetPlayerId()}, Bet on:{option}, stake:{stake}");
				}
			}
		}
	}
}