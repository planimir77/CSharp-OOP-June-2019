namespace PlayersAndMonsters.Models.Players
{
    using Common;
    using System;
    using Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value
                    , "Player's username cannot be null or an empty string.");
                
                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                Validator.ThrowIfNumberIsOrNegative(value
                    , "Player's health bonus cannot be less than zero.");
                
                this.health = value;
            }
        }

        public bool IsDead 
            => Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfNumberIsOrNegative(damagePoints
                , "Damage points cannot be less than zero.");
            
            Health = Math.Max(Health - damagePoints, 0);

        }
    }
}
