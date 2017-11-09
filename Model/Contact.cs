using System;
using MongoDB.Bson;

namespace sampleReactCS.Models{
    public class Contact {
        public ObjectId Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}

        public Contact(string name, string email){
            Name = name;
            Email = email;
        }
    }
}
