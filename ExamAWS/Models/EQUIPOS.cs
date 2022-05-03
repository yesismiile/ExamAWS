using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAWS.Models
{
    [Table("EQUIPOS")]
    public class EQUIPOS
    {
        [Key]
        [Column("IDEQUIPO")]
        public int IdEquipo { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("CHAMPIONS")]
        public int Champions { get; set; }
        [Column("WEB")]
        public string Web { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

    }

}
