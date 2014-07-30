using Punch.Core;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
using Ninject;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public abstract class KnockoutMetadataAdapterBaseTests : EqipKnockoutMetadataBaseTest
    {
        protected KnockoutMetadataAdapter Adapter { get; set; }

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            KnockoutMetadataProvider.RegisterMetadataProvider(new Provider(base.HttpContext.Object.Cache, base.Kernel.Get<IMetadataFactory>()));
            Adapter = new KnockoutMetadataAdapter();
        }
    }
}
