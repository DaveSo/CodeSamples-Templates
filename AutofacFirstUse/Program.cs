using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using SecondProject;

namespace AutofacFirstUse
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();

            /*builder.RegisterType<Teacher>().As<IPerson>();
            builder.RegisterType<Student>().As<IPerson>();*/

            var dataAccess = typeof(IPerson).Assembly; //ukazuje na assembly kde autofac bude hledat komponenty k registraci  

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IPerson))))
                .AsImplementedInterfaces();
            Container = builder.Build();

            var persons = Container.Resolve<IEnumerable<IPerson>>();


            foreach (var person in persons)
            {
                person.WriteClassName();
            }
        }
    }

}