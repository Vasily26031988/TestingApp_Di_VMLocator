using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingApp_Di_VMLocator.Models;

namespace TestingApp_Di_VMLocator.ViewModels.Admin
{
    public class AdminPageViewModel : BindableBase
    {
        public ObservableCollection<Test> Tests { get; set; } = new ObservableCollection<Test>();

        public AdminPageViewModel()
        {
            Tests.Add(new Test
            {
                QuestionCount = 3,
                Title = "Тест"
            });


        }

        public ICommand AddTest => new DelegateCommand(() =>
        {

        });

        public ICommand OpenTest => new DelegateCommand(() =>
        {

        });

        public ICommand RemoveTest => new DelegateCommand<Test>((test) =>    //Удаляем из теста данные в классе "Test", указывая в делегате тип <Test> и передавая делегату в параметр переменную "test"
        {
            Tests.Remove(test);
        }, (test) => test != null);
    }
}
