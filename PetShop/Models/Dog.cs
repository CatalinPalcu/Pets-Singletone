using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class Dog:Pet
    {
        public Dog()
        {

        }

        public Dog(string name, string nickname, Gender gender, Color color, Owner owner, DateTime birthDate) : base(name, nickname, gender, color, owner, birthDate) { }
    }
}
