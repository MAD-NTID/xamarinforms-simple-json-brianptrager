using JSONListView.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;


namespace JSONListView
{
    class PersonData
    {
        public static List<Person> people;

        public static void LoadData()
        {
            people = new List<Person>();

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "testmodel.json");

            if (!File.Exists(fileName))
            {

                var assembly = typeof(PersonData).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("JSONListView.testmodel.json");

                string text = "";
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                    people = JsonConvert.DeserializeObject<List<Person>>(text);
                }
            }
            else
            {
                string text = "";
                using (var reader = new StreamReader(fileName))
                {
                    text = reader.ReadToEnd();
                    people = JsonConvert.DeserializeObject<List<Person>>(text);
                }
            }

        }

        public static void UpdateData()
        {
            //You cannot read from an embedded resource!!!
            //var assembly = typeof(PersonData).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("JSONListView.testmodel.json");

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "testmodel.json");
            using (var writer = new StreamWriter(fileName))
            {
                string peopleData = JsonConvert.SerializeObject(people);
                writer.Write(peopleData);
            }

        }
    }
}
