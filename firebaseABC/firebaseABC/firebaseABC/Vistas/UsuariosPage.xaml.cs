using firebaseABC.Modelo;
using firebaseABC.VistasModelo;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firebaseABC.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosPage : ContentPage
    {
        public UsuariosPage()
        {
            InitializeComponent();
            MostrarDatos();
        }

        #region Variables
        MediaFile mFile;
        string stRutaFoto;
        string stIdUsuario;

        #endregion

        #region Metodos

        private async Task InsertarUsuarios()
        {
            try
            {
                vmUsuarios funcion = new vmUsuarios();
                mUsuarios param = new mUsuarios();

                param.Usuario = txtUsuario.Text;
                param.Pass = txtContraseña.Text;
                param.Icono = "-";
                param.Estado = "-";

                stIdUsuario =  await funcion.AgregarUsuarios(param);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", "Error al agregar " + ex.Message, "Aceptar");
            }

        }

        private async Task MostrarDatos()
        {
            vmUsuarios funcion = new vmUsuarios();
            var dt = await funcion.MostrarUsuarios();
            collectionDatos.ItemsSource = dt;

        }

        private async Task SubirImagenStorage()
        {
            vmUsuarios funcion = new vmUsuarios();
            stRutaFoto = await funcion.SubirImagenes(mFile.GetStream(), stIdUsuario);

        }

        private async Task EditarFoto()
        {
            vmUsuarios funcion = new vmUsuarios();
            mUsuarios param = new mUsuarios();

            param.Icono = stRutaFoto;
            param.Id_usuario = stIdUsuario;
            param.Usuario = txtUsuario.Text;
            param.Pass = txtContraseña.Text;
            param.Estado = "Activo";
            await funcion.EditarFoto(param);
            await DisplayAlert("Aviso", "Usuario Agregado", "Aceptar"); 
            
            await MostrarDatos();
            
        }

        private async Task ObtenerDatosUsuario()
        {
            vmUsuarios funcion = new vmUsuarios();
            mUsuarios param = new mUsuarios();

            param.Id_usuario = stIdUsuario;

            var dt = await funcion.ObtenerDatosUsuarios(param);

            foreach (var item in dt)
            {
                txtUsuario.Text = item.Usuario;
                txtContraseña.Text = item.Pass;
                imgCelular.Source = item.Icono;

            }

        }

        private async Task EliminarUsuario()
        {
            vmUsuarios funcion = new vmUsuarios();
            mUsuarios param = new mUsuarios();
            param.Id_usuario = stIdUsuario;
            await funcion.EliminarUsuarios(param);

        }

        private async Task EliminarImagenUsuario()
        {
            vmUsuarios funcion = new vmUsuarios();
            await funcion.EliminarImagen(stIdUsuario + ".jpg");

        }

        #endregion

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            //insertamos y sacamos id
            await InsertarUsuarios();
            //guardamos imagen con id
            await SubirImagenStorage();
            //actualizamos el id que se inserto
            await EditarFoto();

        }

        private async void btnAgregarImg_Clicked(object sender, EventArgs e)
        {
            //guarrdamos la ruta de imagen en una variable y en un image
            await CrossMedia.Current.Initialize();
            try
            {
                mFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium

                });

                if (mFile == null)
                { return; }

                imgCelular.Source = ImageSource.FromStream(() =>
                {
                    var imgStream = mFile.GetStream();
                    return imgStream;

                });

            }
            catch (Exception ex)
            {

                await DisplayAlert("Aviso", "Error al cargar imagen " + ex.Message, "Aceptar");
            }

        }

        async void btnIcono_Clicked(System.Object sender, System.EventArgs e)
        {
            stIdUsuario = (sender as ImageButton).CommandParameter.ToString();
            await ObtenerDatosUsuario();

        }

        async void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
        {
            await EliminarUsuario();
            await EliminarImagenUsuario();
            await MostrarDatos();
            await DisplayAlert("Aviso", "Se elimino correctamente.", "Aceptar");
        }



    }
}