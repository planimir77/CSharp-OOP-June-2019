namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using Players;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer is Beginner)
            {
                BoostBeginnerHealth(attackPlayer);
            }
            if (enemyPlayer is Beginner)
            {
                BoostBeginnerHealth(enemyPlayer);
            }
            
            BoostPlayer(attackPlayer);
            BoostPlayer(enemyPlayer);

            int attackPlayerDamage = attackPlayer.CardRepository
                .Cards
                .Sum(s => s.DamagePoints);

            int enemyPlayerDamage = enemyPlayer.CardRepository
                .Cards
                .Sum(s => s.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            int attackPlayerBonusHealth = player.CardRepository
                .Cards
                .Sum(x => x.HealthPoints);
            player.Health += attackPlayerBonusHealth;
        }

        private void BoostBeginnerHealth(IPlayer player)
        {
            player.Health += 40;
            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
