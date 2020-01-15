using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AssemblyLoad
{
    class Program
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            var codeBase = Assembly.GetExecutingAssembly().Location;
            var path = new FileInfo(codeBase).Directory;
            AssemblyLoadContext.Default.LoadFromAssemblyPath($"{path}\\RepoDb\\RepoDb.dll");
            AssemblyLoadContext.Default.LoadFromAssemblyPath($"{path}\\RepoDb\\System.Data.SQLite.dll");
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath($"{path}\\RepoDb\\RepoDb.SqLite.dll"); // Assembly.LoadFile($"{path}\\RepoDb\\RepoDb.SqLite.dll");
            var assemblies = assembly.GetReferencedAssemblies();
            //var result = GetFields(assembly, typeof(Person));
            InitializeBootstrapper(assembly);
            Console.WriteLine("Hello World!");
        }

        static void InitializeBootstrapper(Assembly assembly)
        {
            var bootstrapType = assembly.GetType("RepoDb.SqLiteBootstrap");
            var initializeMethod = bootstrapType.GetMethod("Initialize");
            initializeMethod.Invoke(null, null);
        }

        static object GetFields(Assembly assembly,
            Type type)
        {
            var fieldCacheType = assembly.GetType("RepoDb.FieldCache");
            var getMethod = fieldCacheType.GetMethod("Get", new[] { typeof(Type) });
            return getMethod.Invoke(null, new[] { typeof(Person) });
        }
    }
}
