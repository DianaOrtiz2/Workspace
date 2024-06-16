using System.ComponentModel.DataAnnotations;

namespace WAChoferes.Models
{
    public class DriverModel
{
    public DriverModel()
    {

    }
    public Guid Id {get; set;}

    [Required]
    public  string? Nombre{ get; set; }
    [Required]
    public  string? Telefono {get; set;}
    [Required]
    public string? NumLicencia {get; set;}
    
    

}


}


