using System.Web.Mvc;
using CadetCorps.Core.Init.DependencyResolution;
using CadetCorps.Core;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(CadetCorps.App_Start.StructuremapMvc), "Start")]

namespace CadetCorps.App_Start {
    public static class StructuremapMvc {
        public static void Start() {
            var container = (IContainer) IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}