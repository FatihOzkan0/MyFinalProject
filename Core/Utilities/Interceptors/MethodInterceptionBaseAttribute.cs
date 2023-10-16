using Castle.DynamicProxy;
using System;



namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
    {
        public int Priority { get; set; }     //Priority öncelik demek hangi attiribut önce çalışıcak onu ayarlıyoruz.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
