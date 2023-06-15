using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio.Interfaces.Repositorios
{
    //esta entidad recibe un valor generico que son las entidades de dominio
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad entidad);


    }
}
