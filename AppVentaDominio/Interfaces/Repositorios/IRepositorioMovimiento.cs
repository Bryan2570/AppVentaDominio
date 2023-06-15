using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentaDominio.Interfaces.Repositorios
{

    //ESTA INTERFACE NO PERMITE EDITAR NI ELIMINAR YA QUE LAS VENTAS NO DEBERIIAN DE CONTAR CON ESTAS OPERACIONES,
    //SE CREA UN METODO ANULAR Y QUE RECIBA EL ID Y PERMITE AMULAR LA VENTA EN CASO DE QUE SUCEDA UN PROBLEMA
    public interface IRepositorioMovimiento<TEntidad,TEntidadID> : IAgregar<TEntidad>,IListar<TEntidad, TEntidadID>,ITransaccion
    {
        void Anular(TEntidadID entidadId);
    }
}
