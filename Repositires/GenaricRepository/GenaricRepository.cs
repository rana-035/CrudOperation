using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositires
{
    public class GenaricRepository<T> where T : BaseModel
    {
        private DbSet<T> db;
        public EntitiesContext Context;
        public GenaricRepository(EntitiesContext context)
        {
            Context = context;
            db = context.Set<T>();
        }
        public T Add(T T)
        {
            return db.Add(T);
        }
        public IEnumerable<T> GetAll()
        {
            return db;
        }
        public T GetByID(int ID)
        {
            return db.FirstOrDefault(i => i.ID == ID);
        }
        public IEnumerable<T> Get(Expression<Func<T,bool>> filter)
        {
            return db.Where(filter);
        }
        public T Update(T T)
        {
            if (!db.Local.Any(i => i.ID == T.ID))
                db.Attach(T);
            Context.Entry(T).State = EntityState.Modified;
            //db.AddOrUpdate(T);
           // Context.Set<T>().AddOrUpdate(T);
            return T;
        }
        public T UpdateForDelete(T T)
        {
            if (!db.Local.Any(i => i.ID == T.ID))
                db.Attach(T);
            //Context.Entry(T).State = EntityState.Modified;
            db.AddOrUpdate(T);
            // Context.Set<T>().AddOrUpdate(T);
            return T;
        }
        public void Remove(T T)
        {
            if (!db.Local.Any(i => i.ID == T.ID))
                db.Attach(T);
            db.Remove(T);
        }
    }
}
