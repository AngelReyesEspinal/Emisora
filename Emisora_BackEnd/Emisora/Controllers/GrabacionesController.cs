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
    public class GrabacionesController : Controller
    {
        //Dependencia
        private readonly IGrabacionServicio _grabacionServicio;

        public GrabacionesController(IGrabacionServicio grabacionServicio)
        {
            _grabacionServicio = grabacionServicio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _grabacionServicio.MostrarTodo()
            );
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Grabacion modelo)
        {
            return Ok(
                _grabacionServicio.Agregar(modelo)
            );
        }
        
        [HttpPut]
        public IActionResult Put([FromBody]Grabacion modelo)
        {
            return Ok(
                _grabacionServicio.Modificar(modelo)
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _grabacionServicio.Eliminar(id)
            );
        }
    }
}