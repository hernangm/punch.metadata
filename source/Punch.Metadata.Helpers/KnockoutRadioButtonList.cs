using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;
using Punch.Metadata;

namespace Punch.Helpers
{

    public class KnockoutRadioButtonList<TModel, TProperty> : KnockoutTagBaseOfTModel<KnockoutRadioButtonList<TModel, TProperty>, TModel, TProperty>
        
    {
        private OptionsMetadata OptionsMetadata { get; set; }
        private OptionsTextMetadata OptionsTextMetadata { get; set; }
        private OptionsValueMetadata OptionsValueMetadata { get; set; }

        public KnockoutRadioButtonList(KnockoutContext<TModel> context, Expression<Func<TModel, TProperty>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("ol", context, binding, instancesNames, aliases)
        {
            if (!this.Context.MetadataProvider.Contains<TModel, TProperty, OptionsMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(OptionsMetadata).Name));
            }
            if (!this.Context.MetadataProvider.Contains<TModel, TProperty, OptionsTextMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(OptionsTextMetadata).Name));
            }
            if (!this.Context.MetadataProvider.Contains<TModel, TProperty, OptionsValueMetadata>(binding))
            {
                throw new ArgumentException("Metadata does not contain the appropriate config ({0})".FormatWith(typeof(OptionsValueMetadata).Name));
            }
            this.OptionsMetadata = this.Context.MetadataProvider.FirstOrDefault<TModel, TProperty, OptionsMetadata>(binding);
            this.OptionsTextMetadata = this.Context.MetadataProvider.FirstOrDefault<TModel, TProperty, OptionsTextMetadata>(binding);
            this.OptionsValueMetadata = this.Context.MetadataProvider.FirstOrDefault<TModel, TProperty, OptionsValueMetadata>(binding);
            this.AddBindingsDefinedThroughMetadata = false;
        }


        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            var id = "'{0}_' + $index()".FormatWith(GetPropertyName());

            var radio = new KnockoutRadioButton("$parent.{0}".FormatWith(GetPropertyName())).WithoutLabel();
            radio.Custom("checkedValue", this.OptionsValueMetadata.Binding.Value, false);
            radio.Attr("id", id, false);

            var span = new KnockoutTag("span", this.OptionsTextMetadata.Binding.Value);

            var label = new KnockoutTagBuilder("label");
            label.Bindings.Attr("for", id, false);
            label.InnerHtml += radio.ToHtmlString();
            label.InnerHtml += span.ToHtmlString();

            tagBuilder.InnerHtml = @"<li>{0}</li>".FormatWith(label.ToString());
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Custom("foreach", this.OptionsMetadata.Binding.Value, false);
        }
    }

    public static class KnockoutHtmlExtensions
    {
        public static KnockoutRadioButtonList<TModel, TProperty> RadioButtonsFor<TModel, TProperty>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, TProperty>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutRadioButtonList<TModel, TProperty>(html.Context, binding, data.InstanceNames, data.Aliases);
        }

    }
}
