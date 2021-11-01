using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVuelos.models
{
    public class SP_Vuelos
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_Vuelo { get; set; }
        public string Cod_Vuelo { get; set; }
        public string Id_Aerolinea { get; set; }
        public string Ciudad_Origen { get; set; }
        public string Ciudad_Destino { get; set; }
        public string Fecha { get; set; }
        public string Hora_Salida { get; set; }
        public string Hora_Llegada { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Id_Estado { get; set; }
    }
}
