using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGeneric
    {
        public interface IGeneric<T> where T : class
        {
            Task Add(T Object);
            Task Update(T Object);
            Task Delete(T Object);
            Task<T> GetEntityById(int Id);
            Task<List<T>> List();
        }

    }
}