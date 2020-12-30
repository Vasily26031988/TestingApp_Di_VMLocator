using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestingApp_Di_VMLocator.ViewModels;


namespace TestingApp_Di_VMLocator.Services
{
    public class PageService
    {

        private Stack<Type> _history; //вместо типа Page мы здесь объявили тип Type, так как когда будем навигатиться назад, 
                                      //то получим тот же стейт, что и был. Но мы регали сервис как Trensiant и нам нужен новый более актуальный стейт. Cоответственно page мы будем "пушить" с 
        
        public event Action<Page> OnPageChanged;
        public bool CanGoToBack => _history.Skip(1).Any();
        public PageService()
        {
            _history = new Stack<Type>();
        }

        public void Navigate(Page page)
        {
            OnPageChanged?.Invoke(page);
             _history.Push(page.GetType());
            
        }

        internal void GoToBack()
        {
            _history.Pop();
            var page = _history.Peek();
            OnPageChanged?.Invoke((Page)Activator.CreateInstance(page)); //здесь будем создавать экземпляры пользуясь тем, что у нас будут создаваться пэйджи с пустым конструктором 
                                                                         //- таким образом будем старые экземпляры забывать, а новые создавать и получать VM либо новую, либо старую, в зависимости от того как она будет зарегана.  
                                                                         //  По причине того, что когда мы возвращаемся на страничку назад - мы восстанавливаем свое состояние полностью из памяти.
        }
    }
}
