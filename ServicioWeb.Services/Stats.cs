using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWeb.Services
{
    //Se crea una clase especial para poder enviar los Stats con JSON
    public class Stats
    {
        public int Mutant { get; set; }
        public int Human { get; set; }
        public decimal Ratio { get; set; }
    }
}
