using AssignmentNasa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssignmentNasa.Common
{
    public static class Utility
    {
        public static string GetPhotoName(string photoUrl)
        {
            string photoName = photoUrl.Substring(photoUrl.LastIndexOf('/'));
            return photoName;
        }

        public static List<string> GetDatesFromFile(string pathDate)
        {

            List<string> photoDates = new List<string>();

            try
            {
                StreamReader file = new StreamReader(pathDate);

                string line;

                Console.WriteLine("Validating dates...");
                while ((line = file.ReadLine()) != null)
                {
                    DateTime photoDate;
                    if (DateTime.TryParse(line, out photoDate))
                    {
                        photoDates.Add(photoDate.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        Console.WriteLine(line + " is not a valid Date!");
                    }
                }

                file.Close();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return photoDates;
        }

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static async Task DownloadPhotos(Uri uri, string pathPhoto, string photoDate)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    var content = await response.Content.ReadAsAsync<Response>();

                    var photos = content.Photos;

                    int photosCount = photos.Count;

                    if (photosCount == 0)
                    {
                        Console.WriteLine("No photos available for " + photoDate + "!");
                        Console.WriteLine("=======================================");
                    }
                    else
                    {

                        //Create folder for date
                        var pathPhotoDate = pathPhoto + "\\" + photoDate;
                        CreateDirectory(pathPhotoDate);

                        Console.WriteLine("Downloading photos of " + photoDate);
                        int count = 0;
                        foreach (var photo in photos)
                        {
                            count++;
                            //save picture in console.
                            Console.WriteLine("Downloading Photo " + count + " of " + photosCount + "...");
                            using (WebClient webClient = new WebClient())
                            {
                                string photoName = GetPhotoName(photo.ImgSrc);
                                webClient.DownloadFile(new Uri(photo.ImgSrc), pathPhotoDate + "\\" + photoName);
                            }
                            Console.WriteLine("Photo " + count + " of " + photosCount + " downloaded.");

                        }

                        Console.WriteLine("Download photos of " + photoDate + " complete!");
                        Console.WriteLine("=======================================");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
