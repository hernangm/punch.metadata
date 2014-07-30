using Eqip.Metadata;

namespace Punch.Metadata
{
    public class TooltipConfig<TModel> : MetadataBindingConfig<KnockoutTooltipBinding<TModel>>
    {
        public TooltipConfig(KnockoutTooltipBinding<TModel> text) : base(text) { }
    }

    public static class ConfigBagBuilderExtensions
    {
        public static IConfigBagBuilderOptions<TModel, TProperty> WithTooltip<TModel, TProperty>(this IConfigBagBuilder<TModel, TProperty> configBagBuilder, string tooltipText)
        {
            return configBagBuilder.SetConfig(new TooltipConfig<TModel>(tooltipText));
        }
    }

    //api.options = {
    //    prerender: false,
    //    id: false,
    //    overwrite: true,
    //    metadata: {
    //        type: 'class'
    //    },
    //    content: {
    //        text: true,
    //        attr: 'title',
    //        title: {
    //            text: false,
    //            button: false
    //        }
    //    },
    //    position: {
    //        my: 'top left',
    //        at: 'bottom right',
    //        target: false,
    //        container: false,
    //        viewport: false,
    //        adjust: {
    //            x: 0, y: 0,
    //            mouse: true,
    //            method: 'flip',
    //            resize: true
    //        },
    //        effect: true
    //    },
    //    show: {
    //        target: false,
    //        event: 'mouseenter',
    //        effect: true,
    //        delay: 90,
    //        solo: false,
    //        ready: false,
    //        modal: {
    //            on: false,
    //            effect: true,
    //            blur: true,
    //            keyboard: true
    //        }
    //    },
    //    hide: {
    //        target: false,
    //        event: 'mouseleave',
    //        effect: true,
    //        delay: 0,
    //        fixed: false,
    //        inactive: false,
    //        leave: 'window',
    //        distance: false
    //    },
    //    style: {
    //        classes: '',
    //        widget: false,
    //        tip: {
    //            corner: true,
    //            mimic: false,
    //            method: true,
    //            width: 9,
    //            height: 9,
    //            border: 0,
    //            offset: 0
    //        }
    //    },
    //    events: {
    //        render: null,
    //        move: null,
    //        show: null,
    //        hide: null,
    //        toggle: null,
    //        focus: null,
    //        blur: null
    //    }
    //};
}
