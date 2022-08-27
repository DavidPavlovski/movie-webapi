﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByGenre(int genre);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T id);
    }
}