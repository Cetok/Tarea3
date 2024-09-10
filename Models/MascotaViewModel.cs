using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea3.Models;

namespace Tarea3.Models
{
    public class MascotaViewModel
    {
         public Mascota Mascota { get; set; }

        // Para manejar la lista de mascotas en la vista
        public IEnumerable<Mascota> Mascotas { get; set; }
    }
}