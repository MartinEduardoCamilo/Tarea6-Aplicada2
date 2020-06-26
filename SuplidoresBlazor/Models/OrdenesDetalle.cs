using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuplidoresBlazor.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int ordenDetalleId { get; set; }
        public int ordenId { get; set; }
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }

        public OrdenesDetalle()
        {
            ordenDetalleId = 0;
            ordenId = 0;
            productoId = 0;
            cantidad = 0;
            costo = 0;
        }

        public OrdenesDetalle(int ordenDetalleId, int ordenId, int productoId, int cantidad, decimal costo)
        {
            this.ordenDetalleId = ordenDetalleId;
            this.ordenId = ordenId;
            this.productoId = productoId;
            this.cantidad = cantidad;
            this.costo = costo;
        }
    }
}
