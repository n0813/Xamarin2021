using System;
using System.Collections.ObjectModel;
using Bogus;
using FramewFreshMV.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace FramewFreshMV.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        //propiedad de modelo
        public ObservableCollection<Contact> Contacts { get; set; } =
            new ObservableCollection<Contact>();

        public MainViewModel()
        {
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

            Contacts = new ObservableCollection<Contact>(contacts);
            //fin de crear datos con bogus

            
        }
    }
}

