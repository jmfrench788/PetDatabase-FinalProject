using PetServices_MVC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Models.AdoptablePetsModels
{
    public class AdoptablePetEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdoptionStatus { get; set; }
        public string Weight { get; set; }
        public int Age { get; set; }
    }
}
