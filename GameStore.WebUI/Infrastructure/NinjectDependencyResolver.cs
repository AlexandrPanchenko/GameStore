using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using System.Configuration;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using Moq;

namespace GameStore.WebUI.Infrastructure
{
    class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        object IDependencyResolver.GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        private void AddBindings()
        {
            //Mock<IGameRepository> mock = new Mock<IGameRepository>();
            //mock.Setup(m => m.Games).Returns(new List<Game>
            //{
            //    new Game {Name="Mafia 3", Price=120 },
            //    new Game {Name="GTA 5", Price=346 },
            //    new Game {Name="The Sims 4", Price=124 }
            //});
            //_kernel.Bind<IGameRepository>().ToConstant(mock.Object);
            _kernel.Bind<IGameRepository>().To<EFGameRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                   .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            _kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            _kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }

    }
}
