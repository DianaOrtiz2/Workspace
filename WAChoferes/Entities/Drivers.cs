
namespace WAChoferes.Entities

{
    public class Drivers
    {
        public Guid Id {get; set;}
        public  string? Nombre{ get; set; }
        public  string? Telefono {get; set;}
        public string? NumLicencia {get; set;}
        public DateTime FechaVencimiento {get; set;}

        
    }
}