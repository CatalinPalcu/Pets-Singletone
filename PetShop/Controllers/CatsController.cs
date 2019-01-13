using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class CatsController : Controller
    {
        private CatRepository catRepository;

        public CatsController()
        {
            catRepository = CatRepository.Instance;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(Gender? gender, Color? color)
        {
            var cats = catRepository.GetCats();

            if (gender.HasValue)
            {
                cats = cats.Where(x => x.Gender == gender.Value).ToList();
            }
            if (color.HasValue)
            {
                cats = cats.Where(x => x.Color == color.Value).ToList();
            }
            return View(cats);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cat catToEdit = catRepository.GetCats().Find(x => x.Id == id);
            return View(catToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Cat model)
        {
            if(ModelState.IsValid)
            {
                var myCat = catRepository.GetCats().Find(x => x.Id == model.Id);
                TryUpdateModelAsync(myCat);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cat());
        }

        [HttpPost]
        public IActionResult Create(Cat model)
        {
            if (ModelState.IsValid)
            {
                catRepository.Add(model);
                return RedirectToAction("List");
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            catRepository.Delete(id);
            return RedirectToAction("List");
        }

    }
}