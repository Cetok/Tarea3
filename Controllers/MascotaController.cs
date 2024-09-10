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
        private readonly ILogger<MascotaController> _logger;
        private readonly ApplicationDbContext _context;

        public MascotaController(ILogger<MascotaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("enviar")]
        public IActionResult Enviar(Mascota objmascota)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");
            _context.Add(objmascota);
            _context.SaveChanges();

            ViewData["Message"] = "Se registró la mascota";
            return View("Index");
        }
        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}