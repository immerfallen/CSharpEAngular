using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {

        }

        [HttpGet]
        public Evento Get()
        {
            return new Evento()
            {
                EventoId = 1,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                Tema = "Selva",
                Local = "Terra",
                QtdPessoas = 13,
                Lote = "qw23",
                ImagemUrl = "google.com"
            };
        }

    }
}
