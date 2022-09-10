using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetServices_MVC.Data.Data
{
    public class AdoptablePet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdoptionStatus { get; set; }

        [ForeignKey(nameof(PetType))]
        public int TypeId { get; set; }
        public virtual PetType PetType { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Weight { get; set; }
        public int Age { get; set; }
    }
}
