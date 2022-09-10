using PetServices_MVC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Models.PetModels
{
    public class PetIndex
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TypeId { get; set; }
        public PetType PetType { get; set; }

        public int ServiceId { get; set; }
        public PetService_ CurrentService { get; set; }
    }
}
