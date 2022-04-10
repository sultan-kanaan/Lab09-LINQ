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
            string path = @"../../../json1.json";
            string readFile = File.ReadAllText(path);
            FeatureCollection Places = JsonConvert.DeserializeObject < FeatureCollection > (readFile);


            var listAllPlaces = Places.features.Select(feature => feature.properties.neighborhood);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("                             Method LINQ");
            Console.WriteLine("______________________________________________________________________________");

            int counter = 1;
            foreach (var f in listAllPlaces)
            {
                Console.WriteLine($"{counter} {f}");
                counter++;
            }


            Neighborhoods(Places);
            NoDuplicates(Places);
            SingleQuery(Places);

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Beep();
            Console.WriteLine("Code By Sultan Kanaan");
            Console.ReadKey();
        }
        public static void ListAll(FeatureCollection Places)
    {
            var filter = from Features in Places.features
                          select Features.properties.neighborhood;
            
        }
        public static void Neighborhoods(FeatureCollection Places)
        {
            var filter = from Feature in Places.features
                         where Feature.properties.neighborhood != ""
                         select Feature.properties.neighborhood;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("                      neighborhoods with Name ");
            Console.WriteLine("______________________________________________________________________________");

            int counter = 0;
            foreach (var feature in filter)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }
        public static void NoDuplicates(FeatureCollection Places)
        {
            var noDuplicates = (from Feature in Places.features
                                where Feature.properties.neighborhood != ""
                                select Feature.properties.neighborhood).Distinct(); ;
            
            Console.ForegroundColor = ConsoleColor.DarkRed;

            int counter = 0;
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("                       No Duplicates");
            Console.WriteLine("______________________________________________________________________________");

            foreach (var feature in noDuplicates)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }

        public static void SingleQuery(FeatureCollection Places)
        {
            var single = from Feature in Places.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood;
            var SingleQ = single.Distinct();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("                        Single Query Line");
            Console.WriteLine("______________________________________________________________________________");

            int counter = 0;
            foreach (var feature in SingleQ)
            {
                counter++;
                Console.WriteLine($"{counter} {feature}");
            }
        }



    }

}
