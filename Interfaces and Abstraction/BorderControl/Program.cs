namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IObject> objects = new List<IObject>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Citizen") // citizen
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];

                    Citizen citizen = new Citizen(name, id, age, birthdate);
                    objects.Add(citizen);
                }
                else if(input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];

                    Pet pet = new Pet(name, birthdate);
                    objects.Add(pet);
                }
            }
            string year = Console.ReadLine();
            
            List<IObject> itemsToRemove = GetDetainedIds(objects, year);
            if (itemsToRemove.Any())
            {
                foreach (var item in itemsToRemove)
                {
                    Console.WriteLine(item.Birthday);
                }
            }
        }

        private static List<IObject> GetDetainedIds(List<IObject> objects, string year)
        {
            List<IObject> toRemoveList = new List<IObject>();
            foreach (var item in objects)
            {
                char[] currentId = item.Birthday.Reverse().ToArray();
                char[] wrongIds = year.Reverse().ToArray();


                bool toRemove = false;
                for (int i = 0; i < wrongIds.Length; i++)
                {
                    if (currentId[i] == wrongIds[i])
                    {
                        toRemove = true;
                    }
                    else
                    {
                        toRemove = false;
                        break;
                    }
                }
                if (toRemove)
                {
                    toRemoveList.Add(item);
                }
            }

            return toRemoveList;
        }
    }
}
