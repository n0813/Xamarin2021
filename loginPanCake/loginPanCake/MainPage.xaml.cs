using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace loginPanCake
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            await Task.Delay(1000);

            await panel1.FadeTo(1, 1000, Easing.SinInOut);

            await Task.WhenAll(

                lblTitulo.TranslateTo(0, 0, 1000, Easing.BounceOut),
                txtUser.TranslateTo(0, 0, 1000, Easing.BounceOut),
                txtPass.TranslateTo(0, 0, 1000, Easing.BounceOut),
                btnIngresar.FadeTo(1, 2000, Easing.SinInOut)

            );
        }

    }
}
