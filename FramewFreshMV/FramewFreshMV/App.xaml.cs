using System;
using FramewFreshMV.Pages;
using FramewFreshMV.ViewModels;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FramewFreshMV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = FreshPageModelResolver.ResolvePageModel<MainViewModel>();

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
