using System;
using System.Windows.Input;
using FreshMvvm;
using MasterDetailFreshMvvm.Servicios;
using Xamarin.Forms;

namespace MasterDetailFreshMvvm.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        INavigationServices _navService;

        public ICommand LoginCmd { get; set; }

        public LoginViewModel(INavigationServices navigationService)
        {
            _navService = navigationService;
        }

        public override void Init(object initData)
        {
            LoginCmd = new Command(async () =>
            {
                //await CoreMethods.PushPageModel<ContactsViewModel>();

                _navService.SwitchNavigation(Enums.NavigacionStacks.Inicio, this);

            }); 
        }

    }
}
