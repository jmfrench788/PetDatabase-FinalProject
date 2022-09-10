using PetServices_MVC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Models.AdoptablePetsModels
{
    public class AdoptablePetCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdoptionStatus { get; set; } = "Not Adopted";
        public int TypeId { get;set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public string Weight { get; set; }
        public int Age { get; set; }
    }
}
