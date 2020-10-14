﻿using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        int SaveChanges();

        int Remove(TEntity entity);
    }
}
