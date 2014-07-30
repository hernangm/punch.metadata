using System;
using System.Linq.Expressions;
using Punch.Bindings;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class EnableMetadata<TModel> : MetadataBindingBase<KnockoutEnableBinding<TModel>>
    {
        public EnableMetadata(KnockoutEnableBinding<TModel> condition)
            : base(condition) { }

        public EnableMetadata(Expression<Func<TModel, bool>> condition)
            : this(new KnockoutEnableBinding<TModel>(condition)) { }
    }

    public static class EnableExtensions
    {

        public static IMetadataCollectorOptions<TModel, TProperty> EnableWhen<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection, Expression<Func<TModel, bool>> condition)
        {
            return metadataCollection.Add(new EnableMetadata<TModel>(condition));
        }

    }
}
