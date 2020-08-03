﻿using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreERP.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>where TEntity : class
    {
        private static readonly ERPContext _context;
        private static readonly DbSet<TEntity> _entities;

        public static Repository<TEntity> Instance { get; } = new Repository<TEntity>();

        static Repository()
        {
            _context = new ERPContext();
            _context.Database.SetCommandTimeout(240);
            _entities = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {            
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {            
            return _entities.Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }
    }
}
