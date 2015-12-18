using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _4chordproject.Resources;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace _4chordproject
{
    public partial class MainPage : PhoneApplicationPage
    {

        private const String URI = "http://fourchordprojectweb.cloudapp.net";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // base URI for API Controller
                    client.BaseAddress = new Uri(URI);

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../api/items
                    // get all items asynchronously 
                    HttpResponseMessage response = await client.GetAsync("api/songs");

                    // continue
                    if (response.IsSuccessStatusCode)
                    {
                        // read result
                        var listings = await response.Content.ReadAsAsync<IEnumerable<Song>>();

                        // display the items on a long list selector
                        songInfo.ItemsSource = new ObservableCollection<Song>(listings);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        
    }
}