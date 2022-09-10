using PetServices_MVC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Models.AdoptablePetsModels
{
     public class AdoptablePetIndex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdoptionStatus { get; set; }

        public int TypeId { get; set; }
        public PetType PetType { get; set; }
    }
}
