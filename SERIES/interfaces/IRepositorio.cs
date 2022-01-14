using System.Collections.Generic;

namespace SERIES
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaporId(int id);
         void Insere(T entidades);
         void Exclui (int id);
         void Atualiza (int id, T entidades);
         int ProximoId();
         
    }
}