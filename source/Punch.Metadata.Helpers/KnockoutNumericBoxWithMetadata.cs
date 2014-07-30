using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Metadata;

namespace Punch.Helpers
{
    public class KnockoutNumericBoxWithMetadata<TModel> : KnockoutNumericBox<TModel> 
    {
        private NumericMetadata Metadata { get; set; }

        public KnockoutNumericBoxWithMetadata(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
            if (!this.Context.MetadataProvider.Contains<TModel, object, NumericMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(NumericMetadata).Name));
            }
            this.Metadata = this.Context.MetadataProvider.FirstOrDefault<TModel, object, NumericMetadata>(binding);
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.Numeric(Binding, this.Metadata);
        }
    }

    public static class NumericKnockoutWithMetadataBindingExtensions
    {
        public static TReturn Numeric<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding, NumericMetadata config)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutNumericBindingWithMetadata<TModel>(binding, config));
            return bindings.ReturnObject;
        }
    }
}
