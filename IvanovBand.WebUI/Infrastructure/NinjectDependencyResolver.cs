using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Concrete;
using IvanovBand.WebUI.Infrastructure.Abstract;
using IvanovBand.WebUI.Infrastructure.Concrete;
using System.Configuration;

namespace IvanovBand.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        private void AddBindings()
        {
            Bind<IArticlesRepository>().To<EFArticleRepository>();
            Bind<IVideoRepository>().To<EFVideoRepository>();
            Bind<IMemberRepository>().To<EFMemberRepository>();
            Bind<ISlideRepository>().To<EFSlideRepository>();
            Bind<ISongRepository>().To<EFSongRepository>();
            Bind<IFeedbackRepository>().To<EFFeedbackRepository>();
            Bind<IConcertRepository>().To<EFConcertRepository>();
            Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}