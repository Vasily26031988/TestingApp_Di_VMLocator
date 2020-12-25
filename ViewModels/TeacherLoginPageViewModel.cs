using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestingApp_Di_VMLocator.Pages.Admin;
using TestingApp_Di_VMLocator.Services;

namespace TestingApp_Di_VMLocator.ViewModels
{
    public class TeacherLoginPageViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public string Password { get; set; }

        public TeacherLoginPageViewModel(PageService navigation)
        {
            _navigation = navigation;
        }

       

        public ICommand Login => new DelegateCommand(() => 
        {
            if (Password =="admin")
            {
                _navigation.Navigate(new AdminPage());
            }

            else
            {
                MessageBox.Show("Неверный пароль");
            }
        
        
        }, ()=> !string.IsNullOrWhiteSpace(Password));
    }
}
