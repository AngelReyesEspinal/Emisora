using Contexto;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicios
{
    public interface ITransmisionServicio
    {
        bool Agregar(Transmision modelo);
        List<Transmision> MostrarTodo();
        bool Modificar(Transmision modelo);
        bool Eliminar(int id);
    }
    public class TransmisionServicio : ITransmisionServicio
    {
        private readonly EmisoraDbContext _transmisionDbContext;
        public TransmisionServicio(EmisoraDbContext transmisionDbContext)
        {
            _transmisionDbContext = transmisionDbContext;
        }

        public bool Agregar(Transmision modelo)
        {
            try
            {
                _transmisionDbContext.Add(modelo);
                _transmisionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Transmision> MostrarTodo()
        {
            var resultado = new List<Transmision>();

            try
            {
                resultado = _transmisionDbContext.Transmision.ToList();
            }
            catch (Exception)
            {
            }

            return resultado;
        }

        public bool Modificar(Transmision modelo)
        {
            try
            {
                var modeloOriginal = _transmisionDbContext.Transmision.Single(x => x.TransmisionId == modelo.TransmisionId);

                modeloOriginal.Link = modelo.Link;

                _transmisionDbContext.Update(modeloOriginal);
                _transmisionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Eliminar(int id)
        {
            try
            {
                Transmision transmision = (Transmision)_transmisionDbContext.Transmision.Where(x => x.TransmisionId == id).First();
                _transmisionDbContext.Transmision.Remove(transmision);
                _transmisionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
