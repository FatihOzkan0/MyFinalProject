 
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Class ile Çalışıyoruz.Bu tasarım Generic Repository Design Patern.
    public interface IEntityRepository<T> where T : class, IEntity, new()  //Generic yapımızı kısıtlıyoruz T hem referans tip olmalı hem de IEntity olucak yada referans alıcak.    
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);  //Filtreleme işlemi listelerken filtremize görede listeyi getirebiliriz. filter= null filtreleme kullanmadan da listeleye bilirsin demek.
        T Get(Expression<Func<T, bool>> filter);   //Tek bir data getirmek için kullanılır.Burada filter null olmaması filtre koymanın zorunlu olduğunu belirtir.
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);


    }
}
