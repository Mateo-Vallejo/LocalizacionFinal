using lib_comunicaciones.Implementaciones; // Implementaciones de interfaces de comunicación
using lib_comunicaciones.Interfaces; // Definición de las interfaces
using lib_entidades.Modelos; // Modelos de datos
using lib_utilidades; // Utilidades para conversión JSON

namespace mst_pruebas.Comunicaciones
{
    [TestClass] // Indica que la clase contiene pruebas unitarias
    public class LocalizacionUsuario
    {
        private ILocalizacionComunicacion? iComunicacion = null; // Interfaz para manejar localizaciones
        private Localizacion? entidad = null; // Instancia de prueba
        private List<Localizacion>? lista = null; // Lista para almacenar resultados

        // Constructor para inicializar la comunicación
        public LocalizacionUsuario()
        {
            iComunicacion = new LocalizacionComunicacion(); // Corrección: Asegurarse de que LocalizacionComunicacion esté correctamente referenciado
        }

        [TestMethod] // Método principal que ejecuta todas las pruebas
        public void Ejecutar()
        {
            Guardar();  // Prueba para guardar una entidad
            Listar();   // Prueba para listar entidades
            Buscar();   // Prueba para buscar una entidad específica
            Modificar(); // Prueba para modificar una entidad
            Borrar();   // Prueba para eliminar una entidad
        }

        private void Listar()
        {
            var datos = new Dictionary<string, object>();

            // Ejecuta la operación de listar
            var task = iComunicacion!.Listar(datos); // Corrección: Asegurarse de que el método Listar esté definido en ILocalizacionComunicacion
            task.Wait();
            datos = task.Result;

            Assert.IsTrue(!datos.ContainsKey("Error")); // Verifica que no haya errores

            lista = JsonConversor.ConvertirAObjeto<List<Localizacion>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        private void Buscar()
        {
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = entidad!, // Buscar por la entidad definida
                ["Tipo"] = "USUARIO" // Tipo de búsqueda
            };

            // Ejecuta la operación de búsqueda
            var task = iComunicacion!.Buscar(datos); // Corrección: Asegurarse de que el método Buscar esté definido en ILocalizacionComunicacion
            task.Wait();
            datos = task.Result;

            Assert.IsTrue(!datos.ContainsKey("Error")); // Verifica que no haya errores

            lista = JsonConversor.ConvertirAObjeto<List<Localizacion>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        private void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Localizacion() // Corrección: Asegurarse de que Localizacion esté correctamente referenciado
            {
                UsuarioId = 1, // ID de usuario de prueba
                Direccion = "Dirección de Prueba",
                Ciudad = "Ciudad de Prueba",
                Pais = "País de Prueba"
            };
            datos["Entidad"] = entidad!;

            // Ejecuta la operación de guardar
            var task = iComunicacion!.Guardar(datos); // Corrección: Asegurarse de que el método Guardar esté definido en ILocalizacionComunicacion
            task.Wait();
            datos = task.Result;

            Assert.IsTrue(!datos.ContainsKey("Error")); // Verifica que no haya errores

            entidad = JsonConversor.ConvertirAObjeto<Localizacion>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        private void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Direccion = "Nueva Dirección"; // Modifica la dirección
            datos["Entidad"] = entidad!;

            // Ejecuta la operación de modificar
            var task = iComunicacion!.Modificar(datos); // Corrección: Asegurarse de que el método Modificar esté definido en ILocalizacionComunicacion
            task.Wait();
            datos = task.Result;

            Assert.IsTrue(!datos.ContainsKey("Error")); // Verifica que no haya errores

            entidad = JsonConversor.ConvertirAObjeto<Localizacion>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        private void Borrar()
        {
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = entidad! // Define la entidad a eliminar
            };

            // Ejecuta la operación de borrar
            var task = iComunicacion!.Borrar(datos); // Corrección: Asegurarse de que el método Borrar esté definido en ILocalizacionComunicacion
            task.Wait();
            datos = task.Result;

            Assert.IsTrue(!datos.ContainsKey("Error")); // Verifica que no haya errores

            entidad = JsonConversor.ConvertirAObjeto<Localizacion>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}