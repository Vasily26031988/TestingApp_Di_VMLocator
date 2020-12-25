using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TestingApp_Di_VMLocator.Pages;
using TestingApp_Di_VMLocator.Services;
using TestingApp_Di_VMLocator.ViewModels;

namespace TestingApp_Di_VMLocator
{
    public class SelectRolePageViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public SelectRolePageViewModel(PageService navigation)
        {
            _navigation = navigation;
        }

        public ICommand LoginTeacher => new DelegateCommand(() =>
        {
            _navigation.Navigate(new TeacherLoginPage());
        });

        public ICommand LoginStudent => new DelegateCommand(() =>
        {
            //_navigation.Navigate  - кидаем на страницу для студента
        });


    }
}
