using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Metadata;

namespace Punch.Helpers
{

    public class KnockoutTimePickerWithMetadata<TModel> : KnockoutTimePicker<TModel> 
    {
        private TimePickerMetadata Metadata { get; set; }

        public KnockoutTimePickerWithMetadata(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
            if (!this.Context.MetadataProvider.Contains<TModel, object, TimePickerMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(TimePickerMetadata).Name));
            }
            this.Metadata = this.Context.MetadataProvider.FirstOrDefault<TModel, object, TimePickerMetadata>(binding);
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.TimePicker(Binding, Metadata);
        }
    }

    public static class KnockoutTimePickerWithMetadataTagBuilderExtensions
    {
        public static TReturn TimePicker<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding, TimePickerMetadata config)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutTimePickerBindingWithMetadata<TModel>(binding, config));
            return bindings.ReturnObject;
        }
    }
}
