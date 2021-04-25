using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Bogus;
using FreshMvvm;
using FwFreshMVVM.Models;

namespace FwFreshMVVM.ViewModels
{
    public class MainViewModel: FreshBasePageModel
    {
        //propiedad de modelo
        public ObservableCollection<Contact> Contacts { get; set; } =
            new ObservableCollection<Contact>();

       

        public async override void Init(object initData)
        {
            Contacts = await GetData();
        }


        public async Task<ObservableCollection<Contact>> GetData()
        {

            await Task.Delay(50);
            UserDialogs.Instance.ShowLoading("Cargando Informacion");
            await Task.Delay(5000);

            //creamos datos
            //llenamos con el paquete nugets se llama bogus
            var contacts = new Faker<Contact>()
                .RuleFor(x => x.Name, y => y.Name.FullName())
                .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
                .Generate(25);

            foreach (var item in contacts)
            {
                item.Photo = "profile.png";
            }

            UserDialogs.Instance.HideLoading();
            return new ObservableCollection<Contact>(contacts);

            //Contacts = new ObservableCollection<Contact>(contacts);
            //fin de crear datos con bogus



        }

    }
}
