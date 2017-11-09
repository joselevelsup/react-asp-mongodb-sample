using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleReactCS.Interfaces;
using sampleReactCS.Models;

namespace sampleReactCS.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class ContactsController : Controller{
        private readonly IContactInterface _contactRepo;

        public ContactsController(IContactInterface contactRepo){
            _contactRepo = contactRepo;
        }

        private async Task<IEnumerable<Contact>> GetContactsInternal(){
            return await _contactRepo.GetAllContacts();
        }

        private async Task<Contact> GetOneContactInternal(string id){
            return await _contactRepo.GetContact(id);
        }

        [HttpGet]
        public Task<IEnumerable<Contact>> Get(){
            return GetContactsInternal();
        }

        [HttpGet("{id}")]
        public Task<Contact> GetOneContact(string id){
            return GetOneContactInternal(id);
        }

        [HttpPost]
        public void CreateContact([FromBody] Contact val){
            _contactRepo.AddContact(val);
        }
    }
}