using ExamenP3YulianaCapito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3YulianaCapito.Interfaces
{
    public interface IAreopuertoRepository
    {
        List<AreopuertoYC> BuscarAreopuertos(string busqueda);
        void GuardarAeropuertos(List<HistorialYC> aeropuertos);
        List<HistorialYC> ObtenerAeropuertosGuardados();
    }
}
