using PetServices_MVC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Models.PetServicesModels
 
{
    public class PetServiceDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
