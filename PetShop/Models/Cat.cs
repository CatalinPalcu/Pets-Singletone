using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Cat:Pet
    {
        public Cat() { }

        public Cat(string name, string nickname, Gender gender, Color color, Owner owner, DateTime birthDate) : base(name, nickname, gender, color, owner, birthDate) { }

    }
}
