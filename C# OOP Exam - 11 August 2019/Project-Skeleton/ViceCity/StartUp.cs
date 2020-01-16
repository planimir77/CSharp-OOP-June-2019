using ViceCity.Core;
using ViceCity.Core.Contracts;

namespace ViceCity
{
    public class StartUp
    {
        private static IEngine engine;

        static void Main(string[] args)
        {
            engine = new Engine();
            engine.Run();

            //AddGun Pistol Colt
            //AddGun Rifle SniperRifle
            //AddPlayer Camber
            //AddPlayer Burney
            //AddGunToPlayer Camber
            //Fight

        }
    }
}
