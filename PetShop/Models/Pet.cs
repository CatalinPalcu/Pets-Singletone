using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum Color
    {
        Black,
        White,
        Yellow
    }

    public class Pet
    {
        private DateTime birthDate;

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(5)]
        public string Nickname { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int years = now.Year - birthDate.Year;
                if (now.DayOfYear < birthDate.DayOfYear)
                    years--;
                return years;
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { this.birthDate = value; }
        }

        [Required]
        public Color Color { get; set; }

        [Required]
        public Gender Gender { get; private set; }

        public Owner Owner { get; set; }

        public Pet()
        {

        }

        public Pet(string name, string nickname, Gender gender, Color color, Owner owner, DateTime birthDate)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.Gender = gender;
            this.Color = color;
            this.Owner = owner;
            this.birthDate = birthDate;
        }
    }
}
