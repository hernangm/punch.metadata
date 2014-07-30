using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Punch.Base.Tests;
using Punch.Bindings;
using Punch.Core;
using Punch.Helpers;
using Punch.Validation;
using Punch.Validation.FluentValidation;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
using Eqip.Metadata.Ninject;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc.FluentValidation;
using NUnit.Framework;
using fv = FluentValidation;


namespace Punch.Metadata.Helpers.Tests
{
    public class NinjectResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }

    class BindingWithMetadataTests : BaseTest
    {
        protected NinjectResolver Resolver { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Resolver = new NinjectResolver();

            // Validators
            this.Resolver.Kernel.Bind<fv.IValidatorFactory>().ToConstant(new NinjectValidatorFactory(this.Resolver.Kernel));
            this.Resolver.Kernel.Bind<IValidatorInspector>().To<ValidatorInspector>();
            fv.AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly()).ForEach(
                match => this.Resolver.Kernel.Bind(match.InterfaceType).To(match.ValidatorType)
            );


            //Metadata
            this.Resolver.Kernel.Bind<IMetadataFactory>().ToConstant(new NinjectMetadataFactory(this.Resolver.Kernel));
            Eqip.Metadata.Ninject.AssemblyScanner.FindConfiguratorsInAssembly(Assembly.GetExecutingAssembly()).ForEach(
                match => this.Resolver.Kernel.Bind(match.InterfaceType).To(match.ConfiguratorType)
            );
            DependencyResolver.SetResolver(this.Resolver);
            KnockoutMetadataProvider.RegisterMetadataProvider(new Provider(base.HttpContext.Object.Cache, this.Resolver.Kernel.Get<IMetadataFactory>()));
        }



        [Test]
        public void binding_with_format()
        {
            var htmlContext = CreateHtmlContext<FormatViewModel>();
            var binding = new KnockoutTextBinding<FormatViewModel>(m => m.Id);
            Assert.AreEqual(@"text : Id.format", binding.GetKnockoutExpression(htmlContext.Context.CreateData()));
        }



        //[Test]
        //public void radio_buttons_list_check()
        //{
        //    var helper = base.CreateKnockoutContext<ListMetadataViewModel>();
        //    var html = helper.Html.RadioButtonsFor(m => m.Film).ToHtmlString();
        //    Assert.IsTrue(html.Contains(@"data-bind=""foreach : Film.options"""));
        //}



        //[Test]
        //public void radio_buttons_list_check()
        //{
        //    var factory = this.Resolver.GetService<IViewModelMetadataFactory>();
        //    var metadata = factory.GetViewModelConfigurator<PeliculaWithValidation>().CreateDescriptor();
        //    var conf = metadata.Properties.FirstOrDefault(m => m.Key == "Nombre");
        //    Assert.IsNotNull(conf);
        //    Assert.True(conf.Value.Any(m => m.GetType() == typeof(ValidatorsConfig)));
        //    Assert.True(((ValidatorsConfig)conf.Value.First(m => m.GetType() == typeof(ValidatorsConfig))).Validators.Count > 0);
        //}
    }
}
