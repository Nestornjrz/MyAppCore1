
using System.ComponentModel.DataAnnotations;

namespace MyAppCore1.Entities
{
    public enum TipoCosina {
        None,
        Italiano,
        Frances,
        Japones,
        Americano
    }
    public class Restaurante
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name ="Nombre del restaurante")]
        public string Nombre { get; set; }
        public TipoCosina Cosina { get; set; }
    }
}
