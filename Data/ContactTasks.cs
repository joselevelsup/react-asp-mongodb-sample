using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sampleReactCS.Interfaces;
using sampleReactCS.Models;
using MongoDB.Bson;

namespace sampleReactCS.Data {
    public class ContactTasks : IContactInterface{
        
        // This variable will contain our database information. context is like a const. It can't be adjusted during run time; 
        private readonly ContactContext context = null;

        public ContactTasks(IOptions<Setting> settings){
            //Inject Database information to context;
            context = new ContactContext(settings);
        }
        public async Task<IEnumerable<Contact>> GetAllContacts(){
            // Retrieves all the documents in our Database;
            try{
                return await context.Contacts.Find(_ => true).ToListAsync();
            } catch (Exception err) {
                throw err;
            }
        }

        public async Task<Contact> GetContact(string id){
            // Only retrieves a single document in our database based on the ID;
            var filter = Builders<Contact>.Filter.Eq("Id", id);
            try {
                return await context.Contacts.Find(filter).FirstOrDefaultAsync();
            } catch(Exception err){
                throw err;
            }
        }

        public async Task AddContact(Contact contact){
            //Creates a new Document in our Database. No need for a return because this does not produce a value;
            try {
                await context.Contacts.InsertOneAsync(contact);
            } catch(Exception err){
                throw err;
            }
        }
    }
}