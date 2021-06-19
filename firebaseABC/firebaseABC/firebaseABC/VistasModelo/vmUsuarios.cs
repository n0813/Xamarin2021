using firebaseABC.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using firebaseABC.Servicios;
using Firebase.Database.Query;
using Firebase.Storage;
using System.IO;
using System.Linq;

namespace firebaseABC.VistasModelo
{
    public class vmUsuarios
    {
        #region Variables
        List<mUsuarios> MUsuarios = new List<mUsuarios>();
        string stRutaFoto;
        string stIdUsuario;
        #endregion


        //mostrar usuarios
        public async Task<List<mUsuarios>> MostrarUsuarios()
        {
            var data = await ConexionFirebase.firebase
                .Child("Usuarios")
                .OrderByKey()
                .OnceAsync<mUsuarios>();

            foreach (var item in data)
            {
                var param = new mUsuarios();
                param.Id_usuario = item.Key;
                param.Usuario = item.Object.Usuario;
                param.Pass = item.Object.Pass;
                param.Icono = item.Object.Icono;
                param.Estado = item.Object.Estado;

                MUsuarios.Add(param);

            }

            return MUsuarios;
        }

        //agregar
        public async Task<string> AgregarUsuarios(mUsuarios oParam)
        {
            var data = await ConexionFirebase.firebase
                .Child("Usuarios")
                .PostAsync(new mUsuarios()
                {
                    Usuario = oParam.Usuario,
                    Pass = oParam.Pass,
                    Estado = oParam.Estado,
                    Icono = oParam.Icono

                });

            return data.Key;
            
        }

        public async Task<string> SubirImagenes(Stream strImagen,string stIdUsuario)
        {
            var dataImg = await new FirebaseStorage("usuarios-1e5c1.appspot.com")
                .Child("Usuarios")
                .Child(stIdUsuario + "jpg")
                .PutAsync(strImagen );

            stRutaFoto = dataImg;
            return stRutaFoto;

        }

        public async Task EditarFoto(mUsuarios oParam)
        {
            var obtenerData = (await ConexionFirebase.firebase
                .Child("Usuarios")
                .OnceAsync<mUsuarios>()).Where(x => x.Key == oParam.Id_usuario).FirstOrDefault();

            await ConexionFirebase.firebase
                .Child("Usuarios")
                .Child(obtenerData.Key)
                .PutAsync(new mUsuarios()
                {
                    Usuario = oParam.Usuario,
                    Pass = oParam.Pass,
                    Estado = oParam.Estado,
                    Icono = oParam.Icono
                });


        }

        public async Task EliminarUsuarios(mUsuarios oParam)
        {
            var data = (await ConexionFirebase.firebase
                .Child("Usuarios")
                .OnceAsync<mUsuarios>()).Where(x => x.Key == oParam.Id_usuario).FirstOrDefault();

            //eliminamos los datos
            await ConexionFirebase.firebase
                .Child("Usuarios")
                .Child(data.Key)
                .DeleteAsync();

        }

        public async Task EliminarImagen(string stImagen)
        {
            //eliminamos la imagen
            await new FirebaseStorage("usuarios-1e5c1.appspot.com")
                .Child("Usuarios")
                .Child(stImagen)
                .DeleteAsync();

        }

        public async Task<List<mUsuarios>> ObtenerDatosUsuarios(mUsuarios oParam)
        {
            var data = (await ConexionFirebase.firebase
                 .Child("Usuarios")
                 .OrderByKey()
                 .OnceAsync<mUsuarios>()).Where(x => x.Key == oParam.Id_usuario);

            foreach (var item in data)
            {
                oParam.Usuario = item.Object.Usuario;
                oParam.Pass = item.Object.Pass;
                oParam.Icono = item.Object.Icono;
                oParam.Estado = item.Object.Estado;

                MUsuarios.Add(oParam);

            }

            return MUsuarios;

        }


    }
}
