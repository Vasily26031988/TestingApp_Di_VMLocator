using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingApp_Di_VMLocator.Models;
using TestingApp_Di_VMLocator.Pages.Admin;
using TestingApp_Di_VMLocator.Services;

namespace TestingApp_Di_VMLocator.ViewModels.Admin
{
    public class AdminPageViewModel : BindableBase
    {
       
        private readonly PageService _navigation;
		private readonly Repository _repository;
		private readonly EventBus _eventBus;

		public ObservableCollection<Test> Tests { get; set; } = new ObservableCollection<Test>();

		public AdminPageViewModel(PageService navigation, Repository repository, EventBus eventBus)
		{
            
            _navigation = navigation;
			_repository = repository;
			_eventBus = eventBus;
            
            Tests = new ObservableCollection<Test>();
            //repository.FindAll<Test>().ContinueWith((s) => 
            //{
            //    Tests = new ObservableCollection<Test>(s.Result);
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            _eventBus.Subscribe<OnSave<Test>>(OnSaveTest);
            _eventBus.Subscribe<OnDelete<Test>>(OnDeleteTest);


            Tests.Add(new Test
            {
                QuestionCount = 3,
                Title = "Тест"
            });
        }

		private Task OnDeleteTest(OnDelete<Test> arg)
		{
            var item = Tests.FirstOrDefault(s => s.Id == arg.Id);
			if (item != null)
			{
                Tests.Remove(item);
			}
            return Task.CompletedTask;
        }

		private Task OnSaveTest(OnSave<Test> arg)
		{
            Tests.Add(arg.Entity);
            return Task.CompletedTask;
		}

		public ICommand AddTest => new DelegateCommand(() =>
        {
            _navigation.Navigate(new TestEditorPage());
        });

        public ICommand OpenTest => new DelegateCommand(() =>
        {

        });

        public ICommand RemoveTest => new AsyncCommand<Test>(async (test) =>    //Удаляем из теста данные в классе "Test", указывая в делегате тип <Test> и передавая делегату в параметр переменную "test"
        {
            await _repository.Remove<Test>(test.Id);
            //Tests.Remove(test);
        }, (test) => test != null);  //благодаря данной реализации нам все равно где и откуда вызвали метод Remove на Test.
    }
}
