namespace MillitaryElite
{
    using MillitaryElite.Models;
    using MillitaryElite.Models.Privates;
    using MillitaryElite.Models.Privates.SpecializedSoldiers;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    // need to replace all the lIsts with hashset and will work 100/100...
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Soldier> soldiers = new HashSet<Soldier>();

            while (true)
            {

                string soldier = Console.ReadLine();

                if (soldier == "End")
                {
                    break;
                }


                string[] soldierArgs = soldier.Split();

                string soldierType = soldierArgs[0];
                string id = soldierArgs[1];
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);
                    Private @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(@private);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierArgs[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    List<string> ids = soldierArgs.Skip(5).ToList();
                    HashSet<Private> privates = GetPrivates(ids, soldiers);
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                    soldiers.Add(general);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);
                    string corps = soldierArgs[5];

                    List<string> repairArgs = soldierArgs.Skip(6).ToList();
                    HashSet<Repair> privates = GetRepairs(repairArgs);
                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, privates);
                        soldiers.Add(engineer);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);
                    string corps = soldierArgs[5];

                    List<string> missionArgs = soldierArgs.Skip(6).ToList();
                    HashSet<Mission> missions = GetMission(missionArgs);
                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            foreach (var soldierObject in soldiers)
            {
                Console.WriteLine(soldierObject);
            }

        }

        private static HashSet<Mission> GetMission(List<string> missionArgs)
        {
            HashSet<Mission> missions = new HashSet<Mission>();

            for (int i = 0; i < missionArgs.Count; i += 2)
            {
                string codeName = missionArgs[i];
                string state = missionArgs[i + 1];

                try
                {
                    Mission mission = new Mission(codeName, state);
                    missions.Add(mission);
                }
                catch (Exception)
                {
                }
            }

            return missions;
        }

        private static HashSet<Repair> GetRepairs(List<string> repairArgs)
        {
            HashSet<Repair> repairs = new HashSet<Repair>();

            for (int i = 0; i < repairArgs.Count; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                Repair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private static HashSet<Private> GetPrivates(List<string> ids, HashSet<Soldier> soldiers)
        {
            HashSet<Private> privates = new HashSet<Private>();

            List<Soldier> filteredSoldiers = soldiers.Where(x => x.GetType().Name == nameof(Private)).ToList();

            foreach (var privateSoldier in filteredSoldiers)
            {
                if (ids.Contains(privateSoldier.Id))
                {
                    privates.Add((Private)privateSoldier);
                }
            }

            return privates;
        }
    }
}
