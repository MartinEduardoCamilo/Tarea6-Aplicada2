using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuplidoresBlazor.Models
{
    public class Productos
    {
        [Key]
        public int productoId { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public int inventario { get; set; }

        public Productos()
        {
            productoId = 0;
            descripcion = string.Empty;
            costo = 0;
            inventario = 0;
        }

        public Productos(int productoId, string descripcion, decimal costo, int inventario)
        {
            this.productoId = productoId;
            this.descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            this.costo = costo;
            this.inventario = inventario;
        }
    }
}
