using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_MVC_Test_Lab2.Data
{
    public interface IApiRequestSend<T>
    {
        IEnumerable<T> GetAllData();
        void AddEntity(T entity);
        void ModifyEntity(int id, T entity);
        void DeleteEntity(T entity);
    }

}
