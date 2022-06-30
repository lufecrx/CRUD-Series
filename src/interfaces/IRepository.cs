using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Series.src.interfaces
{
    public interface IRepository<T>
    {
        List<T> Array();

        T ReturnForId(int id);
        void Insert(T entitie);
        void Delete(int id);
        void Update(int Id, T entitie);
        int NextId();
    }
}