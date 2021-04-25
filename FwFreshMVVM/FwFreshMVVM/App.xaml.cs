using System;
using FreshMvvm;
using FwFreshMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FwFreshMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = FreshPageModelResolver.ResolvePageModel<MainViewModel>();

            /* Para empezar el freshMVVM
               Descargar primero el noguts FreshMVVM, si se desea bajar bogus
               bogus es para simular el llenado de datos
               tambien las carpetas Models, View = Pages ahora se pone asi por el FreshMVVM
               en el ViewModels ya no se usara el MainPageViewModel ahora es = MainViewModel
               Tambien instalar el nuget para evitar poner el onChangePropertyChange nuget = " PropertyChanged.Fody - Version 2.5.13 "
               y se agrega un xml llamado FodyWeavers.xml

            */
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
