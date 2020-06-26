using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuplidoresBlazor.Models
{
    public class Ordenes
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 1000000.")]
        public int ordenId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime fecha { get; set; }

        [Range(1, 1000000, ErrorMessage = "Debe elegir un suplidor.")]
        public int suplidorId { get; set; }

        [Required(ErrorMessage = "El campo total no puede estar vacio.")]
        [Range(1, 100000000, ErrorMessage = "El rango es de 1 a 1000000.")]
        public decimal monto { get; set; }

        [ForeignKey("ordenId")]
        public virtual List<OrdenesDetalle> OrdenDetalles { get; set; }

        public Ordenes()
        {
            ordenId = 0;
            fecha = DateTime.Now;
            suplidorId = 0;
            monto = 0;
            OrdenDetalles = new List<OrdenesDetalle>();
        }

        public Ordenes(int ordenId, DateTime fecha, int suplidorId, decimal monto, List<OrdenesDetalle> ordenDetalles)
        {
            this.ordenId = ordenId;
            this.fecha = fecha;
            this.suplidorId = suplidorId;
            this.monto = monto;
            OrdenDetalles = ordenDetalles ?? throw new ArgumentNullException(nameof(ordenDetalles));
        }
    }
}
