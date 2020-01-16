namespace ViceCity.Models.Guns
{
    public class Rifle:Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int shoot = 5;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - shoot <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= shoot;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return shoot;
            }

            if (this.CanFire)
            {
                this.BulletsPerBarrel -= shoot;
                return shoot;
            }

            return 0;
            //if (this.BulletsPerBarrel < shoot)
            //{
            //    var currentShoot = this.BulletsPerBarrel;
            //    this.BulletsPerBarrel = 0;

            //    return currentShoot;
            //}

            //this.BulletsPerBarrel -= shoot;

            //if (this.BulletsPerBarrel == 0 || this.BulletsPerBarrel < shoot)
            //{
            //    var reload = Math.Min(InitialBulletsPerBarrel, this.TotalBullets);
            //    this.BulletsPerBarrel += reload;
            //    this.TotalBullets -= reload;
            //}

            //return shoot;
        }
    }
}
