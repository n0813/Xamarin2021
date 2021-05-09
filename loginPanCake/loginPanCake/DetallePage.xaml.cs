using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace loginPanCake
{
    public partial class DetallePage : ContentPage
    {
        public DetallePage()
        {
            InitializeComponent();

            //pin.Clicked += (sender, ea) =>

            btnRegresar.Clicked += (sender, ea) =>
            {
                var dat = Navigation.NavigationStack;
                Navigation.PopAsync();

            };


            btnInicio.Clicked += (sender, ea) =>
            {

                Application.Current.MainPage = new NavigationPage(new MainPage());

            };

        }

        
    }
}
