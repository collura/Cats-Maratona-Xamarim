using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Cats
{
    //<T> Define the Object Type in constructor 
    public class AzureService <T>
    {
        //Object Mobile Client Service
        IMobileServiceClient Client;

        //Object Table
        IMobileServiceTable<T> Table;
      
        public AzureService()
        {
            //Url from Mobile app Service to connect...
            string MyAppServiceURL = "http://colluraappcats.azurewebsites.net";

            //Create instance of Mobile Service Client
            Client = new MobileServiceClient(MyAppServiceURL);

            //Receive Table of any Type from Azure
            Table = Client.GetTable<T>();
        }


        //Get Table of specifield type in constructor, from Azure Service
        public Task<IEnumerable<T>> GetTable() {
            return Table.ToEnumerableAsync();
        }
    }
}
