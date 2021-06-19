using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace firebaseABC.Servicios
{
    public class ConexionFirebase
    {

        //conexion con firebase
        public static FirebaseClient firebase = new FirebaseClient("https://usuarios-1e5c1-default-rtdb.firebaseio.com/");

    }
}
