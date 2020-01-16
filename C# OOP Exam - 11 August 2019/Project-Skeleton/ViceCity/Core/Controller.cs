namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using ViceCity.Models.Guns.Contracts;
    using Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using Models.Players;
    using ViceCity.Models.Players.Contracts;
    using Repositories;

    public class Controller:IController
    {
        private readonly List<IPlayer> players;
        private readonly GunRepository gunsRepository;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            IPlayer mainPlayer = new MainPlayer();
            this.players = new List<IPlayer>();
            this.gunsRepository = new GunRepository();
            this.neighbourhood = new GangNeighbourhood();
            this.players.Add(mainPlayer);
        }
        
        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            players.Add(player);
            
            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol" || type == "Rifle")
            {
                Assembly assembly = Assembly.GetCallingAssembly();

                Type[] types = assembly.GetTypes();

                Type typeToCreate = types.FirstOrDefault(t => t.Name == type);

                if (typeToCreate != null)
                {
                    Object instance = Activator.CreateInstance(typeToCreate,name);

                    this.gunsRepository.Add((IGun)instance);
                }

                return $"Successfully added {name} of type: {type}";
            }

            return "Invalid gun type!";

        }

        public string AddGunToPlayer(string name)
        {
            if (gunsRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = this.gunsRepository.Models.FirstOrDefault();
            
            if (name == "Vercetti")
            {
                players.FirstOrDefault(p=>p.Name == "Tommy Vercetti" && p.IsAlive)
                    ?.GunRepository.Add(gun);
                this.gunsRepository.Remove(gunsRepository.Models.FirstOrDefault());
                return $"Successfully added {gun?.Name} to the Main Player: Tommy Vercetti";
            }

            if (players.Any(p=>p.Name == name))
            {
                players.FirstOrDefault(p => p.Name == name && p.IsAlive)
                    ?.GunRepository.Add(gun);
                this.gunsRepository.Remove(gunsRepository.Models.FirstOrDefault());
                return $"Successfully added {gun?.Name} to the Civil Player: {name}";
            }

            return "Civil player with that name doesn't exists!";

        }

        public string Fight()
        {



            MainPlayer mainPlayer = (MainPlayer)this.players
                .FirstOrDefault(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players
                .Where(p => p.GetType().Name != nameof(MainPlayer))
                .ToList();

            this.neighbourhood.Action(mainPlayer, civilPlayers);

            StringBuilder sb = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive) && mainPlayer?.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");

                sb.AppendLine($"Tommy live points: {mainPlayer?.LifePoints}!");

                sb.AppendLine($"Tommy has killed: {civilPlayers.Count(p => p.IsAlive == false)} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Count(p => p.IsAlive)}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
