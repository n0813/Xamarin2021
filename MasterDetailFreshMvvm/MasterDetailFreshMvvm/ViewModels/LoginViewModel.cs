using System;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace MasterDetailFreshMvvm.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {

        public ICommand LoginCmd { get; set; }

        /*public LoginViewModel()
        {
             
        }*/

        public override void Init(object initData)
        {
            LoginCmd = new Command(async () =>
            {
                await CoreMethods.PushPageModel<ContactsViewModel>();

            }); 
        }

    }
}
