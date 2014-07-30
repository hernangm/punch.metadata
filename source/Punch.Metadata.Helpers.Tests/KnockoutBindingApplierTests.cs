using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
using Eqip.Metadata.Ninject;
using Moq;
using Ninject;
using NUnit.Framework;

namespace Punch.Metadata.Helpers.Tests
{
    public class KnockoutBindingApplierTests
    {
        private ViewContext ViewContext { get; set; }
        private StandardKernel Kernel { get; set; }

        [SetUp]
        public void Setup()
        {
            this.ViewContext = new Mock<ViewContext>(
                new ControllerContext(new Mock<HttpContextBase>().Object, new RouteData(), new Mock<ControllerBase>().Object),
                new Mock<IView>().Object,
                new FormatViewModel(),
                new TempDataDictionary()
            ).Object;

            this.Kernel = new StandardKernel();
            this.Kernel.Bind<IMetadataFactory>().ToConstant(new NinjectMetadataFactory(this.Kernel));
            Eqip.Metadata.Ninject.AssemblyScanner.FindConfiguratorsInAssembly(Assembly.GetExecutingAssembly()).ForEach(
                match => this.Kernel.Bind(match.InterfaceType).To(match.ConfiguratorType)
            );
        }


    }
}
