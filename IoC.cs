using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp_Di_VMLocator.Services;
using TestingApp_Di_VMLocator.ViewModels;
using TestingApp_Di_VMLocator.ViewModels.Admin;

namespace TestingApp_Di_VMLocator
{
    public static class IoC
    {
        private static readonly ServiceProvider _provider;
        static IoC()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<SelectRolePageViewModel>();

            services.AddSingleton<TeacherLoginPageViewModel>();

            services.AddSingleton<AdminPageViewModel>();          
            
            services.AddTransient<TestEditorPageViewModel>(); //будет создавать каждый раз новые экземпляры класса, а не один как SingleTon

   
            services.AddSingleton<PageService>();
            services.AddSingleton(new LiteDatabase("Data/test-app.db"));
            services.AddTransient<Repository>();





            _provider = services.BuildServiceProvider();
        }
        public static T Resolve<T>() => _provider.GetRequiredService<T>(); 
    }
}
