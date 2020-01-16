namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayersAndMonsters.Models.Players.Contracts;
    using Contracts;

    public class PlayerRepository:IPlayerRepository
    {
        private readonly List<IPlayer> _players;

        public PlayerRepository()
        {
            _players = new List<IPlayer>();
        }

        public int Count 
            => Players.Count;

        public IReadOnlyCollection<IPlayer> Players 
            => _players.AsReadOnly();
        

        public void Add(IPlayer player)
        {

            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (_players.Any(x=>x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            _players.Add(player);

        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            var removed = _players.Remove(player);
            return removed;
        }

        public IPlayer Find(string username)
        {
            //Returns a player with that username.

            IPlayer player = _players.FirstOrDefault(x => x.Username == username);

            return player;
        }
    }
}
