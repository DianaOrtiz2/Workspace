using System.ComponentModel.DataAnnotations;

namespace WAChoferes.Models
{
    public class AutosModel
{
    public AutosModel()
    {

    }
    public Guid Id {get; set;}

    [Required]
    public string modelo {get; set; }
    [Required]
    public string año {get; set;}
    [Required]
    public string placa {get; set;}
    
    

}

}