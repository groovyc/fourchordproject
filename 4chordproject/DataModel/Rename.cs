

   


//using System;
//using System.Collections.Generic;
//using System.Text;
//    using System.Threading.Tasks;
//    using System.Linq;
//using Newtonsoft.Json;
//using Microsoft.WindowsAzure.Storage.Table;
//using Microsoft.WindowsAzure.MobileServices;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Mobile;
//using Microsoft.WindowsAzure.Mobile.Service;
//using Microsoft.WindowsAzure.Storage;

//using Microsoft.Live;
//using Microsoft.WindowsAzure.MobileServices;
//using System;
//using System.Runtime.Serialization;
//using Windows.UI.Popups;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Navigation;
//namespace _4chordproject.DataModel
//{
//    public class TodoItem :StorageData
//    {
//        CloudStorageAccount storageAccount;
//        StorageCredentials creds;
//        CloudTableClient tableClient;

//        IMobileServiceTable<TodoItem> todoTable =
//    client.GetTable<TodoItem>();
//        public string Id { get; set; }

//        [JsonProperty(PropertyName = "text")]
//        public string Text { get; set; }

//        [JsonProperty(PropertyName = "complete")]
//        public bool Complete { get; set; }
//    }

//    public class EmployeeEntity: TableEntity
//    {
//        public EmployeeEntity(string department)
//        {
//            this.PartitionKey = department;
//            this.PartitionKey = System.Guid.NewGuid().ToString();

//        }

//        public EmployeeEntity()
//        {} public string FirstName {get; set;}
//            public string SecondName {get; set;}
//           public string Title {get; set;}
//           public string Phone {get; set;}
        
//    }
//}


