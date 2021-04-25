using System;
using FreshMvvm;
using FwFreshMVVM.Models;

namespace FwFreshMVVM.ViewModels
{
    public class ContactDetalleViewModel : FreshBasePageModel
    {
        //bindig context ejemplo Profile.Nombre
        public Contact Profile { get; set; }


        public override void Init(object initData)
        {
            if (initData is Contact)
            {
                Profile = initData as Contact;

            }


        }


    }
}
