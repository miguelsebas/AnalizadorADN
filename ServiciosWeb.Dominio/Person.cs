using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb.Dominio
{
    public class Person
    {
        public long Id { get; set; }
        public string DNA { get; set; }
        public Nullable<byte> Mutant { get; set; }
    }
}
