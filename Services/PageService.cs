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

        private Stack<Type> _history;
      
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
            OnPageChanged?.Invoke((Page)Activator.CreateInstance(page));
        }
    }
}
