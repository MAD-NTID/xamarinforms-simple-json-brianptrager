using JSONListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace JSONListView
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Person> people;
        public MainPage()
        {
            InitializeComponent();
            PersonData.LoadData();
            BindingContext = this;
            people = new ObservableCollection<Person>(PersonData.people);
            MyListView.ItemsSource = people;

        }

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Person person = (Person)e.Item;
            await Navigation.PushAsync(new DetailsPage(person));
        }
    }
}
