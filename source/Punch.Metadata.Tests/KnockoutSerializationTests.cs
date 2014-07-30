using Punch.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public class KnockoutSerializationTests
    {

        [Test]
        public void serialize_without_knockout_decorated_properties()
        {
            var pelicula = new PeliculaViewModel()
            {
                Nombre = "Hernan",
            };
            var json = JsonConvert.SerializeObject(pelicula, Formatting.None, new JsonSerializerSettings { ContractResolver = new IgnoreKnockoutDecoratedPropertiesContractResolver() });
            JObject obj = JObject.Parse(json);
            Assert.IsNull(obj["KnockoutProperty"]);
        }

        [Test]
        public void serialize_also_takes_into_account_jsonignore()
        {
            var pelicula = new PeliculaViewModel()
            {
                Nombre = "Hernan",
            };
            var json = JsonConvert.SerializeObject(pelicula, Formatting.None, new JsonSerializerSettings { ContractResolver = new IgnoreKnockoutDecoratedPropertiesContractResolver() });
            JObject obj = JObject.Parse(json);
            Assert.IsNull(obj["MustIgnore"]);
        }
    }
}
