using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretMVC.Models.Repository
{
   public interface IService<T>
    {
       List<T> GetALL();
    T GetByID(int EntityId);
    int Save(T Entity);
    int Update(T Entity);
    int Delete(T Entity);

    }
}
