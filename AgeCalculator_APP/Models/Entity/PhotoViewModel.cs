using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Models.Entity
{
    public class PhotoViewModel
    {
        public int PhotoID { get; set; }
        public string PhotoFile { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
