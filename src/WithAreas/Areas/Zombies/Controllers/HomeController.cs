﻿using Microsoft.AspNetCore.Mvc;
using WithAreas.Core.Interfaces;
using WithAreas.Core.Model;

namespace WithAreas.Areas.Zombies.Controllers
{
    [Area("Zombies")]
    public class HomeController : Controller
    {
        private readonly IRepository<Zombie> _zombieRepository;

        public HomeController(IRepository<Zombie> zombieRepository)
        {
            _zombieRepository = zombieRepository;
        }

        public IActionResult Index()
        {
            var entities = _zombieRepository.List();
            return View(entities);
        }

        public IActionResult Details(int id)
        {
            var entity = _zombieRepository.GetById(id);
            return View(entity);
        }

        public IActionResult Add()
        {
            var entity = new Zombie()
            {
                Name = "Random Zombie"
            };
            _zombieRepository.Add(entity);

            return RedirectToAction("Index");
        }
    }
}