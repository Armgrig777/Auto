using CarsInfoDB.Context;
using CarsInfoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class Extensions
    {
        public static void DownloadAndSaveImage( this string imageUrl)
        {
            try
            {
                
                byte[] imageData;
                using (WebClient client = new WebClient())
                {
                    imageData = client.DownloadData(imageUrl);
                }

                
                string tempFileName = Path.GetTempFileName();
                File.WriteAllBytes(tempFileName, imageData);

               
                using (var dbContext = new CarsDBContext())
                {
                    Image image = new Image { ImageSource = File.ReadAllBytes(tempFileName)};
                    dbContext.Add(image);
                    dbContext.SaveChanges();
                }

                // Delete the temporary file
                File.Delete(tempFileName);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
