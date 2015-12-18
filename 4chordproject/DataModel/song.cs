using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace _4chordproject.DataModel
{
    //public class Song
    //{


    //    public Song(String title, String subtitle, String description, String imagePath,
    //         string artist, string chords, string year, string items
    //            )
    //    {
    //        this.Id = Id;
    //        this.Title = title;
    //        this.Subtitle = subtitle;
    //        this.ImagePath = imagePath;
    //        this.Description = description;

    //        this.Artist = artist;
    //        this.Chords = chords;
    //        this.Year = year;
    //        this.Items = items;

    //    }



    //    //

    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("title")]
    //    public String Title { get; set; }

    //    [JsonProperty("subtitle")]
    //    public String Subtitle { get; set; }
    //    [JsonProperty("imagepath")]
    //    public String ImagePath { get; set; }
    //    [JsonProperty("description")]
    //    public String Description { get; set; }
    //    [JsonProperty("artist")]
    //    public String Artist { get; set; }
    //    [JsonProperty("chords")]
    //    public String Chords { get; set; }
    //    [JsonProperty("year")]
    //    public String Year { get; set; }
    //    [JsonProperty("items")]
    //    public String Items { get; set; }


    //    //  ArrayList Songs = new ArrayList();

    //    //  List<Song> list = new List<Song>();
    //    [JsonProperty("list")]
    //    public List<Song> list { get; set; }
    //}

    //public class SongGroup
    //{
    //    // public List<Song> Songs { get; set; }

    //    //public ObservableCollection<Song> Songs { get; private set; }

    //    //public SongGroup()
    //    //{
    //    //    this.Songs = new ObservableCollection<Song>();
    //    //}


    //    //public ObservableCollection<Song> Song
    //    //{
    //    //    get { return this.Songs; }            //allows you to return the current instance of songs 
    //    //}

    //}


    public class Rootobject
    {
        [JsonProperty("property1")]
        public Song[] Property1 { get; set; }
    }

    public class Song
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty("imagepath")]
        public string ImagePath { get; set; }
        public object Description { get; set; }
        public string Artist { get; set; }
        public string Chords { get; set; }
        public string Year { get; set; }
        public string Items { get; set; }
        public object List { get; set; }
        //working one
    }
}
