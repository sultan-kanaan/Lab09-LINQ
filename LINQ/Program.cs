using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../json1.json";
            string readFile = File.ReadAllText(path);
            List<Features> manhattanPlaces = new List<Features>();
            FeatureCollection Places = JsonConvert.DeserializeObject < FeatureCollection > (readFile);

            ListAll(Places);
            
            var listAllPlaces = Places.features.Select(feature => feature.properties.neighborhood);
            int counter = 1;
            Console.WriteLine("Method LINQ\n");
            foreach (var f in listAllPlaces)
            {
                Console.WriteLine($"{counter} {f}");
                counter++;
            }
        }
        public static void ListAll(FeatureCollection ex)
    {
            var filter = from Features in ex.features
                          select Features.properties.neighborhood;
            int counter = 1;
            foreach (var f in filter)
            {
                Console.WriteLine($"{counter} {f}");
                counter++;
            }
        }
        public static void Neighborhoods(FeatureCollection ex)
        {
            var filter = from Feature in ex.features
                         where Feature.properties.neighborhood != ""
                         select Feature.properties.neighborhood;

            int counter = 0;
            foreach (var feature in filter)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }
        public static void NoDuplicates(FeatureCollection ex)
        {
            var noDuplicates = from Feature in ex.features
                           where Feature.properties.neighborhood != ""
                           select Feature.properties.neighborhood.Distinct();
            int counter = 0;
            Console.WriteLine("Duplicates");
            foreach (var feature in noDuplicates)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }

        public static void SingleQuery(FeatureCollection ex)
        {
            var single = from Feature in ex.features
                           where Feature.properties.neighborhood != ""
                           select Feature.properties.neighborhood.Distinct();
            int counter = 0;
            Console.WriteLine("Single Query Line");
            foreach (var feature in single)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }



    }

}
