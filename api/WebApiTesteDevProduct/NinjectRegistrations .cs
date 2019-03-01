using ApplicationProduct;
using ApplicationProduct.Interfaces;
using DomainProduct.Interfaces;
using DomainProduct.Services;
using Ninject.Modules;
using RepositoryProduct.Repositories;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;

namespace WebApiTesteDevProduct
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppBase<>)).To(typeof(AppBase<>));
            Bind<IAppProduct>().To<AppProduct>();
            Bind<IAppCategory>().To<AppCategory>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IServiceProduct>().To<ServiceProduct>();
            Bind<IServiceCategory>().To<ServiceCategory>();

            Bind(typeof(IRepBase<>)).To(typeof(RepBase<>));
            Bind<IRepProduct>().To<RepProduct>();
            Bind<IRepCategory>().To<RepCategory>();
        }
    }
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = this.resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.GetAll(serviceType);
        }
    }
}