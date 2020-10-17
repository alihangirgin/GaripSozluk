using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _contextLog;
        private readonly DbSet<Log> _dbSet;
        public LogRepository(LogDbContext context) 
        {
            _contextLog = context;
            _dbSet = _contextLog.Set<Log>();
        }


        public Log Add(Log entity)
        {
            var entityEntry = _dbSet.Add(entity);
            return entityEntry.Entity;
        }


        public Log Get(Expression<Func<Log, bool>> expression)
        {
            var result = _dbSet.Where(expression).FirstOrDefault();
            return result;
        }

        public IQueryable<Log> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<Log> GetAll(Expression<Func<Log, bool>> expression)
        {
            var result = _dbSet.Where(expression).AsQueryable();
            return result;
        }

        public Log Update(Log entity)
        {
            var entityEntry = _dbSet.Update(entity);
            return entityEntry.Entity;
        }

        public int SaveChanges()
        {
            return _contextLog.SaveChanges();
        }

        public int Remove(Log entity)
        {
            _contextLog.Remove(entity);
            return _contextLog.SaveChanges();
        }

    }
}
