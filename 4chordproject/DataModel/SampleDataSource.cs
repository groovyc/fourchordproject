using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Syndication;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace _4chordproject.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem
    {
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content
            , string artist, string chords, string year
                )
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Content = content;
            this.Artist = artist;
            this.Chords = chords;
            this.Year = year;
        }

        
        public string UniqueId { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }

        public String Artist { get; private set; }

        public String Chords { get; private set; }

        public String Year { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup
    {
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description
 , string artist// string chords, string year
            )
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Artist = artist;
            //this.Chords = chords;
            //this.Year = year;
            this.Items = new ObservableCollection<SampleDataItem>();

        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }

        public String Artist { get; private set; }

        //public String Chords { get; set; }

        //public String Year { get; set; }
        public ObservableCollection<SampleDataItem> Items { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource(); ///allows only one instance of sampledatasource to be created. 

        //private field group and private property groups  
            private ObservableCollection<SampleDataGroup> _groups = new ObservableCollection<SampleDataGroup>();
        public ObservableCollection<SampleDataGroup> Groups
        {
            get { return this._groups; }             //allows you to return the current instance of groups 
        }

        public static async Task<IEnumerable<SampleDataGroup>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();

            return _sampleDataSource.Groups;
        }

        public static async Task<SampleDataGroup> GetGroupAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<SampleDataItem> GetItemAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        //private async Task GetSampleDataAsync()
        //{
        //    if (this._groups.Count != 0)
        //        return;

        //    await GetFeedsAsync();

        //}






        //    public async Task GetFeedsAsync()
        //    {
        //        Task<SampleDataGroup> feed1 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/developers/atom.aspx");
        //        Task<SampleDataGroup> feed2 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/windowsexperience/atom.aspx");
        //        Task<SampleDataGroup> feed3 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/extremewindows/atom.aspx");
        //        Task<SampleDataGroup> feed4 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/business/atom.aspx");
        //        Task<SampleDataGroup> feed5 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/bloggingwindows/atom.aspx");
        //        Task<SampleDataGroup> feed6 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/windowssecurity/atom.aspx");
        //        Task<SampleDataGroup> feed7 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/springboard/atom.aspx");
        //        Task<SampleDataGroup> feed8 =
        //            GetFeedAsync("http://windowsteamblog.com/windows/b/windowshomeserver/atom.aspx");
        //        // There is no Atom feed for this blog, so we use the RSS feed.
        //        Task<SampleDataGroup> feed9 =
        //            GetFeedAsync("http://windowsteamblog.com/windows_live/b/windowslive/rss.aspx");
        //        Task<SampleDataGroup> feed10 =
        //            GetFeedAsync("http://windowsteamblog.com/windows_live/b/developer/atom.aspx");
        //        Task<SampleDataGroup> feed11 =
        //            GetFeedAsync("http://windowsteamblog.com/ie/b/ie/atom.aspx");
        //        Task<SampleDataGroup> feed12 =
        //            GetFeedAsync("http://windowsteamblog.com/windows_phone/b/wpdev/atom.aspx");
        //        Task<SampleDataGroup> feed13 =
        //            GetFeedAsync("http://windowsteamblog.com/windows_phone/b/wmdev/atom.aspx");

        //        this._groups.Add(await feed1);
        //        this._groups.Add(await feed2);
        //        this._groups.Add(await feed3);
        //        this._groups.Add(await feed4);
        //        this._groups.Add(await feed5);
        //        this._groups.Add(await feed6);
        //        this._groups.Add(await feed7);
        //        this._groups.Add(await feed8);
        //        this._groups.Add(await feed9);
        //        this._groups.Add(await feed10);
        //        this._groups.Add(await feed11);
        //        this._groups.Add(await feed12);
        //        this._groups.Add(await feed13);
        //    }


        //    private async Task<SampleDataGroup> GetFeedAsync(string feedUriString)
        //    {
        //        // using Windows.Web.Syndication;
        //        SyndicationClient client = new SyndicationClient();
        //        Uri feedUri = new Uri(feedUriString);

        //        try
        //        {
        //            SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);

        //            string description = "tbd";
        //            // Use the date of the latest post as the last updated date.
        //            string date = feed.Items[0].PublishedDate.DateTime.ToString();


        //            if (feed.Subtitle != null && feed.Subtitle.Text != null)
        //            {
        //                description = feed.Subtitle.Text;
        //            }

        //            // This code is executed after RetrieveFeedAsync returns the SyndicationFeed.
        //            // Process it and copy the data we want into our FeedData and FeedItem classes.
        //            SampleDataGroup feedData = new SampleDataGroup(feed.Id, feed.Title.Text,
        //                feed.Subtitle.Text, null, description, date);

        //            foreach (SyndicationItem item in feed.Items)
        //            {
        //                string content = "tbd";
        //                string uriLink = "tbd";
        //                string author = item.Authors[0].Name.ToString();
        //                string datePub = item.PublishedDate.DateTime.ToString();

        //                // Handle the differences between RSS and Atom feeds.
        //                if (feed.SourceFormat == SyndicationFormat.Atom10)
        //                {
        //                    content = item.Content.Text;
        //                    uriLink = new Uri("http://windowsteamblog.com" + item.Id).ToString();
        //                }
        //                else if (feed.SourceFormat == SyndicationFormat.Rss20)
        //                {
        //                    content = item.Summary.Text;
        //                    uriLink = item.Links[0].Uri.ToString();
        //                }

        //                SampleDataItem feedItem = new SampleDataItem(item.Id, item.Title.Text, "tbd",
        //                    null, null, content, datePub, author, uriLink);

        //                feedData.Items.Add(feedItem);
        //            }

        //            return feedData;
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    }

        //}



        private async Task GetSampleDataAsync()
        {
            if (this._groups.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/SampleData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText); ///we're telling comp that we have jason data and turning it into a readable format
            JsonArray jsonArray = jsonObject["Groups"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
                                                            groupObject["Title"].GetString(),
                                                            groupObject["Subtitle"].GetString(),
                                                            groupObject["ImagePath"].GetString(),
                                                            groupObject["Description"].GetString(),
                    //groupObject["Content"].GetString(),
                                                            groupObject["Artist"].GetString()
                    //groupObject["Chords"].GetString(),
                    //groupObject["Year"].GetString()
                                                            );

                foreach (JsonValue itemValue in groupObject["Items"].GetArray())
                {
                    JsonObject itemObject = itemValue.GetObject();
                    group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
                                                       itemObject["Title"].GetString(),
                                                       itemObject["Subtitle"].GetString(),
                                                       itemObject["ImagePath"].GetString(),
                                                       itemObject["Description"].GetString(),
                                                       itemObject["Content"].GetString(),
                                                       itemObject["Artist"].GetString(),
                                                       itemObject["Chords"].GetString(),
                                                       itemObject["Year"].GetString()
                                                       ));
                }
                this.Groups.Add(group);
            }
        }
    }
}