using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sampleReactCS.Models;
using MongoDB.Driver;

namespace sampleReactCS.Interfaces{
    public interface IContactInterface{
         Task<IEnumerable<Contact>> GetAllContacts();
         Task<Contact> GetContact(string id);
         Task AddContact(Contact contact);
    }
}