using Day02.Models;
using System.Collections.Generic;

namespace Day02.Service
{
    public interface IEntityService<T>
    {
        int Add(T newCourse);
        int Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        int Update(int id, T newCourse);
    }
}
