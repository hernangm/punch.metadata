using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Metadata;


namespace Punch.Helpers
{
    public class KnockoutDatePickerWithMetadata<TModel> : KnockoutDatePicker<TModel> 
    {
        private DatePickerMetadata Metadata { get; set; }

        public KnockoutDatePickerWithMetadata(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
            if (!this.Context.MetadataProvider.Contains<TModel, object, DatePickerMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(DatePickerMetadata).Name));
            }
            this.Metadata = this.Context.MetadataProvider.FirstOrDefault<TModel, object, DatePickerMetadata>(binding);
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.DatePicker(Binding, Metadata);
        }
    }

    public static class KnockoutDatePickerBindingWithMetadataExtensions
    {
        public static TReturn DatePicker<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, object>> expression, DatePickerMetadata config)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutDatePickerBindingWithMetadata<TModel>(expression, config));
            return bindings.ReturnObject;
        }
    }
}