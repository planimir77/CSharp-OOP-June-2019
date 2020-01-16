namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard:Card
    {
        private new const int DamagePoints = 5;
        private new const int HealthPoints = 80;
        
        public MagicCard(string name) 
            : base(name, DamagePoints, HealthPoints)
        {
        }
    }
}
 