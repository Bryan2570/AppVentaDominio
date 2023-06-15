using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio.Interfaces
{
    public interface IEditar<TEntidad>
    {
        //metodo editar sin retorno 
        void Editar(TEntidad entidad);

    }
}
