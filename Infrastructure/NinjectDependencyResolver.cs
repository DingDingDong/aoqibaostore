using System;
using System.Collections.Generic;
using Ninject;
using Moq;
using System.Web.Mvc;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;
using AoqibaoStore.Concrete;


namespace AoqibaoStore.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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

        private void AddBindings()
        {
            //Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>();
            //mock.Setup(m => m.Categories).Returns(new List<Category> {    
            //    new Category{name = "保健品", imgUrl="product1.jpg", status=1,createDate=DateTime.Now },
            //    new Category{name = "塑身与纤体", imgUrl="product2.jpg", status=1,createDate=DateTime.Now },
            //    new Category{name = "奶粉", imgUrl="product3.jpg", status=1,createDate=DateTime.Now },
            //});
            //kernel.Bind<ICategoryRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();

            EmailSettings emailSettings = new EmailSettings { };

            kernel.Bind<IContactProcessor>().To<EmailContactProcessor>().WithConstructorArgument("settings", emailSettings
                );
            
        }
    }
}