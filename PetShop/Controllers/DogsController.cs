using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class DogsController : Controller
    {
        private DogRepository dogRepository;

        public DogsController()
        {
            dogRepository = DogRepository.Instance;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(Gender? gender, Color? color)
        {
            var dogs = dogRepository.GetDogs();

            if (gender.HasValue)
            {
                dogs = dogs.Where(x => x.Gender == gender.Value).ToList();
            }
            if (color.HasValue)
            {
                dogs = dogs.Where(x => x.Color == color.Value).ToList();
            }
            return View(dogs);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dog dogToEdit = dogRepository.GetDogs().Find(x => x.Id == id);
            return View(dogToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Dog model)
        {
            if (ModelState.IsValid)
            {
                var myDog = dogRepository.GetDogs().Find(x => x.Id == model.Id);
                TryUpdateModelAsync(myDog);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Dog());
        }

        [HttpPost]
        public IActionResult Create(Dog model)
        {
            if(ModelState.IsValid)
            {
                dogRepository.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Dog dogToEdit = dogRepository.GetDogs().Find(x => x.Id == id);
            return View(dogToEdit);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            dogRepository.Delete(id);
            return RedirectToAction("List");
        }


    }
}