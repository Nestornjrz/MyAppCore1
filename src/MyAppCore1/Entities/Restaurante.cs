
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
        public string Nombre { get; set; }
        public TipoCosina Cosina { get; set; }
    }
}
