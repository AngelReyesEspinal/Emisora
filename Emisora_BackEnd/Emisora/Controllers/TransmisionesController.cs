using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicios;

namespace Emisora.Controllers
{
    [Route("Emisora/[controller]/[action]")]
    public class TransmisionesController : Controller
    {
        //Dependencia
        private readonly ITransmisionServicio _trasmisionServicio;

        public TransmisionesController(ITransmisionServicio trasmisionServicio)
        {
            _trasmisionServicio = trasmisionServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _trasmisionServicio.MostrarTodo()
            );
        }

        [HttpPost]
        public IActionResult Post([FromBody]Transmision modelo)
        {
            return Ok(
                _trasmisionServicio.Agregar(modelo)
            );
        }

        [HttpPut]
        public IActionResult Put([FromBody]Transmision modelo)
        {
            return Ok(
                _trasmisionServicio.Modificar(modelo)
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _trasmisionServicio.Eliminar(id)
            );
        }
    }
}