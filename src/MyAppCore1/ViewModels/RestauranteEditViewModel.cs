using MyAppCore1.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyAppCore1.ViewModels {
    public class RestauranteEditViewModel {
        [Required, MaxLength(80)]
        public string Nombre { get; set; }
        public TipoCosina Cosina { get; set; }
    }
}
