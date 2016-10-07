using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Telefono() {
            return "0981 263.726";
        }

        [Route("direccion")]
        public string Direccion() {
            return "Paraguay";
        }
    }
}
