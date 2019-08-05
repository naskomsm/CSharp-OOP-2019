﻿namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count { get; }

        public IReadOnlyCollection<IPlayer> Players
            => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null!");
            }

            if (this.players.Select(x => x.Username).Contains(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var player = this.players.FirstOrDefault(x => x.Username == username);

            if(player == null)
            {
                throw new ArgumentException("Player cannot be null!");
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null!");
            }

            return this.players.Remove(player);
        }
    }
}
