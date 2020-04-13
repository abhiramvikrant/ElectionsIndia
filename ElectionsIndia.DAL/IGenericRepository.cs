using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionsIndia.DAL
{
   public interface IGenericRepository<T> 
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T Update(T t);
        int Delete(T t);

        int Insert(T t);


    }
}
