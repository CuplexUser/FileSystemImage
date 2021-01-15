using Autofac;
using FileSystemImage.Library.AutofacModules;
using GeneralToolkitLib.ConfigHelper;
using System.Reflection;

namespace FileSystemImage.Configuration
{
    public static class AutofacConfig
    {
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <returns></returns>
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = GetMainAssembly();


            Assembly[] coreAssemblies = new Assembly[2];
            var generalToolKitAssembly = AssemblyHelper.GetAssembly();

            coreAssemblies[0] = thisAssembly;
            coreAssemblies[1] = generalToolKitAssembly;

            //if (generalToolKitAssembly != null)
            //{
            //    builder.RegisterAssemblyModules(generalToolKitAssembly);
            //}

            builder.RegisterAssemblyModules(coreAssemblies);
            var container = builder.Build();


            return container;
        }



        /// <summary>
        /// Gets the main assembly.
        /// </summary>
        /// <returns></returns>
        public static Assembly GetMainAssembly()
        {
            return typeof(FileSystemImageModule).Assembly;
        }

    }
}
