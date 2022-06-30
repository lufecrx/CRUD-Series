using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Series.src.interfaces;

namespace CRUD_Series.src
{
    public class SerieRepository : IRepository<SerieClass>
    {

        private List<SerieClass> arraySerie = new List<SerieClass>();


        public List<SerieClass> Array()
        {
            return arraySerie;
        }

        public void Delete(int id)
        {
            arraySerie[id].Remove();
        }

        public void Insert(SerieClass entitie)
        {
            arraySerie.Add(entitie);
        }

        public int NextId()
        {
            return arraySerie.Count;
        }

        public SerieClass ReturnForId(int id)
        {
            return arraySerie[id];
        }

        public void Update(int Id, SerieClass entitie)
        {
            arraySerie[Id] = entitie;
        }
    }
}