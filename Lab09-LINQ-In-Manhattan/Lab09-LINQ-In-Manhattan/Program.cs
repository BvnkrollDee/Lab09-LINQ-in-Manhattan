using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Linq;

namespace Lab09_LINQ_In_Manhattan;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("/Users/bvnkrolldee/Documents/GitHub/Reading-notes/Lab09-LINQ-in-Manhattan/Lab09-LINQ-In-Manhattan/Lab09-LINQ-In-Manhattan");
        Console.WriteLine("Read file into string");

        FeatureCollection featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json);
        Console.WriteLine("Deserialized the json data");


        Location[] locations = featureCollection.features;
        Console.WriteLine(locations);
        // Output all 147 locations
        Part1WithLINQ(locations);
        // output neighborhoods with names - expecting 143
        Part2(locations);
        Part3(locations);
        Part4(locations);
    }

    public static void Part1(Location[] items) // items is just a variable it could have been any word
    {
        Dictionary<string, int> locationAppearances = new Dictionary<string, int>();
        for(int i = 0; i <items.Length; i++)
        {
            Location currentLocation = items[i];
            string neighborhood = currentLocation.properties.neighborhood;
            bool neighborhoodAlreadyInDictionary = locationAppearances.ContainsKey(neighborhood);
            if (neighborhoodAlreadyInDictionary == false)
            {
                locationAppearances.Add(currentLocation.properties.neighborhood, 1);
            }
            else {
                int currentValue = locationAppearances.GetValueOrDefault
                    (neighborhood);
                currentValue += 1;
            }
            Console.WriteLine(currentLocation.properties.neighborhood);
            locationAppearances.Add(currentLocation.properties.neighborhood, 1);
        }

        foreach (var location in locationAppearances)
        {
            Console.WriteLine($"{location.Key}: {location.Value}");
        }

    }
       public static void Part1WithLINQ(Location[] items)
        {
        var neighborHoodQuery = from item in items
                                        group item by item into grouped
                                        select new { Key = grouped.Key, Value = grouped.Count() };
        foreach (var location in neighborHoodQuery)
        {
            Console.WriteLine($"{location.Key}: {location.Value}");
        }

        }



    public static void Part2(Location[] items)
    {
        var neighborHoodQuery = from item in items
                                where item.properties.neighborhood != ""
                                //group item by item into grouped
                                select item;
        foreach (var location in neighborHoodQuery)
        {
            Console.WriteLine(location.properties.neighborhood);
            //Console.WriteLine($"{location.Key}: {location.Value}");
        }
    }

    public static void Part3(Location[] items)
    {
        //var neighborHoodQuery = from item in items
        //                        where !string.IsNullOrEmpty(item.properties.neighborhood)
        //                        group item by item.properties.neighborhood into grouped
        //                        select item;


        var distinctQuery = (from item in items
                             where !string.IsNullOrEmpty(item.properties.neighborhood)
                             select item.properties.neighborhood).Distinct();

        var distinctMethod = items
            .Where(item => !string.IsNullOrEmpty(item.properties.neighborhood))
            .Select(item => item.properties.neighborhood)
            .Distinct();

        foreach(string n in distinctMethod)
        {
            Console.WriteLine(n);
        }
    }

    public static void Part4(Location[] items)
    {
        var neighborHoodQuery = items
            .Where(item => !string.IsNullOrEmpty(item.properties.neighborhood))
            .Select(item => item.properties.neighborhood)
            .Distinct();

        foreach(var nerighborhood in neighborHoodQuery)
        {
            Console.WriteLine(nerighborhood);
        }
    }


}

