using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarsInfoDB.Context
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageSource { get; set; }
        [ForeignKey("Cars")]
        public int CarsId { get; set; }
        public virtual Cars Cars { get; set; }
    }
}
