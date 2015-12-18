using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using _4chordproject.Data;
using _4chordproject.DataModel;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace _4chordproject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubPage1 : Page
    {
        private const String URI = "http://fourchordprojectweb.cloudapp.net";

        public HubPage1()
        {
            this.InitializeComponent();
        }

        private async void btn2GetData_Click(object sender, RoutedEventArgs e)
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
                        imageInfo.ItemsSource = new ObservableCollection<Song>(listings);
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

        
    } //end of class


} 
