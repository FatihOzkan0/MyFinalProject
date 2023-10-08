using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{

    //Repositorydeki methodlarımızı doldurduğumuz yer.Bunları Core katmanında yazma sebebimiz bunların her proje için evrensel olması.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using kullanmamızın nedeni context yapısı pahalı ve büyüktür using kullanarak işi bitince garbage collector onu çöpe atar.Bu da performansımızı arttırır.

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //turnary operator kullandık.Açıklama : filtre null mı bak null ise product set et git ve listele , ":" null değil ise filtreye göre listele.

            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity  entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
