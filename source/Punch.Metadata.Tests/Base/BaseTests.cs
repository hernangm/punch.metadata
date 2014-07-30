using System.Reflection;
using System.Web;
using Punch.Base.Tests;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
using Eqip.Metadata.Ninject;
using Moq;
using Ninject;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public abstract class EqipKnockoutMetadataBaseTest : BaseTest
    {
        protected StandardKernel Kernel { get; set; }

        [SetUp]
        public virtual void Setup()
        {
            this.Kernel = new StandardKernel();
            this.Kernel.Bind<IMetadataFactory>().ToConstant(new NinjectMetadataFactory(this.Kernel));
            AssemblyScanner.FindConfiguratorsInAssembly(Assembly.GetExecutingAssembly()).ForEach(
                match => this.Kernel.Bind(match.InterfaceType).To(match.ConfiguratorType)
            );
        }
    }
}
