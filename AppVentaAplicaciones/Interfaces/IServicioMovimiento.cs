using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVentaDominio.Interfaces;
using AppVentaDominio.Interfaces.Repositorios;

namespace AppVentaAplicaciones.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad,TEntidadID>
    {
        void Anular(TEntidadID entidadId);
    }
}
