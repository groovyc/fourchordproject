//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Table;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq;
//using Newtonsoft.Json;

//namespace _4chordproject.DataModel
//{
//    public class SportingProductEntity : TableEntity
//    {
//        public SportingProductEntity(string category, string sku)
//            : base(category, sku) { }

//        public SportingProductEntity() { }

//        public string ProductName { get; set; }
//        public string Description { get; set; }

//        private static void Main()
//        {
//            string accountName = "fourchordproject";
//            string accountKey = "EwV2q2kdAD7dzy6rjqfYINjhiXLu5W0Dg2deFfNelLC352l/615Solmh9JtvaIcguRUHHrZ89zGgOsUPhzhiBg==";
//            try
//            {
//                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
//                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

//                CloudTableClient client = account.CreateCloudTableClient();

//                CloudTable table = client.GetTableReference("sportingproducts");
//                table.CreateIfNotExists();

//                Console.WriteLine(table.Uri.ToString());
//                SportingProductEntity entity = new SportingProductEntity("Baseball", "BBt1032")
//                {
//                    ProductName = "Louisville Slugger",
//                    Description = "A great bat for any level of player!"
//                };

//                TableOperation insertOperation = TableOperation.Insert(entity);
//                table.Execute(insertOperation);

//                Console.WriteLine("Entity inserted!");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(ex);
//            }

//            Console.WriteLine("Done... press a key to end.");
//            Console.ReadKey();
//        }

//    }
//}
