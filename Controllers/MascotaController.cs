using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarea3.Data;
using Tarea3.Models;

namespace Tarea3.Controllers
{
    [Route("mascota")]
    public class MascotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        [HttpGet("index")]
        public IActionResult Index()
        {
            var viewModel = new MascotaViewModel
            {
                Mascota = new Mascota(),
                Mascotas = _context.DataMascota.ToList() 
            };

            return View(viewModel);
        }

        [HttpPost("create")]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.DataMascota.Add(mascota);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new MascotaViewModel
            {
                Mascota = mascota,
                Mascotas = _context.DataMascota.ToList()
                
            };

            return View("Index", viewModel);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var mascota = _context.DataMascota.Find(id);
            if (mascota != null)
            {
                _context.DataMascota.Remove(mascota);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}