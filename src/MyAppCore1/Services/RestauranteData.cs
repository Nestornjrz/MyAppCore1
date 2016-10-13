using MyAppCore1.Entities;
using System.Collections.Generic;
using System;
using System.Linq;


namespace MyAppCore1.Services {
    public interface IRestauranteData {
        IEnumerable<Restaurante> GetAll();
        Restaurante Get(int id);
        Restaurante Add(Restaurante nuevoRestaurante);
        void Commit();
    }

    public class SqlRestauranteData : IRestauranteData {
        private MyAppCore1DbContext _context;

        public SqlRestauranteData(MyAppCore1DbContext context) {
            _context = context;
        }

        public Restaurante Add(Restaurante nuevoRestaurante) {
            _context.Add(nuevoRestaurante);            
            return nuevoRestaurante;
        }

        public void Commit() {
            _context.SaveChanges();
        }

        public Restaurante Get(int id) {
            return _context.Restaurantes.FirstOrDefault(r=>r.Id == id);
        }

        public IEnumerable<Restaurante> GetAll() {
            return _context.Restaurantes;
        }
    }
    public class InMemoryRestauranteData : IRestauranteData {
        static InMemoryRestauranteData() {
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
     
        public Restaurante Add(Restaurante nuevoRestaurante) {
            nuevoRestaurante.Id = _restaurantes.Max(r=>r.Id) + 1;
            _restaurantes.Add(nuevoRestaurante);
            return nuevoRestaurante;
        }

        public void Commit() {
            //No aplicable
        }

        static List<Restaurante> _restaurantes;
    }
}
