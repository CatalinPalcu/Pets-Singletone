using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class CatRepository
    {
        private static List<Cat> Cats = new List<Cat>();
        private static CatRepository instance;
        private static int count;

        public CatRepository() { }

        public static CatRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CatRepository();
                    Cats = InitializeList();
                }
                return instance;
            }
        }

        private static List<Cat> InitializeList()
        {
            List<Cat> cats = new List<Cat>();

            cats.Add(new Cat("Negruta", "nickname1", Gender.Female, Color.Black,
                            new Owner()
                            {
                                Name = "Catalin",
                                Email = "palcu_catalin@yahoo.com"
                            },
                            new DateTime(2016, 04, 05))
                            {Id = cats.Count+1 });
            cats.Add(new Cat("Tommy", "nickname2", Gender.Male, Color.White,
                            new Owner()
                            {
                                Name = "Catalin",
                                Email = "palcu_catalin@yahoo.com"
                            },
                            new DateTime(2014, 09, 25))
                            { Id = cats.Count + 1 });
            cats.Add(new Cat("Arthur", "nickname3", Gender.Male, Color.Yellow,
                            new Owner()
                            {
                                Name = "Anca",
                                Email = "anca@yahoo.com"
                            },
                            new DateTime(2018, 12, 30))
                            { Id = cats.Count + 1 });
            cats.Add(new Cat("Degetica", "nickname4", Gender.Female, Color.White,
                            new Owner()
                            {
                                Name = "Andrei",
                                Email = "andrei@yahoo.com"
                            },
                            new DateTime(2007, 07, 18))
                            { Id = cats.Count + 1 });
            cats.Add(new Cat("ScarFace", "nickname5", Gender.Male, Color.Black,
                            new Owner()
                            {
                                Name = "Gheorghe",
                                Email = "ghgh@yahoo.com"
                            },
                            new DateTime(2017, 04, 28))
                            { Id = cats.Count + 1 });
            count = cats.Count;

            return cats;
        }

        public List<Cat> GetCats()
        {
            return Cats;
        }

        public void Add(Cat newCat)
        {
            count++;
            newCat.Id = count;
            Cats.Add(newCat);
        }

        private int GetIndex(int id)
        {
            for (int i = 0; i < Cats.Count; i++)
                if (Cats[i].Id == id)
                    return i;

            return -1;
        }

        public void Delete(int id)
        {
            int index = GetIndex(id);
            if (index >= 0)
                Cats.RemoveAt(index);
        }
    }
}
