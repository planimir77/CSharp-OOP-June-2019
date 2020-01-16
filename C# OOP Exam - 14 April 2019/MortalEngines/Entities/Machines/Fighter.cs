using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{

    public class Fighter : BaseMachine,IFighter
    {
        private const int InitialHealthPoints = 200;
        private const int InitialAttackPoints = 50;
        private const int InitialDefensePoints = 25;


        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name
                , attackPoints + InitialAttackPoints
                , defensePoints - InitialDefensePoints
                , InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += InitialAttackPoints;
                this.DefensePoints -= InitialDefensePoints;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= InitialAttackPoints;
                this.DefensePoints += InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            string mode = this.AggressiveMode ? "ON" : "OFF";

            sb.AppendLine($" *Aggressive: {mode}");
            return sb.ToString().TrimEnd();
        }
    }
}
