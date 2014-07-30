using System;
using System.Text.RegularExpressions;
using Punch.Core;

namespace Punch.Metadata
{

    internal class MetadataNameResolver : NameResolverBase
    {
        protected override string GetConventionalName(Type type)
        {
            return Regex.Replace(type.ToTypeNameWithoutGenericArity(), "Metadata$", string.Empty);
        }
    }
}
