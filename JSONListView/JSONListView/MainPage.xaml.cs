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
            BindingContext = this;

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("JSONListView.testmodel.json");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
                List<Person> myObjects = JsonConvert.DeserializeObject<List<Person>>(text);
                people = new ObservableCollection<Person>(myObjects);
                MyListView.ItemsSource = people;
            }
        }
    }
}
