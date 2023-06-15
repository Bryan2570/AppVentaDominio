using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        //retorna un tipo de entidad filtrado por el ID 
        TEntidad SeleccionarPorId(TEntidadID entidadId);
    }
}
