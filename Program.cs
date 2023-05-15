using System;

class Program
{
    static void Main()
    {
        string[] cities = { "Prontera", "Geffen", "Morroc", "Payon", "Alberta", "AlDeBaran", "Yuno", "Izude" };
        int[] outbreakLevels = new int[cities.Length];

        // Get the number of cities
        Console.Write("Enter the number of cities: ");
        int numberOfCities = int.Parse(Console.ReadLine());

        // Get city details
        for (int i = 0; i < numberOfCities; i++)
        {
            Console.Write($"Enter the name of city {i}: ");
            string cityName = Console.ReadLine();

            Console.Write($"Enter the number of cities in contact with {cityName}: ");
            int numberOfContacts = int.Parse(Console.ReadLine());

            int[] contacts = new int[numberOfContacts];
            for (int j = 0; j < numberOfContacts; j++)
            {
                Console.Write($"Enter the city number of city {j} in contact with {cityName}: ");
                int contactCityNumber = int.Parse(Console.ReadLine());

                // Validate city number
                if (contactCityNumber < 0 || contactCityNumber >= numberOfCities)
                {
                    Console.WriteLine("Invalid ID");
                    j--;
                    continue;
                }

                contacts[j] = contactCityNumber;
            }
        }

        // Handle events during the COVID-19 outbreak
        while (true)
        {
            Console.WriteLine("City Number\tCity Name\tCOVID-19 Outbreak Level");
            for (int i = 0; i < numberOfCities; i++)
            {
                Console.WriteLine($"{i}\t\t{cities[i]}\t\t{outbreakLevels[i]}");
            }

            Console.Write("Enter the event (Outbreak, Vaccinate, Lockdown, Spread, or Exit): ");
            string eventType = Console.ReadLine();

            if (eventType == "Exit")
                break;

            Console.Write("Enter the city number where the event occurred: ");
            int cityNumber = int.Parse(Console.ReadLine());

            // Validate city number
            if (cityNumber < 0 || cityNumber >= numberOfCities)
            {
                Console.WriteLine("Invalid ID");
                continue;
            }

            switch (eventType)
            {
                case "Outbreak":
                    outbreakLevels[cityNumber] += 2;
                    if (cityNumber > 0)
                        outbreakLevels[cityNumber - 1] += 1;
                    if (cityNumber < numberOfCities - 1)
                        outbreakLevels[cityNumber + 1] += 1;
                    break;

                case "Vaccinate":
                    outbreakLevels[cityNumber] = 0;
                    break;

                case "Lockdown":
                        if (outbreakLevels[cityNumber] != 1)
                            outbreakLevels[cityNumber] -= 1;
                        break;

                case "Spread":
                    outbreakLevels[cityNumber] += 1;
                    for (int i = 1; i < numberOfCities - 1; i++)
                    {
                        if (outbreakLevels[i] > outbreakLevels[i - 1])
                            outbreakLevels[i] += 1;
                        if (outbreakLevels[i] > outbreakLevels[i + 1])
                            outbreakLevels[i] += 1;
                    }
                    break;

            }
        }
    }
}
