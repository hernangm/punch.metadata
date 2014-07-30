using Punch.Serialization;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public class KnockoutContractResolverTests
    {
        [Test]
        public void has_knockout_attribute()
        {
            Assert.IsFalse(IgnoreKnockoutDecoratedPropertiesContractResolver.HasKnockoutAttribute(typeof(PeliculaViewModel).GetProperty("Nombre")));
            Assert.IsTrue(IgnoreKnockoutDecoratedPropertiesContractResolver.HasKnockoutAttribute(typeof(PeliculaViewModel).GetProperty("KnockoutProperty")));
        }
    }
}
