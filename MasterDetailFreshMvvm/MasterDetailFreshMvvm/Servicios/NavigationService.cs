using System;
using FreshMvvm;
using MasterDetailFreshMvvm.Enums;
using MasterDetailFreshMvvm.ViewModels;

namespace MasterDetailFreshMvvm.Servicios
{
    public class NavigationService : INavigationServices
    {
        public void SwitchNavigation(NavigacionStacks navigationPila, FreshBasePageModel page)
        {
            switch (navigationPila)
            {
                case NavigacionStacks.Autentificacion:

                    var login = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
                    var NavLogin = new FreshNavigationContainer(login,navigationPila.ToString());

                    page.CoreMethods.SwitchOutRootNavigation(navigationPila.ToString());

                    break;

                case NavigacionStacks.Inicio:
                    var VInicio = FreshPageModelResolver.ResolvePageModel<ContactsViewModel>();
                    var NavInicio = new FreshNavigationContainer(VInicio, navigationPila.ToString());

                    page.CoreMethods.SwitchOutRootNavigation(navigationPila.ToString());

                    break;

                case NavigacionStacks.MasterD:
                    break;

            }
        }
    }
}
