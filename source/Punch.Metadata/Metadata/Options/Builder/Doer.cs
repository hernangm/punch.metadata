using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class Doer<TModel, TProperty>
    {
        private IMetadataCollector<TModel, TProperty> Metadata { get; set; }

        public Doer(IMetadataCollector<TModel, TProperty> metadataCollection)
        {
            this.Metadata = metadataCollection;
        }

        public IRemoteOptionsConfigBuilder<TModel, TListItem> Of<TListItem>(Expression<Func<TListItem, object>> optionsValue, Expression<Func<TListItem, object>> optionsText)
        {
            var builder = new OptionsConfigBuilder<TModel, TListItem>(new OptionsMetadata<TListItem>());
            Metadata.Add(builder.ListSourceConfig);
            Metadata.Add(new OptionsMetadata(Metadata.PropertyName));
            Metadata.Add(new OptionsValueMetadata(ExpressionHelper.GetExpressionText(optionsValue)));
            Metadata.Add(new OptionsTextMetadata(ExpressionHelper.GetExpressionText(optionsText)));
            return builder;
        }
    }
}
