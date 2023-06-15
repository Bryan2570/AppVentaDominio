using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//IMPORTAMMOS LAS INTERFACES CREADAS PARA PODER USARLAS
using AppVentaDominio.Interfaces;

namespace AppVentaDominio.Interfaces.Repositorios
{
    public interface IRepositoriBase<TEntidad, TEntidadID> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
    }
}
