using Autofac;
using VHJobsApp.Models;
using VHJobsApp.Services;
using VHJobsApp.ViewModels;

namespace VHJobsApp
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            RegisterDepedencies(containerBuilder);

            return containerBuilder.Build();
        }
        protected virtual void RegisterDepedencies(ContainerBuilder cb)
        {            
            cb.RegisterType<JobService>().As<IJobService>().SingleInstance();

            cb.RegisterType<JobListViewModel>().As<IJobListViewModel>().SingleInstance();
            cb.RegisterType<JobDetailViewModel>().As<IJobDetailViewModel>().SingleInstance();
            cb.RegisterType<JobSearchViewModel>().As<IJobSearchViewModel>().SingleInstance();
            cb.RegisterType<FilterViewModel>().As<IFilterViewModel>().SingleInstance();

        }
    }
}
