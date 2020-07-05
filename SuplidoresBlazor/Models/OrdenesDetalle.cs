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
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }
        public string Descripcion { get; set; }

        public decimal Importe { get; set; }

        public OrdenesDetalle()
        {
            ordenDetalleId = 0;
            productoId = 0;
            cantidad = 0;
            costo = 0;
            Descripcion = string.Empty;
            Importe = 0;
        }

        public OrdenesDetalle(int ordenDetalleId, int productoId, int cantidad, decimal costo, string descripcion, decimal importe)
        {
            this.ordenDetalleId = ordenDetalleId;
            this.productoId = productoId;
            this.cantidad = cantidad;
            this.costo = costo;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Importe = importe;
        }
    }
}
