using Contexto;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicios
{
    public interface IGrabacionServicio
    {
        bool Agregar(Grabacion modelo);
        List<Grabacion> MostrarTodo();
        bool Eliminar(int id);
        bool Modificar(Grabacion modelo);
    }

    public class GrabacionServicio : IGrabacionServicio
    {
        private readonly EmisoraDbContext _grabacionDbContext;
        public GrabacionServicio(EmisoraDbContext grabacionDbContext)
        {
            _grabacionDbContext = grabacionDbContext;
        }

        public bool Agregar(Grabacion modelo)
        {
            try
            {
                _grabacionDbContext.Add(modelo);
                _grabacionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Grabacion> MostrarTodo()
        {
            var resultado = new List<Grabacion>();

            try
            {
                resultado = _grabacionDbContext.Grabacion.OrderByDescending(x => x.GrabacionId).ToList();
            }
            catch (Exception)
            {
            }

            return resultado;
        }

        public bool Eliminar(int id)
        {
            try
            {
                Grabacion usuario = (Grabacion)_grabacionDbContext.Grabacion.Where(x => x.GrabacionId == id).First();
                _grabacionDbContext.Grabacion.Remove(usuario);
                _grabacionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Modificar(Grabacion modelo)
        {
            try
            {
                var modeloOriginal = _grabacionDbContext.Grabacion.Single(x => x.GrabacionId == modelo.GrabacionId);

                modeloOriginal.Link = modelo.Link;

                _grabacionDbContext.Update(modeloOriginal);
                _grabacionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
