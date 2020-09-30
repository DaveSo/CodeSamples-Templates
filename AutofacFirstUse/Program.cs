using System;
using System.Collections.Generic;
using Autofac;

namespace AutofacFirstUse
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<Teacher>().As<IPerson>();
            builder.RegisterType<Student>().As<IPerson>();
            Container = builder.Build();

            var persons = Container.Resolve<IEnumerable<IPerson>>();


            foreach (var person in persons)
            {
                person.WriteClassName();
            }
        }
    }

    public interface IOutput
    {
        void Write(string content);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }


    public interface IPerson
    {
        void WriteClassName();
    }


    public class Teacher : IPerson
    {
        private IOutput _output;
        public Teacher(IOutput output)
        {
            _output = output;
        }

        public void WriteClassName()
        {
            _output.Write(GetType().Name);
        }
    }
    public class Student : IPerson
    {
        /*private IOutput _output;
        public Student(IOutput output)
        {
            _output = output;
        }*/

        public void WriteClassName()
        {
            Console.WriteLine(GetType().Name);
        }
    }
}