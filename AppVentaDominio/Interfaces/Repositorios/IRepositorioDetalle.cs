using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVentaDominio.Interfaces;

namespace AppVentaDominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID> :IAgregar<TEntidad>,ITransaccion
    {
    }
}
