using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using FileSystemImage.Configuration;
using Serilog;

namespace FileSystemImage.Library.AutofacModules
{
    public class LogDemo
    {
        readonly ILogger _log;

        public LogDemo(ILogger log)
        {
            _log = log;
        }

        public void Show()
        {
            _log.Information("This is also an event from 'SomeClass'");
        }
    }
}
