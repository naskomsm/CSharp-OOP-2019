namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Factories;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilots;
        private Dictionary<string, IMachine> machines;

        private PilotFactory pilotFactory;
        private TankFactory tankFactory;
        private FighterFactory fightorFactory;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();

            this.pilotFactory = new PilotFactory();
            this.tankFactory = new TankFactory();
            this.fightorFactory = new FighterFactory();
        }

        public string HirePilot(string name)
        {
            var pilot = pilotFactory.CreatePilot(name);

            if (this.pilots.ContainsKey(name))
            {
                return $"Pilot {name} is hired already";
            }

            this.pilots.Add(name, pilot);

            return $"Pilot {name} hired";
        } // should be good

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = this.tankFactory.CreateTank(name, attackPoints, defensePoints);

            if (this.machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(name, tank);

            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        } // should be good

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = this.fightorFactory.CreateFighter(name, attackPoints, defensePoints);

            if (this.machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(name, fighter);

            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        } // should be good

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (!this.machines.ContainsKey(selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            var machine = this.machines[selectedMachineName];
            var pilot = this.pilots[selectedPilotName];

            if (machine.Pilot != null)
            {
                return $"Machine {machine.Name} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        } // dont know about that

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.ContainsKey(attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (!this.machines.ContainsKey(defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            var attackingMachine = this.machines[attackingMachineName];
            var defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:f2}";
        } // dont know about that  

        public string PilotReport(string pilotReporting)
        {
            if (!this.pilots.ContainsKey(pilotReporting))
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            var pilot = this.pilots[pilotReporting];

            return pilot.Report();
        } // should be ok 

        public string MachineReport(string machineName)
        {
            if (!this.machines.ContainsKey(machineName))
            {
                return $"Machine {machineName} could not be found";
            }

            var machine = this.machines[machineName];

            return machine.ToString();
        } // should be ok 

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!this.machines.ContainsKey(fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            var fighter = (Fighter)this.machines[fighterName];
            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        } // should be good

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!this.machines.ContainsKey(tankName))
            {
                return $"Machine {tankName} could not be found";
            }

            var tank = (Tank)this.machines[tankName];
            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        } // should be good
    }
}