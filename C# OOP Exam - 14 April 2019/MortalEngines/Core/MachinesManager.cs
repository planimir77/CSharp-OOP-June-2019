using System;
using System.Collections.Generic;
using System.Linq;
using MortalEngines.Common;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return String.Format(OutputMessages.PilotExists, name);
            }
            IPilot pilot = new Pilot(name);
            pilots.Add(pilot);

            return String.Format(OutputMessages.PilotHired, name);

        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(t => t.GetType().Name == nameof(Tank) && t.Name == name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);

            machines.Add(tank);

            return String.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(t => t.GetType().Name == nameof(Fighter) && t.Name == name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighter);

            string mode = fighter.AggressiveMode ? "ON" : "OFF";

            return String.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, mode);

        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            if (pilot == null)
            {
                return String.Format(OutputMessages.PilotNotFound, selectedMachineName);
            }

            IMachine machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return String.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);
            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(m => m.Name == defendingMachineName);
            if (attackingMachine == null )
            {
                return String.Format(OutputMessages.MachineNotFound,attackingMachineName );
            }
            else if (defendingMachine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }

            attackingMachine.Attack(defendingMachine);

            return String.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == pilotReporting);
            return pilot?.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(m => m.Name == machineName);
            return machine?.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (machines.Any(t => t.GetType().Name == nameof(Fighter) && t.Name == fighterName))
            {
                IFighter fighter = (Fighter)machines.FirstOrDefault(t => t.GetType().Name == nameof(Tank) && t.Name == fighterName);
                fighter?.ToggleAggressiveMode();
                return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return String.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (machines.Any(t => t.GetType().Name == nameof(Tank) && t.Name == tankName))
            {
                ITank tank = (Tank)machines.FirstOrDefault(t => t.GetType().Name == nameof(Tank) && t.Name == tankName);
                tank?.ToggleDefenseMode();
                return String.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return String.Format(OutputMessages.MachineNotFound, tankName);

        }
    }
}