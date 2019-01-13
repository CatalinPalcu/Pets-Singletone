using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class DogRepository
    {
        private static List<Dog> Dogs = new List<Dog>();
        private static DogRepository instance;
        private static int count;

        public DogRepository()
        {

        }

        public static DogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DogRepository();
                    Dogs = InitializeList();
                }
                return instance;
            }
        }

        private static List<Dog> InitializeList()
        {
            List<Dog> dogs = new List<Dog>();

            dogs.Add(new Dog("Roxy", "nickname1", Gender.Female, Color.Black,
                            new Owner()
                            {
                                Name = "Catalin",
                                Email = "palcu_catalin@yahoo.com"
                            },
                            new DateTime(2016, 04, 05))
            { Id = dogs.Count + 1 });
            dogs.Add(new Dog("Azor", "nickname2", Gender.Male, Color.White,
                            new Owner()
                            {
                                Name = "Catalin",
                                Email = "palcu_catalin@yahoo.com"
                            },
                            new DateTime(2014, 09, 25))
            { Id = dogs.Count + 1 });
            dogs.Add(new Dog("Spot", "nickname3", Gender.Male, Color.Yellow,
                            new Owner()
                            {
                                Name = "Anca",
                                Email = "anca@yahoo.com"
                            },
                            new DateTime(2018, 12, 30))
            { Id = dogs.Count + 1 });
            dogs.Add(new Dog("Laica", "nickname4", Gender.Female, Color.White,
                            new Owner()
                            {
                                Name = "Andrei",
                                Email = "andrei@yahoo.com"
                            },
                            new DateTime(2007, 07, 18))
            { Id = dogs.Count + 1 });
            dogs.Add(new Dog("Hercule", "nickname5", Gender.Male, Color.Black,
                            new Owner()
                            {
                                Name = "Gheorghe",
                                Email = "ghgh@yahoo.com"
                            },
                            new DateTime(2017, 04, 28))
            { Id = dogs.Count + 1 });
            count = dogs.Count;

            return dogs;
        }

        public List<Dog> GetDogs()
        {
            return Dogs;
        }

        public void Add (Dog newDog)
        {
            count++;
            newDog.Id = count;
            Dogs.Add(newDog);
        }

        private int GetIndex(int id)
        {
            for (int i = 0; i < Dogs.Count; i++)
                if (Dogs[i].Id == id)
                    return i;

            return -1;
        }

        public void Delete(int id)
        {
            int index = GetIndex(id);
            if (index >= 0)
                Dogs.RemoveAt(index);
        }
    }
}
