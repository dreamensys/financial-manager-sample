﻿using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Unity;
using Unity.Lifetime;
using WebApp.Services;

namespace CrossCutting
{
    public static class IoCFactory
    {
        static  IUnityContainer container;

        static IoCFactory()
        {
            InitContainers();
        }
   
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static void InitContainers()
        {
            container = new UnityContainer();

            //Repositories
            container.RegisterType<ITransactionRepository, TransactionRepository>(new TransientLifetimeManager());

            //Services
            container.RegisterType<ITransactionService, TransactionService>(new TransientLifetimeManager());

            //DB
            container.RegisterType<ManagerDBContext>();

        }

        
    }
}
