using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp_Di_VMLocator.ViewModels;
using TestingApp_Di_VMLocator.ViewModels.Admin;

namespace TestingApp_Di_VMLocator
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => IoC.Resolve<MainViewModel>();

        public  SelectRolePageViewModel SelectRolePageViewModel => IoC.Resolve<SelectRolePageViewModel>();

        public TeacherLoginPageViewModel TeacherLoginPageViewModel => IoC.Resolve<TeacherLoginPageViewModel>();

        public AdminPageViewModel AdminPageViewModel => IoC.Resolve<AdminPageViewModel>();

        public TestEditorPageViewModel TestEditorPageViewModel => IoC.Resolve<TestEditorPageViewModel>();

    }
}
