﻿using FD.Videolocadora.Application.Interfaces;
using FD.Videolocadora.CrossCutting.IoC;
using Microsoft.Azure.ServiceBus;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FD.Videolocadora.ConsoleApp
{
    class Program
    {
        private const string _CONNECTION_STRING = "Endpoint=sb://spottermessagebusdev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=qhv+vddxzeoK0KFj7xMWovjvXKUEIzyjcRHYfQbNSus=";
        private const string _NAME_QUEUE = "treinamento_felix";
        static QueueClient _Queue;
        static Container _Container;
        static void Main(string[] args)
        {
            Initialize();
            using (AsyncScopedLifestyle.BeginScope(_Container))
            {


                var genero = _Container.GetInstance<IGeneroAppService>();
                _Queue = new QueueClient(_CONNECTION_STRING, _NAME_QUEUE);

                _Queue.RegisterMessageHandler((Microsoft.Azure.ServiceBus.Message M, CancellationToken C) =>
                {
                    string Body = Encoding.UTF8.GetString(M.Body);
                    Console.WriteLine(Body);

                    return Task.CompletedTask;

                }, new MessageHandlerOptions((E) =>
                {
                    Console.WriteLine(E.Exception.Message);
                    return Task.CompletedTask;
                })
                {
                    AutoComplete = true,
                });
                while (true)
                {
                    Thread.Sleep(1000);
                }
                
            }
            _Container.Dispose();
        }

        public static void Initialize()
        {
            _Container = new Container();
            _Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            InitializeContainer(_Container);

            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _Container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
             //   new SimpleInjectorWebApiDependencyResolver(container);

        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}
