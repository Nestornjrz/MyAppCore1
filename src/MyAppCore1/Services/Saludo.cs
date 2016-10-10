using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.Services
{
    public interface ISaludo {
        string GetSaludo();
    }
    public class Saludo : ISaludo {
        private string _saludo;

        public Saludo(IConfiguration configuration) {
            _saludo = configuration["Saludo"];
        }
        public string GetSaludo() {
            return _saludo;
        }
    }
}
