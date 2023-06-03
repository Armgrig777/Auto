using CarsInfoDB.Context;
using System.Text.Json;

namespace Auto.Services
{
    public class JsonFileService
    {
        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "Cars.json");

        public IEnumerable<Cars> GetCars()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Cars[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public void AddRating(int carid, int rating)
        {
            var cars = GetCars();

            if (cars.First(x => x.Id == carid).Ratings == null)
            {
                cars.First(x => x.Id == carid).Ratings.Add(new Ratings { Rating = rating });
               
            }
            else
            {
                var ratings = cars.First(x => x.Id == carid).Ratings;
                ratings.Add(new Ratings { Rating = rating });
                cars.First(x => x.Id == carid).Ratings = ratings;
            }

            using var outputstream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Cars>>(
                new Utf8JsonWriter(outputstream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                cars
            );
        }
    }
}
