using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sampleReactCS.Models;

namespace sampleReactCS.Data{
    public class ContactContext{
        private readonly IMongoDatabase _database = null;

        public ContactContext(IOptions<Setting> settings){
            var client = new MongoClient(settings.Value.ConnectionString);

            if(client != null ){
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Contact> Contacts {
            get {
                return _database.GetCollection<Contact>("Contacts");
            }
        }
    }
}