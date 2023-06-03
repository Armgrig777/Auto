using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CarsInfoDB.Context
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Img { get; set; }
        //public Image? Image => Images.FirstOrDefault();
        public virtual ICollection<Ratings>? Ratings { get; set; }
        public virtual ICollection<Image>? Images { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Cars>(this);
    }
        
}
