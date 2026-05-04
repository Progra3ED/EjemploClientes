using EjemploClientes.Models;
using System.Text.Json;

namespace EjemploClientes.Services
{
    public class ClienteService
    {
        private readonly string _rutaArchivo = "clientes.json";
        private readonly int _veces = 20;

        public void Guardar(Cliente nuevoCliente)
        {
            
            //Leer la lista actual (o crear una nueva si el archivo no existe)
            List<Cliente> lista = new();
            if (File.Exists(_rutaArchivo))
            {
                var jsonExistente = File.ReadAllText(_rutaArchivo);
                lista = JsonSerializer.Deserialize<List<Cliente>>(jsonExistente) ?? new();
            }
            

            //Agregar el nuevo cliente a la lista
            lista.Add(nuevoCliente);

            //Serializar el Json y escribir en el disco
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var nuevoJson = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(_rutaArchivo, nuevoJson);
        }

        //Devuelve una lista de Clientes leidos desde el archivo
        public List<Cliente> Leer()
        {
            if (!File.Exists(_rutaArchivo))
                return new List<Cliente>();

            //El try sirve para "atrapar" errores y que no los muestre en la pantalla
            //Dentro del try (probar) se pone el código que vamos a ejecutar, si por alguna
            //razón ese código da error, por ejemplo en este caso si el archivo no existe
            //en lugar de dar un error en pantalla, se salta el error y ejecuta lo que está en 
            //en el catch
            try
            {
                var json = File.ReadAllText(_rutaArchivo);

                //los ?? se les llama operador de fusión NULL
                //Si la operación de la izquierda del ?? por algún razón es NULL
                //entonces devuelve lo que está después del ??
                //en este caso devuelve una lista vacía (pero no NULL para eviatar errores)
                
                
                return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();

                
            }
            catch
            {
                return new List<Cliente>();
            }
        }
    }
}
