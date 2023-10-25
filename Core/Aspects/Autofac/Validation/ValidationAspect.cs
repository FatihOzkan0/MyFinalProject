using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    //Aspect : Business işşleminin başında sonunda veya ortasında çalışacak işlemler. 

    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)       //Attiributelerin tipini Type ile atıyoruz.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))  //validatorType ın IValidator mu diye kontrol ediyor.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;    //Yukarıda kontrol işlemi yapıldıkdan sonra validatorType eşitleniyor.
        }
        protected override void OnBefore(IInvocation invocation)      //Validation işlemin başında çalışacağı için OnBefore çağırıyoruz.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //Çalışma anında ınstance oluşturur CreateInstance metodu.ProductValidator newler. 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];     //ProductValidator un tipini yakalar , productdır o tipde.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  //ProductValidator ın yazıldığı add methodunu gezer ve eğer product type ise validate işlemini yapar.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
