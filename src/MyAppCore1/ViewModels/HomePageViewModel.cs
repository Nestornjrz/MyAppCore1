using MyAppCore1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.ViewModels
{
    public class HomePageViewModel
    {
        public string MensajeActual { get; set; }
        public IEnumerable <Restaurante> Restaurantes { get; set; }
    }
}
