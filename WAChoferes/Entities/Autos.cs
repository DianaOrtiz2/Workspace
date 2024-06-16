using System.Runtime.InteropServices;
using System;
namespace WAChoferes.Entities
{
    public class Autos
    {
        public Autos(){

        }
        public Guid Id { get; set; }
        public string modelo {get; set; }
        public string año {get; set;}
        public string placa {get; set;}
    }
}