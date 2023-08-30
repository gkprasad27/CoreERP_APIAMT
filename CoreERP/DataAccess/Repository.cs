using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreERP.DataAccess
{
    public class Repository<TEntity> :ERPContext, IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ERPContext _context;
        private readonly DbSet<TEntity> _entities;

        public static Repository<TEntity> Instance = new Repository<TEntity>();

        public Repository()
        {
            _context = new ERPContext();
            _entities = _context.Set<TEntity>();
        }

        public Repository(ERPContext context)
        {
            _context = new ERPContext();
            _entities = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            //Helper.PreAddProcess()
            _entities.AddRange(entities);
            //Helper.PostAddProcess()
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();

        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
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
            //var j = new[] { typeof(TblLanguage), typeof(TblJvdetails), typeof(TblLedgerPosting), typeof(TblLocation) };
            //GetAll<TblLanguage>(j);
            return _entities;
        }

        //public virtual IEnumerable<TResult> GetAll<TResult>(Type[] types)
        //{
        //    _context.GetType().GetProperty(types[0].Name);
        //    IQueryable outer;
        //    outer.Provider.
        //    //for (int i = 0; i < types.Length; i++)
        //    //{
        //    //    MethodInfo methodInfo = _context.GetType().GetMethod("Set");
        //    //    IQueryable main;
        //    //    switch(i)
        //    //    {
        //    //        case 0:
        //    //            methodInfo = methodInfo.MakeGenericMethod(types[0]);                        
        //    //            methodInfo.Invoke(_context, null).;
        //    //            break;
        //    //        default:
        //    //            break;

        //    //    }
        //    //}

        //    return new List<TResult>();
        //}

        //public static class TypeHelper
        //{
        //    public static DbSet<Type> GetTypedDbSet<T>(this DbSetFinder dbSetFinder, Type type )
        //    {
        //        dbSetFinder.FindSets(type).
        //    }
        //}

    }
}
 
