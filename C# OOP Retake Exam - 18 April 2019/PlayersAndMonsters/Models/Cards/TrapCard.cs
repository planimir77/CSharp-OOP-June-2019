namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard:Card
    {
        private new const int DamagePoints = 120;
        private new const int HealthPoints = 5;

        public TrapCard(string name) 
            : base(name, DamagePoints, HealthPoints)
        {
        }
    }
}
