using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq

namespace ElectionsIndia.DAL
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly ElectionsIndiaDBContext context;

        
        public GenericRepository(ElectionsIndiaDBContext cont)
        {
            this.context = cont;
          
        }


        public int Delete(T t)
        {
          

        public IEnumerable<T> GetAll()
        {
           
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }

        public T Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
