using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TestingApp_Di_VMLocator;
using TestingApp_Di_VMLocator.Pages;
using TestingApp_Di_VMLocator.Services;




namespace TestingApp_Di_VMLocator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public Page CurrentPage { get; set; }

        public MainViewModel(PageService navigation)
        {
            navigation.OnPageChanged += page => CurrentPage = page;
            navigation.Navigate(new SelectRollPage());
            _navigation = navigation;
        }

        public ICommand GoToBack => new DelegateCommand(() => 
        { 
            _navigation.GoToBack(); 
        }, ()=> _navigation.CanGoToBack); 
    }
}
