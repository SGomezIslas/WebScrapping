using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen {  get; set; }
        public float Precio { get; set; }
        public List<object> Productos { get; set; }
    }
}
