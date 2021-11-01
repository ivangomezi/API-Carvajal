using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVuelos.models
{
    public class Vuelos
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_Vuelo { get; set; }
        public string Cod_Vuelo { get; set; }
        public int Id_Aerolinea { get; set; }
        public int Ciudad_Origen { get; set; }
        public int Ciudad_Destino { get; set; }
        public string Fecha { get; set; }
        public string Hora_Salida { get; set; }
        public string Hora_Llegada { get; set; }
        public string Fecha_Creacion { get; set; }
        public int Id_Estado { get; set; }
    }
}
