using System;
using FreshMvvm;
using MasterDetailFreshMvvm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailFreshMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //login
            var inicio = FreshPageModelResolver
                .ResolvePageModel<LoginViewModel>();

            MainPage = new FreshNavigationContainer(inicio); 


            //master detail
            //var masterDetail = new FreshMasterDetailNavigationContainer();

            /*masterDetail.AddPage<ContactsViewModel>("Contacts");
            masterDetail.AddPage<AboutViewModel>("About");
            masterDetail.Init("Menu");

            MainPage = masterDetail;*/

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
