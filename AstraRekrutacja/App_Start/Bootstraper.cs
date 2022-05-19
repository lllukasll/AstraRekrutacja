using AstraRekrutacja.Data.Repositories;
using AstraRekrutacja.Data.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace AstraRekrutacja.App_Start
{
    public static class Bootstraper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IWorkerLeavesRepository, WorkerLeavesRepository>(new TransientLifetimeManager());
        }
    }
}