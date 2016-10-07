using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.Controllers
{
    [Route("empresa/[controller]/[action]")]
    public class AboutController
    {    
        public string Telefono() {
            return "0981 263.726";
        }
        
        public string Direccion() {
            return "Paraguay";
        }
    }
}
