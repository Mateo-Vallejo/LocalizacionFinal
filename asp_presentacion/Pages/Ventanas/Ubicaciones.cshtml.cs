using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace asp_presentacion.Pages.Ventanas
{
    public class UbicacionesModel : PageModel
    {
        public List<Ubicacion> Ubicaciones { get; set; }

        public void OnGet()
        {
            // Simulación de datos desde la base de datos
            Ubicaciones = new List<Ubicacion>
            {
                new Ubicacion { Nombre = "Cliente A", Latitud = 19.4326, Longitud = -99.1332 },
                new Ubicacion { Nombre = "Cliente B", Latitud = 40.7128, Longitud = -74.0060 }
            };
        }
    }

    public class Ubicacion
    {
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}

