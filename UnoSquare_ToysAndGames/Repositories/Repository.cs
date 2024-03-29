﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnoSquare_ToysAndGames.Models;
using Microsoft.EntityFrameworkCore;
using UnoSquare_ToysAndGames.Repositories;

namespace UnoSquare_ToysAndGames.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ProductDataContext context;
        private DbSet<T> entities;
        public Repository(ProductDataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
