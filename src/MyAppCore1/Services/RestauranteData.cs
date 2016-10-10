using MyAppCore1.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MyAppCore1.Services {
    public interface IRestauranteData {
        IEnumerable<Restaurante> GetAll();
        Restaurante Get(int id);
    }
    public class InMemoryRestauranteData : IRestauranteData {
        public InMemoryRestauranteData() {
            _restaurantes = new List<Restaurante> {
                new Restaurante {Id=1,Nombre="La casa de las empanadas" },
                new Restaurante {Id=2,Nombre="Comida china" },
                new Restaurante {Id=3,Nombre="Otro restaurante" }
            };
        }
        public IEnumerable<Restaurante> GetAll() {
            return _restaurantes;
        }

        public Restaurante Get(int id) {
            return _restaurantes.FirstOrDefault(r=>r.Id == id);
        }

        List<Restaurante> _restaurantes;
    }
}
