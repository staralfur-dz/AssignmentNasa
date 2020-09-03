using AssignmentNasa.Common;
using AssignmentNasa.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AssignmentNasa
{
    class Program
    {

        static async Task Main(string[] args)
        {

            //Adding configuration file to maintain api url
            
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var apiUrl = config.GetSection("api-url").Value;

            Console.WriteLine("Insert dates file path:");
            var pathDate = Console.ReadLine();

            var photoDates = Utility.GetDatesFromFile(pathDate);

            if (photoDates.Count == 0 || photoDates == null)
            {
                Console.WriteLine("Please provide valid Dates!");
            }
            else
            {

                Console.WriteLine("Insert path to save photos:");
                var pathPhoto = Console.ReadLine();

                //Processing per date
                foreach (var photoDate in photoDates)
                {
                    var uri = new Uri(apiUrl + photoDate);
                    await Utility.DownloadPhotos(uri, pathPhoto, photoDate);
                }

                Console.WriteLine("Download complete!, Please find photos at " + pathPhoto);
                Console.WriteLine("Press any key to close the program...");
                Console.ReadLine();

            }
        }

    }
}
