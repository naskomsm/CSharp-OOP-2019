namespace FoodShortage
{
    using System;
    using System.Collections.Generic;

    public class ObjectFactory
    {
        public void Run(int numberOfPeople, List<IObject> objects)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] objectArgs = Console.ReadLine().Split();

                string name = objectArgs[0];
                int age = int.Parse(objectArgs[1]);

                if (objectArgs.Length == 4)
                {
                    string id = objectArgs[2];
                    string birthdate = objectArgs[3];

                    var citizen = new Citizen(name, age, id, birthdate);
                    objects.Add(citizen);
                }
                else
                {
                    string group = objectArgs[2];

                    var rebel = new Rebel(name, age, group);
                    objects.Add(rebel);
                }
            }
        }
    }
}
