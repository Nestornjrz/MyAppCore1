using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1
{
    public interface ISaludo {
        string GetSaludo();
    }
    public class Saludo : ISaludo {
        public string GetSaludo() {
            return "Hola desde Saludo";
        }
    }
}
