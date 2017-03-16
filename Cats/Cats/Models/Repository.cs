using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cats
{
    public class Repository
    {
        public async Task<List<Cat>> GetCats() {
            //Chamada RestFull
            //List<Cat> Cats;
            //var URLWebApi = "http://demos.ticapacitacion.com/cats";
            //using (var Client = new System.Net.Http.HttpClient()) {
            //    var JSON = await Client.GetStringAsync(URLWebApi);
            //    Cats = JsonConvert.DeserializeObject <List<Cat>> (JSON);
            //}

            //Calling to Azure Service with the Type required, in this case Cat type
            var Service = new AzureService<Cat>();

            //Var with the Table
            var Items = await Service.GetTable();

            //Return Table as List<Cat>
            return Items.ToList();
        }
    }
}
