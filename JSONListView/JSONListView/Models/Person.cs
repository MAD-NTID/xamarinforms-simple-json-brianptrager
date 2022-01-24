using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JSONListView.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Person : INotifyPropertyChanged
    {
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                    //PersonData.UpdateData();
                }
            }
        }
        private string name;

        [JsonProperty("email")]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                    //PersonData.UpdateData();
                }
            }
        }
        private string email;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
