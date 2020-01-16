namespace ViceCity.Models.Guns
{
    public class Pistol:Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int shoot = 1;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }
        
        public override int Fire()
        {
            if (this.BulletsPerBarrel - shoot <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return shoot;
            }

            if (this.CanFire)
            {
                this.BulletsPerBarrel--;
                return shoot;
            }

            return 0;
            //if (this.BulletsPerBarrel == 0)
            //{
            //    return 0;
            //}

            //this.BulletsPerBarrel -= shoot;

            //if (this.BulletsPerBarrel == 0)
            //{
            //    var reload = Math.Min(InitialBulletsPerBarrel, this.TotalBullets);
            //    this.BulletsPerBarrel += reload;
            //    this.TotalBullets -= reload;
            //}
            //return shoot;
        }
    }
}
