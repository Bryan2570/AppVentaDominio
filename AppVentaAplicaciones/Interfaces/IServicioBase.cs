using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVentaDominio.Interfaces;
using AppVentaDominio.Interfaces.Repositorios;

namespace AppVentaAplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
    }
}
